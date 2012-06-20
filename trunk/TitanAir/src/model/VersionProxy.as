package model 
{
	import flash.events.Event;
	import flash.events.IOErrorEvent;
	import flash.filesystem.File;
	import flash.filesystem.FileMode;
	import flash.filesystem.FileStream;
	import flash.net.URLLoader;
	import flash.net.URLRequest;
	import model.vo.VersionVO;
	import org.puremvc.as3.patterns.proxy.Proxy;
	
	/**
	 * 检测新版本
	 * @author whe
	 */
	public class VersionProxy extends Proxy 
	{
		public static const NAME:String = "VERSION_PROXY";
		public var newverVO:VersionVO;
		public var nowverVO:VersionVO;
		private var newstring:String;
		private var iobserver:IVersionDataObserver;
		public function VersionProxy() 
		{
			newverVO = new VersionVO;
			nowverVO = new VersionVO;
			super(NAME,newverVO);
		}
		
		public function registerVersionOberver(url:String,observer:IVersionDataObserver,type:String):void
		{
			iobserver = observer;
			if (type == 'now')
			{
				var file:File = File.applicationDirectory.resolvePath("air_app_assets/" + url);
				var fs:FileStream = new FileStream(); 
				fs.open(file, FileMode.READ);
				transData(fs.readUTFBytes(fs.bytesAvailable));
				fs.close();
				//file.cancel();
			}
			else if (type=='new')
			{
				var urlloader2:URLLoader = new URLLoader(new URLRequest(url));
				urlloader2.addEventListener(Event.COMPLETE, onComplete);
				urlloader2.addEventListener(IOErrorEvent.IO_ERROR, onError);
			}
		}
		
		private function onError(e:IOErrorEvent):void 
		{
			
		}
		
		private function onComplete(e:Event):void 
		{
			transData(e.target.data as String,'new');
		}
		
		/**
		 * 
		 * @param	string
		 */
		private function transData(content:String,type:String=''):void 
		{
			//TODO: 解析XML 
			var xmlData:XML = new XML(content);
			trace(xmlData.dataSet.number);
			trace(xmlData.dataSet.description);
			var vo:VersionVO = new VersionVO;
			vo.NO = xmlData.dataSet.number.toString();
			vo.desc = xmlData.dataSet.description.toString();
			iobserver.notifyVersionObserver(vo);
			
			
			if (type == 'new')
			{
				newstring = content;

			}
		}
		
		public function writeVersion():void
		{
				var fileStr:FileStream = new FileStream();
				var file:File = new File(File.applicationDirectory.resolvePath("air_app_assets/" +  "version.xml").nativePath); //创建新的File方便后面向File写入数据
				fileStr.open(file, FileMode.WRITE); //以写入形式打开文件，准备更新
				//fileStr.position = fileStr.bytesAvailable; //将指针指向文件尾
				fileStr.writeUTFBytes(newstring);
				fileStr.close(); //关闭文件流
				trace("写入完成");
		}
	}

}