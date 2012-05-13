package display.components
{
	import display.container.UISprite;
	import flash.display.DisplayObject;
	import flash.display.DisplayObjectContainer;
	import flash.display.MovieClip;
	import flash.events.Event;
	
	/**
	 * ...
	 * @author ...
	 */
	public class AbstractComponent extends UISprite
	{
		public var mutex:Boolean = false;
		public var canRemove:Boolean = true;
		public var removeAfterHide:Boolean = true;
		protected var mySkin:DisplayObjectContainer;
		protected var myParent:DisplayObjectContainer;
		protected var skinWidth:int;
		protected var skinHeight:int;
		
		public function AbstractComponent(skin:MovieClip)
		{
			super();
			if (skin != null)
			{
				mySkin = skin;
				// 修改为皮肤的坐标
				x = mySkin.x;
				y = mySkin.y;
				// 重置皮肤的坐标
				mySkin.x = 0;
				mySkin.y = 0;
				skinWidth = mySkin.width;
				skinHeight = mySkin.height;
				// 加入皮肤为子对象
				addChild(mySkin);
			}
			else
			{
				mySkin = this;
			}
		}
		
		/**
		 * 皮肤 
		 * @return 
		 * 
		 */
		public function get skin():DisplayObjectContainer
		{
			return mySkin;
		}
		
		/**
		 * 父显示对象 
		 * @param host
		 * 
		 */
		public function set hostContainer(host:DisplayObjectContainer):void
		{
			myParent = host;
		}
		
		/**
		 * 设置坐标 
		 * @param x
		 * @param y
		 * 
		 */
		public function setPostion(x:int,y:int):void
		{
			this.x = x;
			this.y = y;
		}
		
		/**
		 * 从显示列表删除 
		 * @param event
		 * 
		 */
		public function hide(event:Boolean=true):void
		{
			if(removeAfterHide && parent!=null)
			{
				parent.removeChild(this);
			}
		}
		
		/**
		 * 添加到显示列表 
		 * @param host
		 * @param x
		 * @param y
		 * 
		 */
		public function show(host:DisplayObjectContainer=null,px:int=0,py:int=0):void
		{
			if(host==null && myParent==null && parent==null)
			{
				throw new Error("没有可用的父显示对象");
			}
			if(parent==null || parent!=host && visible )
			{
				if(host!=null)
				{
					myParent = host;
				}
				myParent.addChild(this);
				if(px!=0)
				{
					x = px;
				}
				if(py!=0)
				{
					y = py;
				}
			}
			else
			{
				alpha = 1;
				visible = true;
			}
		}
		
		override protected function addToStage(event:Event):void
		{
			super.addToStage(event);
			myParent = myParent || parent;
		}
		
		public function isInStage():Boolean
		{
			var test:DisplayObject = this;
			while( test )
			{
				if( test.visible && test.stage )
				{
					test = test.parent;	
				}
				else
				{
					return false;
				}
			}
			return true;
		}
	
	}

}