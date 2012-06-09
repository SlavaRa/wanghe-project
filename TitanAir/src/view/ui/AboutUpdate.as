package view.ui 
{
	import com.titan.updateUI;
	import flash.display.Shape;
	import flash.display.Sprite;
	import flash.events.MouseEvent;
	
	/**
	 * 升级 关于界面
	 * @author whe
	 */
	public class AboutUpdate extends Sprite 
	{
		private var ui:updateUI;
		
		public var onUpdateCall:Function;
		
		public function AboutUpdate() 
		{
			ui = new updateUI;
			addChild(ui);
			
			ui.btnUpdate.addEventListener(MouseEvent.CLICK, onBtnUpadteClick);
			
		}
		
		//设置进度条进度
		public function setProgressBar(valueNow:Number,valueTotal:Number):void
		{
			ui.probar.setProgress(valueNow,valueTotal);
		}
		
		
		//升级按钮
		private function onBtnUpadteClick(e:MouseEvent):void 
		{
			if (null != onUpdateCall)
				onUpdateCall();
		}
	}

}