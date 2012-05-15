package view 
{
	import controller.ConstID;
	import model.IQuestionDataObserver;
	import model.P;
	import model.vo.QuestionVO;
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.mediator.Mediator;
	import view.ui.QuestionView;
	
	/**
	 * ...
	 * @author 
	 */
	public class QuestionMediator extends Mediator implements IQuestionDataObserver
	{
		public static const NAME:String = "QUESTION_MEDIATOR";
		public var ui:QuestionView;
		
		private var isAnswered:Boolean = false;
		
		public function QuestionMediator(view:QuestionView)
		{
			ui = view;
			super(NAME,view);
		}
		
		override public function onRegister():void 
		{
			ui.onApplyCall = onApplyCall;
			ui.onReturn = onReturnCall;
		}
		

		override public function listNotificationInterests():Array 
		{
			return [ConstID.SHOW_QUESTION];
		}
		
		override public function handleNotification(notification:INotification):void 
		{
			switch (notification.getName()) 
			{
				case ConstID.SHOW_QUESTION:
					P.questionProxy.registerQuestionObserver(ConstID.FILE_PATH,this);
					sendNotification(ConstID.RESET_SHOW_UI, ui, ConstID.SHOW_POP_UP);
					break;
				default:
					break;
			}
		}
		
		public function notifyQuestionObserver(questionArr:Array):void
		{
			//TODO 随机选一个 牛逼的问题进行展示
			var vo:QuestionVO = P.questionProxy.getRandomUnAnswerQuestion();
			ui.setQuestion(vo);
		}
		
		private function onApplyCall():void 
		{
			if (isAnswered == false)
			{
				ui.showExplain();
			}
			else
			{
				sendNotification(ConstID.GAME_ITEM_CLEAR_FILTER);
			}
		}
		
		private function onReturnCall():void
		{
			sendNotification(ConstID.GAME_ITEM_CLEAR_FILTER);
		}
	}

}