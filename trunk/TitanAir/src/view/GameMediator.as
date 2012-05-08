package view 
{
	import controller.ConstID;
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
		
		override public function onRegister():void 
		{
			ui.onPuzzleComplete = puzzleComplete;
			super.onRegister();
		}
		override public function listNotificationInterests():Array 
		{
			return [
					ConstID.GAME_SET_IMAGE,
					ConstID.GAME_CLEAR_IMAGE
					];
		}
		
		override public function handleNotification(notification:INotification):void 
		{
			switch (notification.getName()) 
			{
				case ConstID.GAME_SET_IMAGE:
					ui.setImage(notification.getBody() as String);
					break;
				case ConstID.GAME_CLEAR_IMAGE:
					break;
				default:
					break;
			}
		}
		
		private function puzzleComplete():void
		{
			
		}
	}
}