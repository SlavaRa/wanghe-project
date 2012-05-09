package display.util
{
	import flash.display.DisplayObject;
	import flash.filters.ColorMatrixFilter;

	/**
	 * ...
	 * @author
	 */
	public class GrayFilter
	{

		public function GrayFilter()
		{

		}

		public static function applyGray(child:DisplayObject):void
		{
			var matrix:Array = new Array();
			matrix = matrix.concat([0.3086, 0.6094, 0.0820, 0, 0]); // red
			matrix = matrix.concat([0.3086, 0.6094, 0.0820, 0, 0]); // green
			matrix = matrix.concat([0.3086, 0.6094, 0.0820, 0, 0]); // blue
			matrix = matrix.concat([0, 0, 0, 1, 0]); // alpha

			applyFilter(child, matrix);

		}

		public static function applyFilter(child:DisplayObject, matrix:Array):void
		{
			var filter:ColorMatrixFilter = new ColorMatrixFilter(matrix);
			var filters:Array = new Array();
			filters.push(filter);
			child.filters = filters;
		}
	}

}