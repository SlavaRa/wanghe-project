package view.ui 
{
	import com.titan.shareUI;
	import flash.display.Shape;
	import flash.display.Sprite;
	import flash.events.MouseEvent;
	
	/**
	 * ...
	 * @author ...
	 */
	public class ShareView extends Sprite 
	{
		private var bg:Shape;
		
		private var ui:shareUI;
		
		public var onCloseCall:Function;
		public var onShareCall:Function;
		
		private var sw:int = 1024;
		private var sh:int = 600;
		
		
		public function ShareView() 
		{
			bg = new Shape;
			bg = new Shape();
			bg.graphics.beginFill(0x000000, 0.6);
			bg.graphics.drawRect(0, 0, sw, sh);
			addChild(bg);
			
			
			ui = new shareUI;
			ui.shareText.multiline = true;
			ui.shareText.wordWrap = true;
			
			addChild(ui);
			ui.btnShare.addEventListener(MouseEvent.CLICK, onShre, false, 0, true);
			ui.btnClose.addEventListener(MouseEvent.CLICK, onClose, false, 0, true);
		}
		
		private function onClose(e:MouseEvent):void 
		{
			if (onCloseCall!=null)
			{
				onCloseCall();
			}
		}
		
		private function onShre(e:MouseEvent):void 
		{
			if (onShareCall!=null)
			{
				onShareCall();
			}
		}
		
		public function setText(txt:String):void
		{
			ui.shareText.text = txt;
		}
		
		public function get ShareText():String
		{
			return ui.shareText.text;
		}
		
		public function setSize(w:int,h:int):void
		{
			sw = w;
			sh = h;
			
			this.bg.width = sw;
			this.bg.height = sh;
			
			ui.x = (sw - ui.width) / 2;
			ui.y = (sh - ui.height) / 2;
		}
	}
}