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
		
		public function QuestionMediator(view:QuestionView)
		{
			ui = view;
			super(NAME,view);
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
					sendNotification(ConstID.RESET_SHOW_UI,ui,ConstID.SHOW_POP_UP);
					break;
				default:
					break;
			}
		}
		
		/* INTERFACE model.IQuestionDataObserver */
		
		public function notifyQuestionObserver(questionArr:Array):void 
		{
			//TODO 随机选一个 牛逼的问题进行展示
			ui.setQuestion(questionArr[5] as QuestionVO);
			trace(questionArr.length);
		}
	}

}