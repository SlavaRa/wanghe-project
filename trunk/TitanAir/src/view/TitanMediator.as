package view 
{
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.mediator.Mediator;
	
	/**
	 * ...
	 * @author ...
	 */
	public class TitanMediator extends Mediator 
	{
		public static const NAME:String = "TITAN_MEDIATOR";
		public var ui:Titan;
		
		public function TitanMediator(view:Titan) 
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