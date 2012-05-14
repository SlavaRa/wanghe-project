package ttair
{
	import flash.desktop.NativeApplication;
	import flash.display.StageOrientation;
	import flash.events.Event;
	import flash.display.Sprite;
	import flash.display.StageAlign;
	import flash.display.StageScaleMode;
	import flash.events.StageOrientationEvent;
	import flash.text.TextField;
	import flash.ui.Multitouch;
	import flash.ui.MultitouchInputMode;
	
	/**
	 * ...
	 * @author
	 */
	public class Main extends Sprite
	{
		private var txt:TextField;
		private var txt2:TextField;
		
		public function Main():void
		{
			stage.scaleMode = StageScaleMode.NO_SCALE;
			stage.align = StageAlign.TOP_LEFT;
			stage.addEventListener(Event.DEACTIVATE, deactivate);
			
			// touch or gesture?
			Multitouch.inputMode = MultitouchInputMode.TOUCH_POINT;
			
			// entry point
			init();
		}
		
		private function init():void
		{
			txt = new TextField;
			txt.text = "正方向正方向正方向正方向正方向";
			addChild(txt);
			txt.x = 100;
			txt.y = 100;
			txt.width = 500;
			
			txt2 = new TextField;
			txt2.text = "正方向正方向正方向正方向正方向";
			txt2.x = 100;
			txt2.y = 150;
			txt2.width = 500;
			addChild(txt2);
			
			if (stage.supportedOrientations)
			{
				stage.addEventListener(StageOrientationEvent.ORIENTATION_CHANGING, onOrientationChangeing);
				stage.addEventListener(StageOrientationEvent.ORIENTATION_CHANGE, onOrientationChange);
			}
		}
		
		private function onOrientationChangeing(event:StageOrientationEvent):void 
		{
			txt.text = event.beforeOrientation;
			txt2.text = event.afterOrientation;
			switch (event.afterOrientation)
			{
				
				case StageOrientation.DEFAULT: 
					// re-orient display objects based on 
					// the default (right-side up) orientation. 
					//txt.text = "StageOrientation.DEFAULT";
					event.preventDefault();
					break;
				case StageOrientation.ROTATED_RIGHT: 
					// Re-orient display objects based on 
					// right-hand orientation. 
					//txt.text = "StageOrientation.ROTATED_RIGHT";
					break;
				case StageOrientation.ROTATED_LEFT: 
					// Re-orient display objects based on 
					// left-hand orientation. 
					//txt.text = "StageOrientation.ROTATED_LEFT";
					break;
				case StageOrientation.UPSIDE_DOWN: 
					// Re-orient display objects based on 
					// upside-down orientation. 
					//txt.text = "StageOrientation.UPSIDE_DOWN";
					event.preventDefault();
					break;
			}
		}
		
		private function onOrientationChange(event:StageOrientationEvent):void
		{
			switch (event.afterOrientation)
			{
				case StageOrientation.DEFAULT: 
					// re-orient display objects based on 
					// the default (right-side up) orientation. 
					//txt.text = "StageOrientation.DEFAULT";
					//event.preventDefault();
					break;
				case StageOrientation.ROTATED_RIGHT: 
					// Re-orient display objects based on 
					// right-hand orientation. 
					//txt.text = "StageOrientation.ROTATED_RIGHT";
					break;
				case StageOrientation.ROTATED_LEFT: 
					// Re-orient display objects based on 
					// left-hand orientation. 
					//txt.text = "StageOrientation.ROTATED_LEFT";
					break;
				case StageOrientation.UPSIDE_DOWN: 
					// Re-orient display objects based on 
					// upside-down orientation. 
					//txt.text = "StageOrientation.UPSIDE_DOWN";
					//event.preventDefault();
					break;
			}
		}
		
		private function deactivate(e:Event):void
		{
			// auto-close
			NativeApplication.nativeApplication.exit();
		}
	
	}

}