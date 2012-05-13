package model
{
	import flash.events.Event;
	import flash.filesystem.File;
	import flash.net.URLLoader;
	import flash.net.URLRequest;
	import model.vo.OptionVO;
	import model.vo.QuestionVO;
	import org.puremvc.as3.patterns.proxy.Proxy;
	
	/**
	 * ...
	 * @author ...
	 */
	public class QuestionProxy extends Proxy
	{
		//问题
		public var questions:Array;
		private var iobserver:IQuestionDataObserver;
		public static const NAME:String = "QUESTION_PROXY";
		public function QuestionProxy()
		{
			questions = new Array;
			super(NAME,questions)
		}
		
		public function registerQuestionObserver(filepath:String, obersver:IQuestionDataObserver):void
		{
			iobserver = obersver;
			if (questions.length==0)
			{
				var file:File = File.applicationDirectory.resolvePath(filepath);
				//var file:File = File.documentsDirectory.resolvePath(filepath);
				var urlloader:URLLoader = new URLLoader(new URLRequest(file.url));
				urlloader.addEventListener(Event.COMPLETE, onComplete, false, 0, true);
			}
			else
			{
				iobserver.notifyQuestionObserver(questions);
			}
			
		}
		
		private function onComplete(e:Event):void 
		{
			//trace(e.target.data);
			transData(e.target.data as String);
			if (iobserver)
			{
				iobserver.notifyQuestionObserver(questions);
			}
		}
		
		private function transData(content:String):void
		{
			var xmlData:XML = new XML(content);
			var tempEntity:XMLList = xmlData.descendants('entity') as XMLList;
			questions.length = 0;
			for each(var entity:XML in tempEntity)
			{
				var item:QuestionVO = new QuestionVO;
				var no:String = entity.@no.toString();
				item.id = parseInt(no);
				item.content = entity.question[0];
				item.explain = entity.explain[0];
				item.sound = entity.sound[0];
				item.options = new Array;
				var options:XMLList = entity.descendants("option") as XMLList;
				for each (var op:XML in options) 
				{
					var opvo:OptionVO = new OptionVO;
					opvo.content = op.toString();
					opvo.no = parseInt(op.@no.toString());
					item.options.push(opvo);
				}
				
				item.rightOptions = new Array;
				var rightoptions:XMLList = entity.descendants("right") as XMLList;
				for each (var right:XML in rightoptions) 
				{
					item.rightOptions.push(parseInt(right.toString()));
				}
				questions.push(item);
			}
		}
	
	}

}