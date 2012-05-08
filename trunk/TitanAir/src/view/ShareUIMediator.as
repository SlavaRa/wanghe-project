package view 
{
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
		
		public function ShareUIMediator(view:ShareView) 
		{
			ui = view;
			super(NAME, view);
		}
		
		override public function listNotificationInterests():Array 
		{
			return super.listNotificationInterests();
		}
		
		override public function handleNotification(notification:INotification):void 
		{
			super.handleNotification(notification);
		}
	}

}