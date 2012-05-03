package view 
{
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.mediator.Mediator;
	import view.ui.MainUIView;
	
	/**
	 * ...
	 * @author 
	 */
	public class MainUIMediator extends Mediator 
	{
		public static const NAME:String = "MAIN_UI_MEDIATOR";
		public var ui:MainUIView;
		
		public function MainUIMediator(view:MainUIView) 
		{
			ui = view;
			super(NAME,view);
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