package model 
{
	import org.puremvc.as3.interfaces.IFacade;
	/**
	 * ...
	 * @author whe
	 */
	public class P 
	{
		
		public function P() 
		{
			throw new Error("静态结构不能构造");
		}
		
		public static var facade:IFacade;
		public static function setFacade(_facade:IFacade):void{
			facade = _facade;
		}
		
		public static function get questionProxy():QuestionProxy
		{
			return QuestionProxy(facade.retrieveProxy(QuestionProxy.NAME));
		}
		
		public static function get versionProxy():VersionProxy
		{
			return VersionProxy(facade.retrieveProxy(VersionProxy.NAME));
		}
	}

}