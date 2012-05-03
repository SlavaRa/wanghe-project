package view.ui 
{
	import flash.display.Sprite;
	import com.titan.mainUI;
	/**
	 * whe
	 * @author 
	 */
	public class MainUIView extends Sprite 
	{
		private var mainui:mainUI;
		public function MainUIView() 
		{
			super();
			init();
		}
		
		public function init():void
		{
			mainui = new mainUI;
			addChild(mainui);
		}
	}
}