using System;
using System.Collections.Generic;
using System.Text;
using PluginCore;
using System.ComponentModel;
using PluginCore.Managers;
using ProjectManager.Projects;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using ProjectManager;

namespace AojianModule
{
    public class PluginMain:IPlugin
    {
        private String pluginName = "AojianModule";
        private String pluginGuid = "78A80582-2E8E-4e02-8E48-AD0063BCFD8C";
        private String pluginHelp = "www.flashdevelop.org/community/";
        private String pluginDesc = "傲剑2模块向导";
        private String pluginAuth = "He Wang";
        private IMainForm mainForm;
        private string  lastFileFromTemplate;

        private string sendProName;
        private string receiveProName;
        private string proName;

        #region IPlugin 成员

        public void Dispose()
        {
           
        }

        public void Initialize()
        {
            this.AddEventHandlers();
            mainForm = PluginBase.MainForm;
        }

        public void AddEventHandlers()
        {
            EventManager.AddEventHandler(this, EventType.Command | EventType.ProcessArgs);
            EventManager.AddEventHandler(this, EventType.FileSwitch, HandlingPriority.Low);
        }


        public int Api
        {
            get { return 1; }
        }

        public string Name
        {
            get { return pluginName; }
        }

        public string Guid
        {
            get { return pluginGuid; }
        }

        public string Help
        {
            get { return pluginHelp; }
        }

        public string Author
        {
            get { return pluginAuth; }
        }

        public string Description
        {
            get { return pluginDesc; }
        }

        public object Settings
        {
            get { return null; }
        }

        #endregion

        #region IEventHandler 成员

        public void HandleEvent(object sender, NotifyEvent e, HandlingPriority priority)
        {
            Project project;
            switch (e.Type)
            {
                case EventType.Command:
                    DataEvent evt = (DataEvent)e;
                    if (evt.Action == "ProjectManager.CreateNewFile")
                    {
                        Hashtable table = evt.Data as Hashtable;
                        project = PluginBase.CurrentProject as Project;
                        if ((project.Language.StartsWith("as")) && IsModuleTemplate(table["templatePath"] as String))
                        {
                            evt.Handled = true;
                            showWizard(table["inDirectory"] as string, table["templatePath"] as String);
                            
                            //String className = table.ContainsKey("className") ? table["className"] as String : TextHelper.GetString("Wizard.Label.NewClass");
                            //DisplayClassWizard(table["inDirectory"] as String, table["templatePath"] as String, className, table["constructorArgs"] as String, table["constructorArgTypes"] as List<String>);
                        }
                    }
                    break;

                //case EventType.FileSwitch:
                //    if (PluginBase.MainForm.CurrentDocument.FileName == processOnSwitch)
                //    {
                //        processOnSwitch = null;
                //        if (lastFileOptions == null || lastFileOptions.interfaces == null) return;
                //        foreach (String cname in lastFileOptions.interfaces)
                //        {
                //            ASContext.Context.CurrentModel.Check();
                //            ClassModel inClass = ASContext.Context.CurrentModel.GetPublicClass();
                //            ASGenerator.SetJobContext(null, cname, null, null);
                //            ASGenerator.GenerateJob(GeneratorJobType.ImplementInterface, null, inClass, null, null);
                //        }
                //        lastFileOptions = null;
                //    }
                //    break;

                case EventType.ProcessArgs:
                    TextEvent te = e as TextEvent;
                    project = PluginBase.CurrentProject as Project;
                    if (lastFileFromTemplate != null && project != null && (project.Language.StartsWith("as")))
                    {
                        te.Value = ProcessArgs(project, te.Value);
                    }
                    break;
            }
        }

        public string ProcessArgs(Project project, string args)
        {
            if (lastFileFromTemplate != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(lastFileFromTemplate);

                args = args.Replace("$(FileName)", fileName);

                if (args.Contains("$(FileNameWithPackage)") || args.Contains("$(Package)"))
                {
                    string package = "";
                    string path = lastFileFromTemplate;

                    // Find closest parent
                    string classpath = project.AbsoluteClasspaths.GetClosestParent(path);

                    // Can't find parent, look in global classpaths
                    if (classpath == null)
                    {
                        PathCollection globalPaths = new PathCollection();
                        foreach (string cp in ProjectManager.PluginMain.Settings.GlobalClasspaths)
                            globalPaths.Add(cp);
                        classpath = globalPaths.GetClosestParent(path);
                    }
                    if (classpath != null)
                    {
                        // Parse package name from path
                        package = Path.GetDirectoryName(ProjectPaths.GetRelativePath(classpath, path));
                        package = package.Replace(Path.DirectorySeparatorChar, '.');
                    }

                    args = args.Replace("$(Package)", package);
                    args = args.Replace("$(ProName)", proName);
                    args = args.Replace("$(ProRecName)", receiveProName);
                    args = args.Replace("$(ProSendName)", sendProName);
                    if (package != "")
                        args = args.Replace("$(FileNameWithPackage)", package + "." + fileName);
                    else
                        args = args.Replace("$(FileNameWithPackage)", fileName);
                }
            }
            return args;
        }

        private bool IsModuleTemplate(string templateFile)
        {
            return templateFile != null && File.Exists(templateFile + ".module");
        }


        private void showWizard(string inDirectory, string templatePath)
        {
            AojianModuleWinzard dialog = new AojianModuleWinzard();
            dialog.showPath = inDirectory;
            if(dialog.ShowDialog()==DialogResult.OK)
            {
                //创建目录 创建文件
                string folederName = dialog.Folder;
                string moduleName = dialog.ModuleName;

                sendProName=moduleName+"_send_Processor";
                receiveProName= moduleName + "_receive_Processor";
                proName = moduleName + "_Processor";

                string path = Path.Combine(inDirectory, folederName);
                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    Directory.CreateDirectory(path+"\\view");
                }

                FileInfo fi = new FileInfo(templatePath);
                string di = fi.DirectoryName;

                lastFileFromTemplate = path + "\\" + moduleName + "_Module.as";

                string templeFile = di + "\\" + "Temp_Module.as.fdt";
                mainForm.FileFromTemplate(templeFile, path+"\\"+moduleName+"_Module.as");

                lastFileFromTemplate = path + "\\" + moduleName + "_receive_Processor.as";

                templeFile = di + "\\" + "Receive_receive_Processor.as.fdt";
                path = Path.Combine(path, "view");
                mainForm.FileFromTemplate(templeFile, path + "\\" + moduleName + "_receive_Processor.as");

                lastFileFromTemplate = path + "\\" + moduleName + "_send_Processor.as";

                templeFile = di + "\\" + "Send_send_Processor.as.fdt";
                mainForm.FileFromTemplate(templeFile, path + "\\" + moduleName + "_send_Processor.as");

                lastFileFromTemplate = path + "\\" + moduleName + "_Processor.as";

                templeFile = di + "\\" + "Normal_Processor.as.fdt";
                mainForm.FileFromTemplate(templeFile, path + "\\" + moduleName + "_Processor.as");
				
				lastFileFromTemplate = null;
            }
            
        }
        #endregion
    }
}
