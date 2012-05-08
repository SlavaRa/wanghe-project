package view.ui 
{
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Loader;
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.events.MouseEvent;
	import flash.events.TimerEvent;
	import flash.filesystem.File;
	import flash.geom.Point;
	import flash.geom.Rectangle;
	import flash.net.URLRequest;
	import flash.utils.Timer;
	
	/**
	 * ...
	 * @author 
	 */
	public class GameView extends Sprite 
	{
		// space between pieces and offset
		public static const pieceSpace:Number = 1;
		public static const horizOffset:Number = 50;
		public static const vertOffset:Number = 50;
		
		// number of pieces
		public static const numPiecesHoriz:int = 4;
		public static const numPiecesVert:int = 4;
		
		// random shuffle steps 打乱步数
		public static const numShuffle:int = 1;
		
		// animation steps and time
		public static const slideSteps:int = 10;
		public static const slideTime:int = 250;
		
		// size of pieces
		private var pieceWidth:Number;
		private var pieceHeight:Number;

		// game pieces
		private var puzzleObjects:Array;
		
		// tracking moves
		private var blankPoint:Point;
		private var slidingPiece:Object;
		private var slideDirection:Point;
		private var slideAnimation:Timer;
		
		private var loader:Loader;
		
		public var onPuzzleComplete:Function;
		
		public function GameView(){
			blankPoint = new Point(numPiecesHoriz - 1, numPiecesVert - 1);
			puzzleObjects = new Array();
		}
		
		
		public function setImage(filename:String):void
		{
			loadBitmap(filename);
		}
		
		public function loadBitmap(bitmapFile:String):void {
			var file:File = File.applicationDirectory.resolvePath("air_app_assets/"+bitmapFile);
			loader = new Loader();
			loader.contentLoaderInfo.addEventListener(Event.COMPLETE, loadComplete, false, 0, true);
			loader.load(new URLRequest(file.url));
		}
		
		private function loadComplete(e:Event):void 
		{
			// create new image to hold loaded bitmap
			var image:Bitmap = Bitmap(e.target.content);
			pieceWidth = image.width/numPiecesHoriz;
			pieceHeight = image.height/numPiecesVert;
			
			// cut into puzzle pieces
			makePuzzlePieces(image.bitmapData);
			
			// shuffle them 打乱丫的
			//shufflePuzzlePieces();
		}
		
		public function makePuzzlePieces(bitmapData:BitmapData):void {
			
			//清理
			clearPuzzle();
			
			for(var x:uint=0;x<numPiecesHoriz;x++) {
				for (var y:uint=0;y<numPiecesVert;y++) {
					// skip blank spot
					if (blankPoint.equals(new Point(x,y))) continue;
					
					// create new puzzle piece bitmap and sprite
					var newPuzzlePieceBitmap:Bitmap = new Bitmap(new BitmapData(pieceWidth,pieceHeight));
					newPuzzlePieceBitmap.bitmapData.copyPixels(bitmapData,new Rectangle(x*pieceWidth,y*pieceHeight,pieceWidth,pieceHeight),new Point(0,0));
					var newPuzzlePiece:Sprite = new Sprite();
					newPuzzlePiece.name = x.toString() + y.toString();
					newPuzzlePiece.addChild(newPuzzlePieceBitmap);
					addChild(newPuzzlePiece);
					
					// set location
					newPuzzlePiece.x = x*(pieceWidth+pieceSpace) + horizOffset;
					newPuzzlePiece.y = y*(pieceHeight+pieceSpace) + vertOffset;
					
					// create object to store in array
					var newPuzzleObject:Object = new Object();
					newPuzzleObject.currentLoc = new Point(x,y);
					newPuzzleObject.homeLoc = new Point(x,y);
					newPuzzleObject.piece = newPuzzlePiece;
					newPuzzlePiece.addEventListener(MouseEvent.CLICK,clickPuzzlePiece);
					puzzleObjects.push(newPuzzleObject);
				}
			}
		}
		
		public function shufflePuzzlePieces():void {
			for(var i:int=0;i<numShuffle;i++) {
				shuffleRandom();
			}
        }
		
		// random move
		public function shuffleRandom():void{
			// loop to find valid moves
			var validPuzzleObjects:Array = new Array();
			for(var i:uint=0;i<puzzleObjects.length;i++) {
				if (validMove(puzzleObjects[i]) != "none") {
					validPuzzleObjects.push(puzzleObjects[i]);
				}
			}
			// pick a random move
			var pick:uint = Math.floor(Math.random()*validPuzzleObjects.length);
			movePiece(validPuzzleObjects[pick],false);
		}
		
		public function validMove(puzzleObject:Object): String {
			// is the blank spot above
			if ((puzzleObject.currentLoc.x == blankPoint.x) &&
				(puzzleObject.currentLoc.y == blankPoint.y+1)) {
				return "up";
			}
			// is the blank spot below
			if ((puzzleObject.currentLoc.x == blankPoint.x) &&
				(puzzleObject.currentLoc.y == blankPoint.y-1)) {
				return "down";
			}
			// is the blank to the left
			if ((puzzleObject.currentLoc.y == blankPoint.y) &&
				(puzzleObject.currentLoc.x == blankPoint.x+1)) {
				return "left";
			}
			// is the blank to the right
			if ((puzzleObject.currentLoc.y == blankPoint.y) &&
				(puzzleObject.currentLoc.x == blankPoint.x-1)) {
				return "right";
			}
			// no valid moves
			return "none";
		}
		
		public function clickPuzzlePiece(event:MouseEvent):void {
			// find piece clicked and move it
			//TODO 判断一下 是否激活
			
			for(var i:int=0;i<puzzleObjects.length;i++) {
				if (puzzleObjects[i].piece == event.currentTarget) {
					movePiece(puzzleObjects[i],true);
					break;
				}
			}
		}
		
		public function movePiece(puzzleObject:Object, slideEffect:Boolean):void {
			// get direction of blank space
			switch (validMove(puzzleObject)) {
				case "up":
					movePieceInDirection(puzzleObject,0,-1,slideEffect);
					break;
				case "down":
					movePieceInDirection(puzzleObject,0,1,slideEffect);
					break;
				case "left":
					movePieceInDirection(puzzleObject,-1,0,slideEffect);
					break;
				case "right":
					movePieceInDirection(puzzleObject,1,0,slideEffect);
					break;
			}
		}
		
		public function movePieceInDirection(puzzleObject:Object, dx:int ,dy:int, slideEffect:Boolean):void {
			puzzleObject.currentLoc.x += dx;
			puzzleObject.currentLoc.y += dy;
			blankPoint.x -= dx;
			blankPoint.y -= dy;
			
			// animate or not
			if (slideEffect) {
				// start animation
				startSlide(puzzleObject,dx*(pieceWidth+pieceSpace),dy*(pieceHeight+pieceSpace));
			} else {
				// no animation, just move
				puzzleObject.piece.x = puzzleObject.currentLoc.x*(pieceWidth+pieceSpace) + horizOffset;
				puzzleObject.piece.y = puzzleObject.currentLoc.y*(pieceHeight+pieceSpace) + vertOffset;
			}
		}
		
		public function startSlide(puzzleObject:Object, dx:Number, dy:Number):void {
			if (slideAnimation != null) slideDone(null);
			slidingPiece = puzzleObject;
			slideDirection = new Point(dx,dy);
			slideAnimation = new Timer(slideTime/slideSteps,slideSteps);
			slideAnimation.addEventListener(TimerEvent.TIMER,slidePiece);
			slideAnimation.addEventListener(TimerEvent.TIMER_COMPLETE,slideDone);
			slideAnimation.start();
		}
		
		// move one step in slide
		public function slidePiece(event:Event):void {
			slidingPiece.piece.x += slideDirection.x/slideSteps;
			slidingPiece.piece.y += slideDirection.y/slideSteps;
		}
		
		// complete slide
		public function slideDone(event:Event):void{
			slidingPiece.piece.x = slidingPiece.currentLoc.x*(pieceWidth+pieceSpace) + horizOffset;
			slidingPiece.piece.y = slidingPiece.currentLoc.y*(pieceHeight+pieceSpace) + vertOffset;
			slideAnimation.stop();
			slideAnimation = null;
			
			// check to see if puzzle is complete now
			if (puzzleComplete()) {
				clearPuzzle();
				//gotoAndStop("gameover");
			}
		}
		
		// check to see if all pieces are in place
		public function puzzleComplete():Boolean {
			for(var i:int=0;i<puzzleObjects.length;i++) {
				if (!puzzleObjects[i].currentLoc.equals(puzzleObjects[i].homeLoc)) {
					return false;
				}
			}
			if (onPuzzleComplete != null)
			{
				onPuzzleComplete();
			}
			return true;
		}
		
		// remove all puzzle pieces
		public function clearPuzzle() :void{
			for (var i:int = 0; i < puzzleObjects.length;i++) {
				puzzleObjects[i].piece.removeEventListener(MouseEvent.CLICK,clickPuzzlePiece);
				removeChild(puzzleObjects[i].piece);
			}
			puzzleObjects.length = 0;
		}
		
	}
}