package view.ui
{
	import com.titan.checkboxskin;
	import com.titan.playbtn;
	import com.titan.questionUI;
	import com.titan.radiobtnskin;
	import controller.ConstID;
	import display.components.CheckBox;
	import display.components.RadioButton;
	import display.components.RadioButtonGroup;
	import flash.display.DisplayObject;
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.events.IOErrorEvent;
	import flash.events.MouseEvent;
	import flash.events.ProgressEvent;
	import flash.filesystem.File;
	import flash.media.Sound;
	import flash.media.SoundChannel;
	import flash.media.SoundLoaderContext;
	import flash.net.URLRequest;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import flash.text.TextFormat;
	import model.vo.OptionVO;
	import model.vo.QuestionVO;
	
	/**
	 * ...
	 * @author
	 */
	public class QuestionView extends Sprite
	{
		private var ui:questionUI;
		private var question:TextField;
		private var _cureVO:QuestionVO;
		private var optionsArr:Array;
		private var textFormat:TextFormat = new TextFormat;
		private var answertextFormat:TextFormat = new TextFormat;
		private var explaintextFormat:TextFormat = new TextFormat;
		
		private var answer:TextField;
		private var explain:TextField;
		
		private var QUES_FOND_SIZE:int = 24;
		private var ANSWER_FOND_SIZE:int = 20;
		private var OPTION_PADDING:int = 40;
		private var ANSWER_PADDING:int = 10;
		private var LEFT_PADDING:int = 50;
		
		
		private var radiobtnGroup:RadioButtonGroup = new RadioButtonGroup;
		
		public var onApplyCall:Function;
		public var onReturn:Function;
		public function QuestionView()
		{
			ui = new questionUI;
			addChild(ui);
			
			question = new TextField();
			question.multiline = true;
			question.x = LEFT_PADDING;
			question.y = 122;
			question.width = 512;
			question.height = 200;
			question.selectable = false;
			question.mouseEnabled = false;
			//question.autoSize = TextFieldAutoSize.LEFT;
			ui.addChild(question);
			
			answer = new TextField;
			answer.multiline = false;
			answer.x = LEFT_PADDING;
			answer.width = 512;
			answer.selectable = false;
			answer.mouseEnabled = false;
			answer.autoSize = TextFieldAutoSize.LEFT;
			answer.text = "正确答案";
			ui.addChild(answer);
			
			//TODO fix position
			explain = new TextField;
			explain.multiline = true;
			explain.wordWrap = true;
			explain.autoSize = "left";
			explain.x = 620;
			explain.y = 180;
			explain.width = 380;
			explain.selectable = false;
			explain.mouseEnabled = false;
			ui.addChild(explain);
			
			
			ui.btnAnswer.addEventListener(MouseEvent.CLICK, onApply, false, 0, true);
			ui.btnReturn.addEventListener(MouseEvent.CLICK, onReturnClick, false, 0, true);
			
			optionsArr = new Array;
			
			textFormat.size = QUES_FOND_SIZE;
			textFormat.font = "微软雅黑";
			textFormat.color = 0x595959;
			
			answertextFormat.size = ANSWER_FOND_SIZE;
			answertextFormat.font = "微软雅黑";
			answertextFormat.color = 0x595959;
			
			explaintextFormat.size = ANSWER_FOND_SIZE;
			explaintextFormat.font = "微软雅黑";
			explaintextFormat.color = 0x8AC234;
			
			
			plybtn = new CheckBox(ui.plybtn);
			ui.addChild(plybtn);
			plybtn.addEventListener(MouseEvent.CLICK, onPlayClick, false, 0, true);
			
			sound = new Sound();
		}
		
		private function onReturnClick(e:MouseEvent):void 
		{
			if (onReturn!=null)
			{
				if (_cureVO.state == -1)
					_cureVO.state = 0;
				onReturn();
				if(soundChannel)
					soundChannel.stop();
			}
		}
		
		public function setQuestion(quesVO:QuestionVO):void
		{
			resetUI();
			if (quesVO == null)
			{
				return;
			}
			_cureVO = quesVO;
			
			question.text = quesVO.content;
			question.setTextFormat(textFormat);
			
			answer.y = question.y + question.numLines * QUES_FOND_SIZE + ANSWER_PADDING;
			answer.text = "";
			
			setOptions();
			soundChannel = null;
		}
		
		public function resetUI():void 
		{
			question.text = "";
			explain.text = "";
			_cureVO = null;
			for each(var item:Object in optionsArr)
			{
				if (ui.contains(item.display as DisplayObject))
				{
					ui.removeChild(item.display as DisplayObject);
				}
			}
			optionsArr.length = 0;
			radiobtnGroup.clear();
		}
		
		private var lineCount:int = 0;
		private var ypo:int = 0;//问题解释
		//设置选项
		public function setOptions():void
		{
			optionsArr.length = 0;
			radiobtnGroup.clear();
			var lengthCount:Number = LEFT_PADDING;
			var yPosition:Number = question.y + question.numLines * QUES_FOND_SIZE + OPTION_PADDING;
			lineCount = 0;
			ypo = 0;
			for each (var op:OptionVO in _cureVO.options)
			{
				if (_cureVO.rightOptions.length == 1)
				{
					var skin:radiobtnskin = new radiobtnskin;
					var radiobtn:RadioButton = new RadioButton(skin);
					ui.addChild(radiobtn);
					radiobtn.text = op.content;
					radiobtn.index = op.no;
					radiobtn.x = lengthCount;
					if ((radiobtn.x + radiobtn.comWidth) > 565)
					{
						lineCount++;
						lengthCount = LEFT_PADDING;
					}
					radiobtn.x = lengthCount;
					radiobtn.y = yPosition + lineCount * OPTION_PADDING;
					
					ypo = radiobtn.y;
					
					lengthCount += radiobtn.comWidth;
					optionsArr.push({display: radiobtn, index: op.no});
					radiobtnGroup.addRadioButton(radiobtn);
				}
				else
				{
					var skin2:checkboxskin = new checkboxskin;
					var checkBox:CheckBox = new CheckBox(skin2);
					ui.addChild(checkBox);
					checkBox.text = op.content;
					checkBox.index = op.no;
					checkBox.x = lengthCount;
					if ((checkBox.x + checkBox.comWidth) > 565)
					{
						lineCount++;
						lengthCount = LEFT_PADDING;
					}
					checkBox.x = lengthCount;
					checkBox.y = yPosition + lineCount * OPTION_PADDING;
					
					ypo = checkBox.y;
					
					lengthCount += checkBox.comWidth;
					optionsArr.push( { display: checkBox, index: op.no } );
				}
			}
		}
		
		private function onApply(e:MouseEvent):void 
		{
			if (_cureVO.state != -1) return;
			
			if (checkAnswer())
			{
				_cureVO.state = 1;
			}else{
				_cureVO.state = 0;
			}
			
			if (null != onApplyCall)
			{
				onApplyCall();
			}
		}
		
		private function checkAnswer():Boolean
		{
			if (_cureVO == null) return false;
			
			if (_cureVO.rightOptions.length == 1)
			{
				var opindex:int = radiobtnGroup.SelectIndex;
				if (_cureVO.rightOptions[0] == opindex)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else if(_cureVO.rightOptions.length > 1)
			{
				var arr:Array = new Array;
				for each(var item:Object in optionsArr)
				{
					if ((item.display as CheckBox).selected == true)
					{
						arr.push(item.index as int);
					}
				}
				
				if (arr.length != _cureVO.rightOptions.length) 
					return false;
				
				for each(var op:int in _cureVO.rightOptions)
				{
					if (arr.indexOf(op) == -1)
					 return false;
				}
				
				return true;
			}
			return false;
		}
		
		//供外部调用
		public function showExplain():void
		{
			//TODO 显示解释和配音
			loadmusic(_cureVO.sound);
			var rightAnswer:String = '';
			if (_cureVO.state != 1)
			{
				rightAnswer = "回答错误  正确答案:";
			}
			else
			{
				rightAnswer = "回答正确  正确答案:";
			}
			
			for each(var i:int in _cureVO.rightOptions)
			{
				for each (var op:OptionVO in _cureVO.options) 
				{
					if (op.no == i)
					{
						rightAnswer += (op.content.substr(0, 1));
					}
				}
			}
			answer.text = rightAnswer;
			answer.setTextFormat(answertextFormat);
			
			explain.text = _cureVO.explain;
			explain.setTextFormat(explaintextFormat);
			//explain.y = ypo + 40;
		}
		
		private var position:int = 0;
		private var sound:Sound;
		private var soundChannel:SoundChannel;
		private var plybtn:CheckBox;
		private var buffer:SoundLoaderContext = new SoundLoaderContext(5000) 
		private function loadmusic(path:String):void
		{
			plybtn.selected = false;
			sound = new Sound;
			sound.addEventListener(Event.COMPLETE, completeHandler, false, 0, true);
            sound.addEventListener(Event.ID3, id3Handler, false, 0, true);
            sound.addEventListener(IOErrorEvent.IO_ERROR, ioErrorHandler, false, 0, true);
            sound.addEventListener(ProgressEvent.PROGRESS, progressHandler, false, 0, true);
			var file:File = File.applicationDirectory.resolvePath(ConstID.SOUND_PATH + path);
			sound.load(new URLRequest(file.url),buffer);
			soundChannel = sound.play();
		}
		
		private function onPlayClick(e:MouseEvent):void 
		{
			if (null == soundChannel) return;
			if (plybtn.selected==true)
			{
				position = soundChannel.position;
				soundChannel.stop();
			}
			else
			{
				soundChannel = sound.play(position);
			}
		}
		
		private function completeHandler(event:Event):void {
            trace("completeHandler: " + event);
        }

        private function id3Handler(event:Event):void {
            trace("id3Handler: " + event);
        }

        private function ioErrorHandler(event:Event):void {
            trace("ioErrorHandler: " + event);
        }

        private function progressHandler(event:ProgressEvent):void {
            trace("progressHandler: " + event);
        }

		public function stopPlaySound():void
		{
			if (soundChannel)
			{
				soundChannel.stop();
				sound.close();
			}
		}
	}
}