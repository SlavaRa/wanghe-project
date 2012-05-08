package display.container
{
	import flash.display.Sprite;
	import flash.events.Event;
	
	/**
	 * ...
	 * @author ...
	 */
	public class UISprite extends Sprite
	{
		private var _createChildrenCalled:Boolean;
		private var _removeChildrenCalled:Boolean;
		private var _opened:Boolean = false; //是否开启
		
		public function UISprite()
		{
			super();
			addEventListener(Event.ADDED_TO_STAGE, onAddedToStageHandler, false, 0, true);
		}
		
		private function onAddedToStageHandler(event:Event):void
		{
			if (!_createChildrenCalled)
			{
				onCreateChildren();
			}
			addToStage(event);
		}
		
		private function onRemoveFromStageHandler(event:Event):void
		{
			removeFromStage(event);
			if (!_removeChildrenCalled)
			{
				onRemoveChildren();
			}
		}
		
		/**
		 * 实例已经被添加到舞台上
		 * @param event
		 *
		 */
		protected function addToStage(event:Event):void
		{
			removeEventListener(Event.ADDED_TO_STAGE, onAddedToStageHandler);
			addEventListener(Event.REMOVED_FROM_STAGE, onRemoveFromStageHandler, false, 0, true);
			stage.addEventListener(Event.RESIZE, resetXY);
			_opened = true;
		}
		
		/**
		 * 实例即将被从舞台上移除
		 * @param event
		 *
		 */
		protected function removeFromStage(event:Event):void
		{
			stage.removeEventListener(Event.RESIZE, resetXY);
			removeEventListener(Event.REMOVED_FROM_STAGE, onRemoveFromStageHandler);
			addEventListener(Event.ADDED_TO_STAGE, onAddedToStageHandler, false, 0, true);
			_opened = false;
		}
		
		/**
		 * 创建内部组件
		 *
		 */
		protected function onCreateChildren():void
		{
			_createChildrenCalled = true;
			_removeChildrenCalled = false;
		}
		
		/**
		 * 移除内部组件
		 *
		 */
		protected function onRemoveChildren():void
		{
			_createChildrenCalled = false;
			_removeChildrenCalled = true;
		}
		
		/**
		 * 刷新坐标
		 *
		 */
		public function resetXY(event:Event = null):void
		{
		
		}
		
		/***
		 * 存在父子关联界面时定位
		 * */
		public function resetPosition(panel:UISprite):void
		{
		
		}
		
		/**
		 * 是否打开
		 * @return
		 *
		 */
		public function get opened():Boolean
		{
			return _opened;
		}
	
	}

}