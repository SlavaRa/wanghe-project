package view
{
	import flash.events.Event;
	import flash.events.IEventDispatcher;
	import flash.events.IOErrorEvent;
	import flash.events.ProgressEvent;
	import flash.events.SecurityErrorEvent;
	import flash.filesystem.File;
	import flash.net.URLRequest;
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.mediator.Mediator;
	import view.ui.AboutUpdate;
	
	/**
	 * ...
	 * @author
	 */
	public class AboutUpdateMediator extends Mediator
	{
		public var ui:AboutUpdate;
		
		private var downFileURL:URLRequest;
		private var netFile:File;
		
		public function AboutUpdateMediator(viewComponent:AboutUpdate)
		{
			ui = viewComponent;
		}
		
		override public function onRegister():void
		{
			ui.onUpdateCall = onUpdateCall;
		}
		
		override public function listNotificationInterests():Array
		{
			return [];
		}
		
		override public function handleNotification(notification:INotification):void
		{
			switch (notification.getName())
			{
				default: 
					break;
			}
		}
		
		private function onUpdateCall():void
		{
			downLoad();
		}
		
		public function downLoad(netFileURL:String):void
		{
			downFileURL = new URLRequest(netFileURL);
			netFile = new File();
			configureListeners(netFile);
			netFile.download(downFileURL);
		}
		
		private function configureListeners(dispatcher:IEventDispatcher):void
		{
			dispatcher.addEventListener(IOErrorEvent.IO_ERROR, ioErrorHandler);
			dispatcher.addEventListener(SecurityErrorEvent.SECURITY_ERROR, securityErrorHandler); //当由于安全错误导致下载失败时调度
			dispatcher.addEventListener(Event.SELECT, selectHandler); //当用户从对话框中选择要下载的文件时调度
			dispatcher.addEventListener(Event.OPEN, openHandler); // 当下载操作开始时调度
			dispatcher.addEventListener(ProgressEvent.PROGRESS, progressHandler); //在文件下载操作期间进行定期调度
			dispatcher.addEventListener(Event.CANCEL, cancelHandler); //当用户取消对话框时调度
			dispatcher.addEventListener(Event.COMPLETE, completeHandler); //当文件下载操作成功完成时调度
		}
		
		private function selectHandler(event:Event):void
		{
			var file:File = File(event.target);
			trace("下载文件本地存放绝对路径：" + file.nativePath); //下载文件本地存放绝对路径：E:\flex4\logo_cn.gif
			trace(file.url); //file:///E:/flex4/logo_cn.gif
		}
		
		private function openHandler(event:Event):void
		{
			
		}
		
		private function progressHandler(event:ProgressEvent):void
		{
			var file:File = File(event.target);
			ui.setProgressBar(event.bytesLoaded, event.bytesTotal);
			trace("文件本地化后的名称：" + file.name); //文件本地化后的名称：logo_cn.gif
			trace("文件下载到本地的日期：" + file.creationDate); //Fri Jan 15 09:15:29 GMT+0800 2010
			trace("到本地时的文件大小：" + file.size); //到本地时的文件大小：7763
			trace("已下载字节数：" + event.bytesLoaded); //已下载字节数：7763
			trace("文件总字节数：" + event.bytesTotal); //文件总字节数：7763
		}
		
		private function cancelHandler(event:Event):void
		{

		}
		
		private function completeHandler(event:Event):void
		{
			var file:File = File(event.target);
			trace("文件格式：" + file.type); //文件格式：.gif
			trace("文件格式(没点，推荐使用的)：" + file.extension); //文件格式(没点，推荐使用的)：gif
			trace("文件创建者：" + file.creator); //文件创建者：null
			trace(file.data); //
			trace("是否为目录：" + file.isDirectory); //是否为目录：false
			trace("是否隐藏：" + file.isHidden); //是否隐藏：false
			trace("存储分区空间总大小(字节)：" + file.spaceAvailable); //存储分区空间总大小(字节)：148634128384
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