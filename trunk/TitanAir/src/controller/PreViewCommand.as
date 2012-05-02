package controller
{
	import org.puremvc.as3.interfaces.INotification;
	import org.puremvc.as3.patterns.command.SimpleCommand;
	import view.TitanMediator;
	
	public class PreViewCommand extends SimpleCommand
	{
		public function PreViewCommand()
		{
			super();
		}
		
		override public function execute(notification:INotification):void
		{
			var app:Titan = Titan(notification.getBody());
			facade.registerMediator(new TitanMediator(app));			
		}
	}
}