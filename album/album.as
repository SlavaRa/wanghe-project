package
{
	
	import com.album.AlbumEntity;
	import com.album.AlbumWord;
	import com.album.ImgBox;
	import com.greensock.easing.Strong;
	import com.greensock.events.LoaderEvent;
	import com.greensock.loading.core.DisplayObjectLoader;
	import com.greensock.TweenLite;
	import flash.display.Bitmap;
	import flash.display.DisplayObject;
	import flash.display.Loader;
	import flash.display.LoaderInfo;
	import flash.display.MovieClip;
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.events.IOErrorEvent;
	import flash.events.MouseEvent;
	import flash.net.URLLoader;
	import flash.net.URLRequest;
	
	public class album extends MovieClip
	{
		private var xmlFileName:String = "data.xml";
		
		private var dataArr:Array = [];
		
		private var loader:URLLoader;
		
		private var word:AlbumWord;
		
		private var _imgContainer:Sprite;
		
		private var _curIndex:int = 0;
		
		private static const SHOW_ITEM_NUMBER:int = 5;
		
		private var boxArr:Array = [];//BOX的数组
		
		public function album()
		{
			super();
			// constructor code
			_imgContainer = new Sprite();
			_imgContainer.graphics.clear();
			_imgContainer.graphics.beginFill(0x00FF00, 0);
			_imgContainer.graphics.drawRect(0, 0, 10, 10);
			_imgContainer.graphics.endFill();
			
			_imgContainer.x = 150;
			_imgContainer.y = 900;
			_imgContainer.mouseChildren = true;
			_imgContainer.mouseEnabled = true;
			addChild(_imgContainer);
			
			word = this["w"] as AlbumWord;
			word.addEventListener(AlbumWord.NEXT_CLICK, onNextClick);
			word.addEventListener(AlbumWord.PREVIOUS_CLICK, onPreClick);
			
			loadXml();
		}
		

		

		
		private function loadXml()
		{
			loader = new URLLoader();
			var url:URLRequest = new URLRequest(xmlFileName);
			loader.addEventListener(Event.COMPLETE, onComplete);
			loader.addEventListener(IOErrorEvent.IO_ERROR, onError);
			loader.load(url);
		}
		
		private function onError(e:IOErrorEvent):void
		{
			trace("IO错误");
		}
		
		private function onComplete(e:Event):void
		{
			var str:String = (e.target as URLLoader).data as String;
			var xml:XML = new XML(str);
			processXML(xml);
		}
		
		private function processXML(xml:XML):void
		{
			var list:XMLList = xml.descendants("entity") as XMLList;
			dataArr.length = 0;
			var entiity:AlbumEntity;
			var index:int = 0;
			for each (var node:XML in list)
			{
				entiity = new AlbumEntity();
				entiity.id = parseInt(node.id);
				entiity.title = node.title.toString();
				entiity.content = node.content.toString();
				entiity.img = node.img.toString();
				
				dataArr.push(entiity);
				index++;
			}
			dataArr.sortOn("id", Array.NUMERIC);
			
			loadImages();
		}
		
		/**
		 * 下载图片
		 * @param	arr
		 */
		private function loadImages()
		{
			loadNext();
		}
		
		/**
		 * 单线程下载
		 * @param	arr
		 */
		private function loadNext():void
		{
			var url:String;
			for each (var entity:AlbumEntity in dataArr)
			{
				if (entity.bitmap == null)
				{
					var load:Loader = new Loader();
					var urlreq:URLRequest = new URLRequest(entity.img);
					load.contentLoaderInfo.addEventListener(Event.COMPLETE, onImgComplete);
					load.load(urlreq);
					return;
				}
			}
			
			//显示排列
			trace("loadNext");
			showAllImg();
		}
		
		private function onImgComplete(e:Event):void
		{
			var bitmap:Bitmap = Bitmap((e.target as LoaderInfo).content);
			for each (var entity:AlbumEntity in dataArr)
			{
				var url:String = (e.target as LoaderInfo).url;
				url = url.substr(url.length - entity.img.length, entity.img.length);
				if (entity.img == url)
				{
					entity.bitmap = bitmap;
					break;
				}
			}
			loadNext();
		}
		
		//排列显示各种图片
		private function showAllImg():void
		{
			var index:int = 0;
			for each (var entity:AlbumEntity in dataArr)
			{
				var imgBox:ImgBox = new ImgBox();
				imgBox.entity = entity;
				imgBox.addEventListener(MouseEvent.CLICK, onBoxClick);
				_imgContainer.addChildAt(imgBox, 0);
				boxArr.push(imgBox);
				imgBox.scaleX = 1 - index * 0.1;
				imgBox.scaleY = 1 - index * 0.1;
				imgBox.x = 200 - index * 80;
				imgBox.index = index;
				index++;
			}
			
			setEntityData(dataArr[0]);
		}
		
		/**
		 *
		 * @param	e
		 */
		private function onBoxClick(e:MouseEvent):void
		{
			//点击BOX
			var box:ImgBox = e.target as ImgBox;
			var step:int = box.index;
			
			//补全 imgBox
			var leng:int = step;
			if (step == 0) return;
			
			setEntityData(box.entity);
			
			
			for (var j:int = 0 ; j < box.index ; j++) 
			{
				var imgBox:ImgBox = new ImgBox();
				var tempIndex:int = _curIndex + j;
				if (tempIndex >= dataArr.length)
				{
					tempIndex -=dataArr.length
				}
				imgBox.entity = dataArr[tempIndex] as AlbumEntity;
				imgBox.addEventListener(MouseEvent.CLICK, onBoxClick);
				_imgContainer.addChildAt(imgBox, 0);
				
				imgBox.scaleX = 1 - boxArr.length * 0.1;
				imgBox.scaleY = 1 - boxArr.length* 0.1;
				imgBox.x = 200 - boxArr.length * 80;
				imgBox.index = boxArr.length;
				boxArr.push(imgBox);
			}
			
			//移动
			for each (var imgbox:ImgBox in boxArr) 
			{
				moveItem(imgbox, step);
			}
			_curIndex = box.entity.id;
			
			boxArr = boxArr.slice(step, boxArr.length);
			
			var l:int = boxArr.length;
			for (var i:int = 0; i < l; i++) 
			{
				(boxArr[i] as ImgBox).index = i;
			}
		}
		
		private function onPreClick(e:Event):void 
		{

		}
		
		private function onNextClick(e:Event):void 
		{
			
		}
		
		/**
		 * 移动imgBox
		 * @param	disObj
		 * @param	step
		 * Strong.easeOut
		 */
		private function moveItem(box:ImgBox,step:int)
		{
			var index:int = box.index - step;
			var alpha:Number = 1;
			var time:Number = 0;
			
			var realStep:int = 0;//实际步数
			var destX:int = 0;
			var scaleY:Number = 0;
			
			if (index < 0)
			{
				index = 0;
				alpha = 0;
				realStep = box.index;
			}
			else
			{
				realStep = step;
			}
			
			//box.index = box.index - realStep;
			
			time = realStep * 0.5;
			destX = 200 -  index * 80;
			scaleY = 1 - index * 0.1;
			
			TweenLite.to(box, time, { scaleY:scaleY, x:destX, alpha:alpha, ease:Strong.easeOut , onComplete:onTweenComplete, onCompleteParams:[box] } );
			
			//if (box.index < 0)
			//{
				//box.index += dataArr.length;
			//}
		}
		
		/**
		 * 
		 * @param	box
		 */
		private function onTweenComplete(box:ImgBox):void
		{
			if (box.alpha == 0)
			{
				box.parent.removeChild(box);
				//var len:int = boxArr.length;
				//for (var i:int = 0; i < len; i++) 
				//{
					//if ((boxArr[i] as ImgBox) == box)
					//{
						//boxArr.splice(i, 1);
						//break;
					//}
				//}
			}
			
		}
		
		/**
		 * 设置标题 内容
		 * @param	entity
		 */
		private function setEntityData(entity:AlbumEntity):void
		{
			word.setTitle(entity.title);
			word.setContent(entity.content);
		}
	
	}

}
