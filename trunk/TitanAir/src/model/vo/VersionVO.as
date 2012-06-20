package model.vo 
{
	import model.IVersionDataObserver;
	/**
	 * 版本号
	 * @author whw
	 */
	public class VersionVO implements IVersionDataObserver
	{
		/**
		 * 版本号
		 */	
		public var NO:String;
		
		/**
		 * 版本说明
		 */
		public var desc:String;
		
		//完成回调函数
		public var completeCall:Function;
		
		public function VersionVO() 
		{
			
		}	
		
		
		/* INTERFACE model.IVersionDataObserver */
		public function notifyVersionObserver(vo:VersionVO):void 
		{
			if (completeCall!=null)
			{
				completeCall(vo);
			}
		}
	}
}