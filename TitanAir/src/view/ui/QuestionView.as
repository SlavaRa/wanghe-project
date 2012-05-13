package view.ui 
{
	import com.titan.questionUI;
	import com.titan.radiobtnskin;
	import display.components.RadioButton;
	import flash.display.Sprite;
	import flash.events.MouseEvent;
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
		
		private var QUES_FOND_SIZE:int = 25;
		private var OPTION_PADDING:int = 40;
		
		private var textFormat:TextFormat = new TextFormat;
		
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
			
			optionsArr = new Array;
			
			textFormat.size = QUES_FOND_SIZE;
			textFormat.font = "华文细黑";
			textFormat.color = 0x00FFFF;
			
		}
		
		public function setQuestion(quesVO:QuestionVO):void
		{
			_cureVO = quesVO;
			question.text = quesVO.content;
			question.setTextFormat(textFormat);
			

			setOptions();
		}
		
		//设置选项
		public function setOptions():void
		{
			optionsArr.length = 0;
			var index:int = 0;
			var lengthCount:Number = 139;
			var yPosition:Number = question.x + question.numLines * QUES_FOND_SIZE;
			var lineCount:int = 0;
			for each(var op:OptionVO in _cureVO.options)
			{
				if (_cureVO.rightOptions.length == 1)
				{
					var skin:radiobtnskin = new radiobtnskin;
					var radiobtn:RadioButton = new RadioButton(skin);
					ui.addChild(radiobtn);
					radiobtn.text = op.content;
					radiobtn.index = op.no;
					radiobtn.x = lengthCount;
					if ((radiobtn.x+radiobtn.comWidth)>stage.stageWidth)
					{
						lineCount++;
						lengthCount = 139;
					}
					radiobtn.x = lengthCount;
					radiobtn.y = yPosition + lineCount * OPTION_PADDING;
					
					lengthCount += radiobtn.comWidth;
					radiobtn.addEventListener(MouseEvent.CLICK, onRadioBtnClick, false, 0, true);
					optionsArr.push( { display:radiobtn, index:op.no } );
				}
				else
				{
					
				}
				
				index++;

			}
		}
		
		private function onRadioBtnClick(e:MouseEvent):void 
		{
			
		}
	}
}