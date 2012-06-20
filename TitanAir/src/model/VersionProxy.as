package model 
{
	import flash.events.Event;
	import flash.filesystem.File;
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
		private var verVO:VersionVO;
		private var iobserver:IVersionDataObserver;
		public function VersionProxy() 
		{
			verVO = new VersionVO;
			super(NAME,verVO);
		}
		
		public function registerVersionOberver(url:String,observer:IVersionDataObserver):void
		{
			iobserver = observer;
			//var file:File = File.applicationDirectory.resolvePath(url);
			//var file:File = File.documentsDirectory.resolvePath(filepath);
			var urlloader:URLLoader = new URLLoader(new URLRequest(url));
			urlloader.addEventListener(Event.COMPLETE, onComplete, false, 0, true);
		}
		
		private function onComplete(e:Event):void 
		{
			transData(e.target.data as String);
		}
		
		/**
		 * 
		 * @param	string
		 */
		private function transData(string:String):void 
		{
			//TODO: 解析XML 
		}
		
	}

}