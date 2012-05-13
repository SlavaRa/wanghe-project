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
		
		private var QUES_FOND_SIZE:int = 25;
		private var OPTION_PADDING:int = 40;
		
		private var radiobtnGroup:RadioButtonGroup = new RadioButtonGroup;
		
		public var onApplyCall:Function;
		
		public function QuestionView()
		{
			ui = new questionUI;
			addChild(ui);
			
			question = new TextField();
			question.multiline = true;
			question.x = 139;
			question.y = 92;
			question.width = 920;
			question.height = 200;
			question.selectable = false;
			question.mouseEnabled = false;
			question.multiline = true;
			question.autoSize = TextFieldAutoSize.LEFT;
			ui.addChild(question);
			
			ui.btnApply.addEventListener(MouseEvent.CLICK, onApply, false, 0, true);
			
			optionsArr = new Array;
			
			textFormat.size = QUES_FOND_SIZE;
			textFormat.font = "微软雅黑";
			textFormat.color = 0x000000;
		
			plybtn = new CheckBox(ui.plybtn);
			ui.addChild(plybtn);
			plybtn.addEventListener(MouseEvent.CLICK, onPlayClick, false, 0, true);
			
			sound = new Sound();
			sound.addEventListener(Event.COMPLETE, completeHandler);
            sound.addEventListener(Event.ID3, id3Handler);
            sound.addEventListener(IOErrorEvent.IO_ERROR, ioErrorHandler);
            sound.addEventListener(ProgressEvent.PROGRESS, progressHandler);
		}
		

		
		public function setQuestion(quesVO:QuestionVO):void
		{
			_cureVO = quesVO;
			question.text = quesVO.content;
			question.setTextFormat(textFormat);
			setOptions();
			
			soundChannel = null;
		}
		
		//设置选项
		public function setOptions():void
		{
			optionsArr.length = 0;
			radiobtnGroup.clear();
			var lengthCount:Number = 139;
			var yPosition:Number = question.x + question.numLines * QUES_FOND_SIZE;
			var lineCount:int = 0;
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
					if ((radiobtn.x + radiobtn.comWidth) > stage.stageWidth)
					{
						lineCount++;
						lengthCount = 139;
					}
					radiobtn.x = lengthCount;
					radiobtn.y = yPosition + lineCount * OPTION_PADDING;
					
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
					if ((checkBox.x + checkBox.comWidth) > stage.stageWidth)
					{
						lineCount++;
						lengthCount = 139;
					}
					checkBox.x = lengthCount;
					checkBox.y = yPosition + lineCount * OPTION_PADDING;
					lengthCount += checkBox.comWidth;
					optionsArr.push({display: checkBox, index: op.no});
					
				}
			}
		}
		
		private function onApply(e:MouseEvent):void 
		{
			if (null != onApplyCall)
			{
				onApplyCall();
			}
		}
		
		//供外部调用
		public function showExplain():void
		{
			//TODO 显示解释和配音
			loadmusic(_cureVO.sound);
		}
		
		private var position:int = 0;
		private var sound:Sound;
		private var soundChannel:SoundChannel;
		private var plybtn:CheckBox;
		private var buffer:SoundLoaderContext = new SoundLoaderContext(5000) 
		private function loadmusic(path:String):void
		{
			plybtn.selected = false;
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
            //trace("completeHandler: " + event);
        }

        private function id3Handler(event:Event):void {
            //trace("id3Handler: " + event);
        }

        private function ioErrorHandler(event:Event):void {
            //trace("ioErrorHandler: " + event);
        }

        private function progressHandler(event:ProgressEvent):void {
            //trace("progressHandler: " + event);
        }

	
	}
}