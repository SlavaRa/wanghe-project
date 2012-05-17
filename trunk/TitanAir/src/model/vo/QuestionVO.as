package model.vo 
{
	/**
	 * ...
	 * @author ...
	 */
	public class QuestionVO 
	{
		public var id:int;
		public var content:String;
		public var options:Array;
		public var rightOptions:Array;
		public var explain:String;
		public var explainimg:String;
		
		public var sound:String;
		//-1未回答
		//0错误
		//1正确
		public var state:int = -1;//
		public function QuestionVO() 
		{	
		}
	}

}