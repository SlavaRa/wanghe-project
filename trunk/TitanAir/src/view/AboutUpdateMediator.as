package view
{
	import controller.ConstID;
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
		
		public function AboutUpdateMediator(viewComponent:AboutUpdate)
		{
			ui = viewComponent;
			super(NAME, ui);
		}
		
		override public function onRegister():void
		{
			ui.onUpdateCall = onUpdateCall;
		}
		
		override public function listNotificationInterests():Array
		{
			return [ConstID.SHOW_SETTING_VIEW];
		}
		
		override public function handleNotification(notification:INotification):void
		{
			switch (notification.getName())
			{
				case ConstID.SHOW_SETTING_VIEW: 
					sendNotification(ConstID.RESET_SHOW_UI, ui, ConstID.SHOW_POP_UP);
					break;
				default: 
					break;
			}
		}
		
		private function onUpdateCall():void
		{
			downLoad(ConstID.UPDATE_DAT_URL);
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
		
		}
		
		private function completeHandler(event:Event):void
		{
			var f:File = new File(File.applicationDirectory.resolvePath("air_app_assets/" + "res_data.rar").nativePath);
			var fs:FileStream = new FileStream();
			fs.open(f, FileMode.WRITE);
			fs.writeBytes(event.target.data);
			fs.close();
			trace("下载完成！！");
		}
		
		private function ioErrorHandler(event:IOErrorEvent):void
		{
			trace("错误信息: " + event);
		}
		
		private function securityErrorHandler(event:SecurityErrorEvent):void
		{
			trace("securityErrorHandler: " + event);
		}
	}

}