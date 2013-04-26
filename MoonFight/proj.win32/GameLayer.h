#pragma once
#include "cocos2d.h"
#include "Ship.h"
#include "Bullet.h"

using namespace cocos2d;

#define STATE_PLAYING 0
#define STATE_GAMEOVER 1
#define MAX_CONTAINT_WIDTH 40
#define MAX_CONTAINT_HEIGHT 40


class GameLayer:public CCLayer
{
public:
	int time;
	Ship* ship;

	int game_status;

	CCSprite* backSky;
	int backSkyHeight;
	CCSprite* backSkyRe;

	CCTMXTiledMap* backTileMap;
	int backTileMapHeight;
	CCTMXTiledMap* backTileMapRe;

	int _tempScore;
	BOOL _isBackSkyReload;
	BOOL _isBackTileReload;
	
	CCLabelTTF* lbScore;
	CCSize winSize;//

	CCRect screenRect;
	
	bool init();

	CCSpriteBatchNode* texTransparentBatch;
	CCSpriteBatchNode* texOpaqueBatch;

	void update(float dt);

	bool ccTouchBegan(CCTouch *pTouch, CCEvent *pEvent);
	void ccTouchMoved(CCTouch *pTouch, CCEvent *pEvent);
	void ccTouchEnded(CCTouch *pTouch, CCEvent *pEvent);

	void addBullet(Bullet* b,int zOrder,int mode);




	void registerWithTouchDispatcher(void);

	static GameLayer*  getInstance();

	void removeInactiveUnit(float dt);

	GameLayer(void);
	~GameLayer(void);

	CREATE_FUNC(GameLayer);



private:
	void iniBackGround();
	void moveBackGround(float dt);

	void processEvent(CCTouch* touches);

	static GameLayer* SHARED_GAME_LAYER;

};




