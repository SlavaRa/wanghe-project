package view 
{
	import controller.ConstID;
	import flash.display.Sprite;
	import flash.events.Event;
	import model.P;
	import model.vo.QuestionVO;
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
			ui.onShareClickCall = onShareClick;
			ui.onSettingClickCall = onSettingClick;
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
					sendNotification(ConstID.RESET_SHOW_UI,this.ui,ConstID.SHOW_SWITCH);
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
			if (P.questionProxy.getRandomUnAnswerQuestion() == null)
			{
				ui.clearAllFilter();
				var score:int = 0;
				for each(var item:QuestionVO in P.questionProxy.questions)
				{
					if (item.state == 1)
						score++;
				}
				ui.setScore(score);
				sendNotification(ConstID.SHOW_SHARE_VIEW,"我在健康知识问答中获得"+(score*10).toString()+"分,快来答题吧~！");
			}
			else
			{
				ui.clearItemFilter(curItemName);
			}
		}
		
		private function onShareClick():void
		{
			sendNotification(ConstID.SHOW_SHARE_VIEW,"分享到社区。。。");
		}
		
		private function onSettingClick():void 
		{
			sendNotification(ConstID.SHOW_SETTING_VIEW);
		}
	}
}