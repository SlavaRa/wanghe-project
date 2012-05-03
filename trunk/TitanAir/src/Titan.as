package 
{
	import flash.desktop.NativeApplication;
	import flash.events.Event;
	import flash.display.Sprite;
	import flash.display.StageAlign;
	import flash.display.StageScaleMode;
	import flash.ui.Multitouch;
	import flash.ui.MultitouchInputMode;
	
	/**
	 * ...
	 * @author 
	 */
	public class Titan extends Sprite 
	{
		
		public function Titan():void 
		{
			stage.scaleMode = StageScaleMode.NO_SCALE;
			stage.align = StageAlign.TOP_LEFT;
			addEventListener(Event.ADDED_TO_STAGE, onStageInit, false, 0, true);
			// touch or gesture?
			Multitouch.inputMode = MultitouchInputMode.TOUCH_POINT;
			
			// entry point
		}
		
		private function onStageInit(e:Event):void 
		{
			removeEventListener(Event.ADDED_TO_STAGE, onStageInit);
			TitanFacade.getInstance().startup(this);
		}
		
		private function deactivate(e:Event):void 
		{
			// auto-close
		}
		
	}
	
}