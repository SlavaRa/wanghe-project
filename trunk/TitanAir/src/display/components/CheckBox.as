package display.components
{
	import flash.display.MovieClip;
	import flash.errors.IllegalOperationError;
	import flash.events.MouseEvent;
	
	/**
	 * ...
	 * @author ...
	 */
	public class CheckBox extends AbstractComponent
	{
		protected var _enabled:Boolean;
		protected var _currentFrame:int = 1;
		
		
		public function CheckBox(skin:MovieClip)
		{
			if (skin)
			{
				super(skin);
				if (skin.totalFrames < 2)
				{
					throw new IllegalOperationError("需要至少2帧");
				}
				skin.mouseChildren = false;
				skin.gotoAndStop(1);
				addEvents();
			}
		}
		
		public function get selected():Boolean
		{
			return (_currentFrame == 2);
		}
		
		public function set selected(b:Boolean):void
		{
			_currentFrame = b ? 2 : 1;
			(mySkin as MovieClip).gotoAndStop(_currentFrame);
		}
		
		protected function addEvents():void
		{
			skin.addEventListener(MouseEvent.CLICK, click);
		}
		
		protected function delEvents():void
		{
			skin.removeEventListener(MouseEvent.CLICK, click);
		}
		
		protected function click(event:MouseEvent):void
		{
			if (_currentFrame == 1)
			{
				(mySkin as MovieClip).gotoAndStop(2);
				_currentFrame = 2;
			}
			else
			{
				(mySkin as MovieClip).gotoAndStop(1);
				_currentFrame = 1;
			}
		}
		
		public function set enabled(value:Boolean):void
		{
			if (value) //可用
			{
				addEvents();
				mySkin.filters = [];
			}
			else //不可用
			{
				//mySkin.filters = Filter.disableFilter;
				delEvents();
			}
			mouseChildren = mouseEnabled = value;
			_enabled = value;
		}
	}
}