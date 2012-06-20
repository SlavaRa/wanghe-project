package model 
{
	import model.vo.VersionVO;
	/**
	 * ...
	 * @author whe
	 */
	public interface IVersionDataObserver 
	{
		function notifyVersionObserver(vo:VersionVO):void	
	}

}