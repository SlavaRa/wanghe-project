package controller
{
	import org.puremvc.as3.patterns.command.MacroCommand;
	
	public class StartupCommand extends MacroCommand
	{
		public function StartupCommand()
		{
			super();
			this.addSubCommand( PreViewCommand );
			this.addSubCommand( PreCmdCommand );
			this.addSubCommand( PreModelCommand );
		}
	}
}