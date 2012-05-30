package
{
	import flash.display.Sprite;
	import flash.display.StageAlign;
	import flash.display.StageScaleMode;
	import flash.events.Event;
	import flash.html.HTMLLoader;
	import flash.net.URLRequest;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	
	[SWF(width="780",height="500")]
	public class WeiboServiceDemo_HTMLLoader extends Sprite
	{
		//申请应用的app key
		private var _appKey:String = "2961195243";
		
		private var _html:HTMLLoader;
		
		public function WeiboServiceDemo_HTMLLoader()
		{
			super();
			this.width = 400;
			this.height = 400;
			init();
		}
		
		private function init():void
		{	
			showLogin();
		}
		
		private function showLogin():void
		{
			var url:String = "https://api.weibo.com/oauth2/authorize";
			url+="?client_id=" + _appKey;
			url += "&response_type=token";
			url += "&display=flash";
			
			_html = new HTMLLoader();
			var urlReq:URLRequest = new URLRequest(url);
			_html.addEventListener(Event.LOCATION_CHANGE, onLocationChange);
			_html.width = stage.stageWidth;
			_html.height = stage.stageHeight;
			_html.load(urlReq); 
			addChild(_html);		
		}
		
		protected function onLocationChange(event:Event):void
		{
			var lc:String = _html.location;
			//授权成功的情况： 
			//https://api.weibo.com/oauth2/connect.html#access_token=2.00fOiXjBDXvUSCfcad38dcb00toA5Q&expires_in=604800&remind_in=60267&uid=1589102821
			//trace(lc);
			var arr:Array = String(lc.split("#")[1]).split("&");
			var access_token:String = "";
			var expires_in:String = "";
			var remind_in:String = "";
			var uid:String = "";
			for (var i:int = 0 ; i < arr.length; i ++)
			{
				var str:String = arr[i];
				if (str.indexOf("access_token=") >= 0) access_token = str.split("=")[1];
				if (str.indexOf("expires_in=") >= 0) expires_in = str.split("=")[1];
				if (str.indexOf("remind_in=") >= 0) remind_in = str.split("=")[1];
				if (str.indexOf("uid=") >= 0) uid = str.split("=")[1];
			}
			
			if(access_token != "")
			{
				//说明登陆成功
				_html.removeEventListener(Event.LOCATION_CHANGE, onLocationChange);
				removeChild(_html);
				
				var t:TextField = new TextField();
				t.autoSize = TextFieldAutoSize.LEFT;
				t.wordWrap = true;
				t.width = stage.stageWidth - 20;
				t.x = 10;
				addChild(t);
				var result:String =  "-- access_token: " + access_token + "\n";
				result += "-- expires_in: " + expires_in + "\n";
				result += "-- remind_in: " + remind_in + "\n";
				result += "-- uid: " + uid;
				t.text = result;
			}
		}
	}
	
}