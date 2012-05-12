package view.ui 
{
	import com.titan.questionUI;
	import flash.display.Sprite;
	
	/**
	 * ...
	 * @author 
	 */
	public class QuestionView extends Sprite 
	{
		private var ui:questionUI;
		//private var ui
		public function QuestionView()
		{
			ui = new questionUI;
			addChild(ui);
		}
	}
}