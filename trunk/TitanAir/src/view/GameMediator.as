package view 
{
	import controller.ConstID;
	import flash.display.Sprite;
	import flash.events.Event;
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
			ui.onPuzzleClick = onPuzzleItemClick;
			super.onRegister();
		}
		override public function listNotificationInterests():Array 
		{
			return [
					ConstID.GAME_SET_IMAGE,
					ConstID.GAME_CLEAR_IMAGE,
					ConstID.GAME_ITEM_CLEAR_FILTER
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
				case ConstID.GAME_ITEM_CLEAR_FILTER:
					setPuzzleItemFilter();
					break;
				default:
					break;
			}
		}
		
		private function puzzleComplete():void
		{
			
		}
		
		private var curItemName:String = "";
		//点击拼图格子
		private function onPuzzleItemClick(e:Event):void
		{
			var sp:Sprite = e.target as Sprite;
			curItemName = sp.name;
			//TODO 把答题界面呼出来
			sendNotification(ConstID.SHOW_QUESTION,"");
		}
		
		private function setPuzzleItemFilter():void
		{
			ui.clearItemFilter(curItemName);
		}
	}
}