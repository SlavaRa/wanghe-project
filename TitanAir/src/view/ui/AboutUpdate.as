package view.ui 
{
	import com.titan.updateUI;
	import controller.ConstID;
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
		public var onReutrnCall:Function;
		
		public function AboutUpdate() 
		{
			ui = new updateUI;
			addChild(ui);
			
			ui.btnUpdate.addEventListener(MouseEvent.CLICK, onBtnUpadteClick);
			ui.btnReturn.addEventListener(MouseEvent.CLICK, onReturnClick);
		}
		
		private function onReturnClick(e:MouseEvent):void 
		{
			 if (onReutrnCall != null)
				onReutrnCall();
		}
		
		//设置进度条进度
		public function setProgressBar(valueNow:Number,valueTotal:Number):void
		{
			var w:Number = (valueNow / valueTotal) * 600;
			ui.progress.width = w;
		}
		
		
		//升级按钮
		private function onBtnUpadteClick(e:MouseEvent):void 
		{
			if (null != onUpdateCall)
				onUpdateCall();
		}
		
		public function set txt(str:String):void
		{
			ui.txt.text = str;
		}
	}

}