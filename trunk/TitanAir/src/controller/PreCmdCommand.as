package controller
{
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.command.SimpleCommand;
	
	public class PreCmdCommand extends SimpleCommand
	{
		public function PreCmdCommand()
		{
			super();
		}
		override public function execute( notification:INotification ) : void
		{
           
		}
	}
}