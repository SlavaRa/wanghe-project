package 
{
	import flash.desktop.NativeApplication;
	import flash.display.StageOrientation;
	import flash.events.Event;
	import flash.display.Sprite;
	import flash.display.StageAlign;
	import flash.display.StageScaleMode;
	import flash.events.StageOrientationEvent;
	import flash.ui.Multitouch;
	import flash.ui.MultitouchInputMode;
	
	/**
	 * whe
	 * @author 
	 */
	public class Titan extends Sprite 
	{
		
		public function Titan():void 
		{
			stage.scaleMode = StageScaleMode.NO_SCALE;
			stage.align = StageAlign.TOP_LEFT;
			addEventListener(Event.ADDED_TO_STAGE, onStageInit, false, 0, true);
			stage.addEventListener(Event.DEACTIVATE, deactivate);
			// touch or gesture?
			Multitouch.inputMode = MultitouchInputMode.TOUCH_POINT;
			
			// entry point
			init();
		}
		
		private function init():void 
		{
			if (stage.supportedOrientations)
			{
				stage.addEventListener(StageOrientationEvent.ORIENTATION_CHANGING, onOrientationChangeing);
				//stage.addEventListener(StageOrientationEvent.ORIENTATION_CHANGE, onOrientationChange);
			}
		}
		private function onOrientationChangeing(event:StageOrientationEvent):void 
		{
			switch (event.afterOrientation)
			{
				case StageOrientation.DEFAULT: 
					event.preventDefault();
					break;
				case StageOrientation.ROTATED_RIGHT: 
					break;
				case StageOrientation.ROTATED_LEFT: 
					break;
				case StageOrientation.UPSIDE_DOWN: 
					event.preventDefault();
					break;
				default:
					event.preventDefault();
					break;
			}
		}
		
/*		private function onOrientationChange(event:StageOrientationEvent):void
		{
			switch (event.afterOrientation)
			{
				case StageOrientation.DEFAULT: 
					break;
				case StageOrientation.ROTATED_RIGHT: 
					break;
				case StageOrientation.ROTATED_LEFT: 
					break;
				case StageOrientation.UPSIDE_DOWN: 
					break;
			}
		}*/
		
		private function onStageInit(e:Event):void 
		{
			removeEventListener(Event.ADDED_TO_STAGE, onStageInit);
			TitanFacade.getInstance().startup(this);
		}
		
		private function deactivate(e:Event):void
		{
			NativeApplication.nativeApplication.exit();
		}
		
	}
	
}