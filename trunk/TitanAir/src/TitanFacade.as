package  
{
	import controller.StartupCommand;
	import model.P;
	import org.puremvc.as3.patterns.facade.Facade;
	
	/**
	 * ...
	 * @author whe
	 */
	public class TitanFacade extends Facade 
	{
		public static const STARTUP:String = "TITAN_FACADE";
		
		public function TitanFacade() 
		{
			super();
		}
		
		public static function getInstance():TitanFacade
		{
			if ( instance == null ) 
				instance = new TitanFacade();
			return TitanFacade(instance);
		}
		
		public function startup(app:Titan):void
		{
			sendNotification(STARTUP, app);
		}
		
		override protected function initializeController():void 
		{
			super.initializeController();
			P.setFacade(this);
			registerCommand(STARTUP, StartupCommand);
		}
	}
}