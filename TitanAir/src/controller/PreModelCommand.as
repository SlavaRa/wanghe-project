package controller
{
	import model.QuestionProxy;
	import model.VersionProxy;
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.command.SimpleCommand;
	
	public class PreModelCommand extends SimpleCommand
	{
		public function PreModelCommand()
		{
			super();
		}
		override public function execute( notification:INotification ) : void
		{
			facade.registerProxy(new QuestionProxy());
			facade.registerProxy(new VersionProxy());
		}
	}
}