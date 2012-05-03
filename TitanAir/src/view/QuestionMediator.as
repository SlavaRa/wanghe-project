package view 
{
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.mediator.Mediator;
	import view.ui.QuestionView;
	
	/**
	 * ...
	 * @author 
	 */
	public class QuestionMediator extends Mediator 
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
			return super.listNotificationInterests();
		}
		
		override public function handleNotification(notification:INotification):void 
		{
			super.handleNotification(notification);
		}
	}

}