package display.components 
{
	import flash.display.MovieClip;
	import flash.errors.IllegalOperationError;
	import flash.events.Event;
	import flash.events.MouseEvent;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import flash.text.TextFormat;
	
	/**
	 * ...
	 * @author whe
	 */
	public class RadioButton extends AbstractComponent 
	{
		protected var _enabled:Boolean;
		protected var _currentFrame:int = 1;
		
		public var _textField:TextField;
		
		private var textFormat:TextFormat = new TextFormat;
		
		public var index:int = -1;
		
		private var FOND_SIZE:int = 20;
		public function RadioButton(skin:MovieClip) 
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
				_textField = new TextField();
				_textField.width = 100;
				_textField.autoSize = TextFieldAutoSize.LEFT;
				_textField.selectable = false;
				_textField.multiline = false;
				_textField.mouseEnabled = false;
				_textField.mouseWheelEnabled = false;
				this.addChild(_textField);
				textFormat.size = FOND_SIZE;
				textFormat.font = "华文细黑";
				textFormat.color = 0xD3FCFE;
			}
		}
		
		public function set text(txt:String):void
		{
			_textField.text = txt;
			_textField.x = skinWidth;
			_textField.setTextFormat(textFormat);
		}
		
		public function get comWidth():int
		{
			return _textField.x + _textField.text.length * FOND_SIZE;
		}
		
		protected function addEvents():void
		{
			skin.addEventListener(MouseEvent.CLICK, click);
		}
		
		protected function delEvents():void
		{
			skin.removeEventListener(MouseEvent.CLICK, click);
		}
		
		public function get selected():Boolean
		{
			return (_currentFrame == 2);
		}
		
		public function set selected(b:Boolean):void
		{
			_currentFrame = b ? 2 : 1;
			(mySkin as MovieClip).gotoAndStop(_currentFrame);
			dispatchEvent(new Event(MouseEvent.CLICK));
		}
		
		private function click(e:MouseEvent):void 
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
				delEvents();
			}
			mouseChildren = mouseEnabled = value;
			_enabled = value;
		}
	}
}