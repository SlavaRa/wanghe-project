package view 
{
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.mediator.Mediator;
	import view.ui.GameView;
	
	/**
	 * ...
	 * @author 
	 */
	public class GameMediator extends Mediator 
	{
		public static const NAME:String = "GAME_MEDIATOR";
		
		public var ui:GameView;
		public function GameMediator(view:GameView) 
		{	
			ui = view;
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