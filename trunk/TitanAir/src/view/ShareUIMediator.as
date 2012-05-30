package view 
{
	import controller.ConstID;
	import flash.net.navigateToURL;
	import flash.net.URLRequest;
	import model.P;
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.mediator.Mediator;
	import view.ui.ShareView;
	
	/**
	 * ...
	 * @author ...
	 */
	public class ShareUIMediator extends Mediator 
	{
		public static const NAME:String = "SHARE_UIMEDIATOR";
		public var ui:ShareView;
		public function ShareUIMediator(view:ShareView) 
		{
			ui = view;
			super(NAME, view);
		}
		
		override public function onRegister():void 
		{
			ui.onCloseCall = onClose;
			ui.onShareCall = onShare;
		}
		
		override public function listNotificationInterests():Array 
		{
			return [ConstID.SHOW_SHARE_VIEW];
		}
		
		override public function handleNotification(notification:INotification):void 
		{
			switch(notification.getName())
			{
				case ConstID.SHOW_SHARE_VIEW:
					ui.visible = true;
					ui.mouseEnabled = true;
					ui.setText(notification.getBody() as String);
					ui.setSize(1024, 600);
					sendNotification(ConstID.SHOW_ME,ui);
					break;
				default:
					break;
			}
		}
		
		private function onClose():void
		{
			ui.visible = false;
			ui.mouseEnabled = false;
			sendNotification(ConstID.HIDE_ME,ui);
		}
		
		private function onShare():void
		{
			var shareText:String = ui.ShareText;
			var url:String = "http://qipu.mopsgame.com/shareManage.do?actions=qipuShareUI";
			var title:String = "title=乳腺健康知识问答";
			var content:String = "url=";
			var uri:String = url +"&" + title +"&" +content + shareText;
			var newuri:String = encodeURI(uri);
			
			var _Newurl:URLRequest=new URLRequest(newuri);
			var _fangshi:String="_blank";
			navigateToURL(_Newurl,_fangshi);
		}
	}

}