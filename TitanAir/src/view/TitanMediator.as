package view 
{
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.mediator.Mediator;
	import view.ui.GameView;
	import view.ui.MainUIView;
	import view.ui.QuestionView;
	import view.ui.ShareView;
	
	/**
	 * ...
	 * @author ...
	 */
	public class TitanMediator extends Mediator 
	{
		public static const NAME:String = "TITAN_MEDIATOR";
		public var ui:Titan;
		
		public var mainUI:MainUIView;
		public var questionUI:QuestionView;
		private var gameUI:GameView;
		private var shareUI:ShareView;
		
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
		
		override public function onRegister():void 
		{
			super.onRegister();
			
			mainUI = new MainUIView;
			var mainUImediator:MainUIMediator = new MainUIMediator(mainUI);
			facade.registerMediator(mainUImediator);
			ui.addChild(mainUI);
			
			gameUI = new GameView;
			var gameUImediator:GameMediator = new GameMediator(gameUI);
			facade.registerMediator(gameUImediator);
			ui.addChild(gameUI);
			gameUI.visible = true;
			
			questionUI = new QuestionView;
			var questionUImediator:QuestionMediator = new QuestionMediator(questionUI);
			facade.registerMediator(questionUImediator);
			ui.addChild(questionUI);
			questionUI.visible = false;
			
			shareUI = new ShareView;
			var shareUIMediator:ShareUIMediator = new ShareUIMediator(shareUI);
			facade.registerMediator(shareUIMediator);
			ui.addChild(shareUI);
			shareUI.visible = false;
			
		}
	}
}