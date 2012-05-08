package display.components 
{
	import flash.events.MouseEvent;
	/**
	 * ...
	 * @author ...
	 */
	public class RadioButtonGroup 
	{
		private var arr:Array;//radioButton 数组
		
		private var selectedRadioButton:RadioButton;
		
		public function RadioButtonGroup() 
		{
			arr = new Array;
		}
		
		public function addRadioButton(radiobtn:RadioButton):void
		{
			if ( -1 != arr.indexOf(radiobtn))
				return;
			
			arr.push(radiobtn);
			radiobtn.addEventListener(MouseEvent.CLICK, click, false, 0, true);
		}
		
		public function removeRadioButton(radiobtn:RadioButton):void
		{
			var index:int = arr.indexOf(radiobtn);
			if ( -1 != index)
			{
				radiobtn.removeEventListener(MouseEvent.CLICK, click);
				arr.splice(index,1);
			}
		}
		
		private function click(e:MouseEvent):void 
		{
			selectedRadioButton = e.target as RadioButton;
			for each (var item:RadioButton in arr) 
			{
				if (item == selectedRadioButton)
				{
					item.selected = true;
				}
				else
				{
					item.selected = false;
				}
			}
		}
	}

}