package view 
{
	import com.greensock.easing.Bounce;
	import com.greensock.TweenLite;
	import controller.ConstID;
	import flash.display.ShaderPrecision;
	import flash.display.SpreadMethod;
	import flash.display.Sprite;
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.mediator.Mediator;
	import view.ui.AboutUpdate;
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
		private var aboutUI:AboutUpdate;
		
		private var childArr:Array;
		
		public function TitanMediator(view:Titan) 
		{
			ui = view;
			super(NAME,view);
		}
		
		override public function listNotificationInterests():Array 
		{
			return [
					ConstID.RESET_SHOW_UI, 
					ConstID.HIDE_ME,
					ConstID.SHOW_ME
					];
		}
		
		override public function handleNotification(notification:INotification):void 
		{
			switch (notification.getName()) 
			{
				case ConstID.RESET_SHOW_UI:
					manageChildView(notification.getBody() as Sprite,notification.getType());
					break;
				case ConstID.HIDE_ME:
					hideme(notification.getBody() as Sprite);
					break;
				case ConstID.SHOW_ME:
					onShowme(notification.getBody() as Sprite);
					break;
				default:
					break;
			}
		}
	
		override public function onRegister():void 
		{
			super.onRegister();
			childArr = new Array;
			
			mainUI = new MainUIView;
			var mainUImediator:MainUIMediator = new MainUIMediator(mainUI);
			facade.registerMediator(mainUImediator);
			childArr.push(mainUI);
			ui.addChild(mainUI);
			
			gameUI = new GameView;
			var gameUImediator:GameMediator = new GameMediator(gameUI);
			facade.registerMediator(gameUImediator);
			ui.addChild(gameUI);
			childArr.push(gameUI);
			gameUI.visible = true;
			
			questionUI = new QuestionView;
			var questionUImediator:QuestionMediator = new QuestionMediator(questionUI);
			facade.registerMediator(questionUImediator);
			ui.addChild(questionUI);
			childArr.push(questionUI);
			questionUI.visible = false;
			
			shareUI = new ShareView;
			var shareUIMediator:ShareUIMediator = new ShareUIMediator(shareUI);
			facade.registerMediator(shareUIMediator);
			ui.addChild(shareUI);
			//childArr.push(shareUI);
			shareUI.visible = false;
			
			aboutUI = new AboutUpdate;
			var aboutMediator:AboutUpdateMediator = new AboutUpdateMediator(aboutUI);
			facade.registerMediator(aboutMediator);
			ui.addChild(aboutUI);
			aboutUI.visible = false;
		}
		
		private function manageChildView(sp:Sprite, type:String):void 
		{
			if (type==ConstID.SHOW_POP_UP)
			{
				for each (var item:Sprite in childArr) 
				{
					if (item == sp)
					{
						item.visible = true;
						item.mouseEnabled = true;
						ui.addChild(item);
						var midX:int = ui.stage.stageWidth / 2;
						var midY:int = ui.stage.stageHeight / 2;
						//var newX:int = (ui.stage.stageWidth) / 2;
						//var newY:int = (ui.stage.stageHeight) / 2;
						TweenLite.to(item, 0, {x:midX,y:midY, scaleX:0.1, scaleY:0.1 } );
						TweenLite.to(item, 1, { x:0, y:0, scaleX:1, scaleY:1 , ease:Bounce.easeOut } );
					}
				}	
			}
			else if (type==ConstID.SHOW_SWITCH)
			{
				for each (var item2:Sprite in childArr) 
				{
					if (item2 == sp)
					{
						item2.visible = true;
						ui.addChild(item2);
					}
					else
					{
						item2.visible = false;
					}
				}
			}
			else if (type==ConstID.HIDE_SHRINK)
			{
				var newX3:int = ui.stage.stageWidth / 2;
				var newY3:int = ui.stage.stageHeight / 2;
				
				TweenLite.to(sp, 1, { x:newX3, y:newY3, scaleX:0, scaleY:0 , ease:Bounce.easeOut, onComplete:hideme, onCompleteParams:[sp] } );
			}
		}
		
		private function hideme(sp:Sprite):void
		{
			sp.visible = false;
			sp.mouseEnabled = false;
		}
		
		private function onShowme(sp:Sprite):void
		{
			sp.visible = true;
			sp.mouseEnabled = true;
			ui.addChild(sp);
		}
		

	}
}