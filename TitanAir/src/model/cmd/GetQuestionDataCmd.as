package model.cmd 
{
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.command.SimpleCommand;
	
	/**
	 * ...
	 * @author ...
	 */
	public class GetQuestionDataCmd extends SimpleCommand 
	{
		public function GetQuestionDataCmd() 
		{
			super();
		}
		
		override public function execute(notification:INotification):void 
		{
			
		}
	}
}