package view.ui 
{
	import flash.display.Sprite;
	import com.titan.mainUI;
	import flash.events.MouseEvent;
	/**
	 * whe
	 * @author 
	 */
	public class MainUIView extends Sprite 
	{
		private var mainui:mainUI;
		
		public var onNextClickCall:Function;
		
		public function MainUIView() 
		{
			super();
			init();
		}
		
		public function init():void
		{
			mainui = new mainUI;
			addChild(mainui);
			
			mainui.btnNext.addEventListener(MouseEvent.CLICK, onClick, false, 0, true);
		}
		
		private function onClick(e:MouseEvent):void 
		{
			if (null != onNextClickCall)
			{
				onNextClickCall();
			}
		}
	}
}