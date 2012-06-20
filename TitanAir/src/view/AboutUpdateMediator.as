package view
{
	import com.riaidea.utils.zip.ZipArchive;
	import com.riaidea.utils.zip.ZipEvent;
	import com.riaidea.utils.zip.ZipFile;
	import controller.ConstID;
	import flash.desktop.NativeApplication;
	import flash.display.Loader;
	import flash.events.Event;
	import flash.events.IEventDispatcher;
	import flash.events.IOErrorEvent;
	import flash.events.ProgressEvent;
	import flash.events.SecurityErrorEvent;
	import flash.filesystem.File;
	import flash.filesystem.FileMode;
	import flash.filesystem.FileStream;
	import flash.net.URLLoader;
	import flash.net.URLLoaderDataFormat;
	import flash.net.URLRequest;
	import flash.system.ApplicationDomain;
	import flash.system.LoaderContext;
	import flash.utils.ByteArray;
	import model.P;
	import model.vo.VersionVO;
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.mediator.Mediator;
	import view.ui.AboutUpdate;
	
	/**
	 * ...
	 * @author
	 */
	public class AboutUpdateMediator extends Mediator
	{
		public static const NAME:String = "AboutUpdateMediator";
		public var ui:AboutUpdate;
		
		private var downFileURL:URLRequest;
		private var netFile:URLLoader;
		
		private var nowVersion:VersionVO;//当前的版本
		private var newVersion:VersionVO;//新的版本
		
		public function AboutUpdateMediator(viewComponent:AboutUpdate)
		{
			ui = viewComponent;
			super(NAME, ui);
		}
		
		override public function onRegister():void
		{
			ui.onUpdateCall = onUpdateCall;
			ui.onReutrnCall = onReturnCall;
		}
		

		
		override public function listNotificationInterests():Array
		{
			return [ConstID.SHOW_SETTING_VIEW,ConstID.CHECK_VERSION];
		}
		
		override public function handleNotification(notification:INotification):void
		{
			switch (notification.getName())
			{
				case ConstID.SHOW_SETTING_VIEW: 
					sendNotification(ConstID.RESET_SHOW_UI, ui, ConstID.SHOW_POP_UP);
					break;
				case ConstID.CHECK_VERSION:
					checkVersion();
					break;
				default: 
					break;
			}
		}
		
		//检查版本
		private function checkVersion():void 
		{
			nowVersion = new VersionVO;
			nowVersion.completeCall = nowVersionCall;
			P.versionProxy.registerVersionOberver("version.xml", nowVersion,'now');
		}
		
		//现在版本回调
		private function nowVersionCall(vo:VersionVO):void 
		{
			P.versionProxy.nowverVO = vo;
			nowVersion = vo;
			trace(vo.NO);
			newVersion = new VersionVO;
			newVersion.completeCall = newVersionCall;
			P.versionProxy.registerVersionOberver(ConstID.UPDATE_XML_URL,newVersion,'new');
		}
		
		//新版本回调
		private function newVersionCall(vo:VersionVO):void 
		{
			P.versionProxy.newverVO = vo;
			newVersion = vo;
			trace(vo.NO);
			if (newVersion.NO != null && newVersion.NO != ""&&nowVersion.NO!=null&&nowVersion.NO!="")
			{
				if (newVersion.NO != nowVersion.NO)
				{
					sendNotification(ConstID.RESET_SHOW_UI, ui, ConstID.SHOW_POP_UP);
				}
			}
		}
		
		private function onUpdateCall():void
		{
			downLoad(ConstID.UPDATE_DAT_URL);
		}
		
		private function onReturnCall():void 
		{
			sendNotification(ConstID.HIDE_ME,ui);
		}
		
		public function downLoad(netFileURL:String):void
		{
			downFileURL = new URLRequest(netFileURL);
			netFile = new URLLoader();
			netFile.dataFormat = URLLoaderDataFormat.BINARY;
			configureListeners(netFile);
			try
			{
				netFile.load(downFileURL);
			}
			catch (e:Error)
			{
				trace("启动下载失败");
			}
		}
		
		private function configureListeners(dispatcher:IEventDispatcher):void
		{
			dispatcher.addEventListener(IOErrorEvent.IO_ERROR, ioErrorHandler);
			dispatcher.addEventListener(SecurityErrorEvent.SECURITY_ERROR, securityErrorHandler); //当由于安全错误导致下载失败时调度
			dispatcher.addEventListener(Event.OPEN, openHandler); // 当下载操作开始时调度
			dispatcher.addEventListener(ProgressEvent.PROGRESS, progressHandler); //在文件下载操作期间进行定期调度
			dispatcher.addEventListener(Event.COMPLETE, completeHandler); //当文件下载操作成功完成时调度
		}
		
		private function openHandler(event:Event):void
		{
		
		}
		
		private function progressHandler(event:ProgressEvent):void
		{
			ui.setProgressBar(event.bytesLoaded, event.bytesTotal);
		}
		
		private function completeHandler(event:Event):void
		{
			var f:File = new File(File.applicationDirectory.resolvePath("air_app_assets/" + "res_data.zip").nativePath);
			var fs:FileStream = new FileStream();
			fs.open(f, FileMode.WRITE);
			fs.writeBytes(event.target.data);
			fs.close();
			trace("下载完成！！");
			ui.txt = "下载完成！正在解压!请耐心等待";
			loadzipFile(File.applicationDirectory.resolvePath("air_app_assets/" + "res_data.zip").nativePath);
		}
		
		private function ioErrorHandler(event:IOErrorEvent):void
		{
			ui.txt = "下载出错，请检查网络状态~";
			trace("错误信息: " + event);
		}
		
		private function securityErrorHandler(event:SecurityErrorEvent):void
		{
			trace("securityErrorHandler: " + event);
		}
		
		private var zip1:ZipArchive = new ZipArchive();
		
		private function loadzipFile(str:String):void
		{
			zip1.addEventListener(ZipEvent.PROGRESS, loading);
			zip1.addEventListener(ZipEvent.INIT, inited);
			zip1.addEventListener(ZipEvent.ERROR, failed);
			zip1.load(str);
		}
		
		private function inited(e:ZipEvent):void
		{
			zip1.removeEventListener(ZipEvent.PROGRESS, loading);
			zip1.removeEventListener(ZipEvent.INIT, inited);
			zip1.removeEventListener(ZipEvent.ERROR, failed);
			
			var len:int = zip1.numFiles;
			
			for (var i:int = 0; i < len; i++)
			{
				var newZipFile:ZipFile = zip1.getFileAt(i);
				var byteArray:ByteArray = new ByteArray();
				byteArray = newZipFile.data;
				var fileStr:FileStream = new FileStream();
				var file:File = new File(File.applicationDirectory.resolvePath("air_app_assets/" +  newZipFile.name).nativePath); //创建新的File方便后面向File写入数据
				fileStr.open(file, FileMode.WRITE); //以写入形式打开文件，准备更新
				//fileStr.position = fileStr.bytesAvailable; //将指针指向文件尾
				fileStr.writeBytes(byteArray, 0, byteArray.length); //在文件中写入新下载的数据
				fileStr.close(); //关闭文件流
			}
			
			P.versionProxy.writeVersion();
			ui.txt = "更新完成！请重启应用程序!";
			
		}
		
		private function failed(e:ZipEvent):void
		{
			ui.txt = "更新出错！请重试！";
		}
		
		private function loading(e:ZipEvent):void
		{
			//ui.setProgressBar(e.message.bytesLoaded, e.message.bytesTotal);
		}
	
	}

}