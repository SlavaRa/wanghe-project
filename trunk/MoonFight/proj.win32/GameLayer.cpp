#pragma once
#include "GameLayer.h"
#include "resource.h"
#include "Ship.h"
#include "gameConfig.h"


GameLayer::GameLayer( void )
{


}

bool GameLayer::init()
{
    SHARED_GAME_LAYER = this;

    game_status = GameState::PLAY;

    CCTexture2D* texTransparent = CCTextureCache::sharedTextureCache()->addImage(s_textureTransparentPack);
    this->texTransparentBatch = CCSpriteBatchNode::createWithTexture(texTransparent);
    this->addChild(texTransparentBatch);

    this->ship = new Ship();
    this->texTransparentBatch->addChild(ship,this->ship->zOrder,UNIT_TAG::PLAYER_TAG);



    this->iniBackGround();



    this->setTouchEnabled(true);

    

    return true;
}

GameLayer::~GameLayer( void )
{

}

//初始化背景
void GameLayer::iniBackGround()
{
    this->_isBackSkyReload = FALSE;
    this->_isBackTileReload = FALSE;

    //背景的天空 蓝不拉几的那个
    this->backSky = CCSprite::createWithSpriteFrameName("bg01.png");
    this->backSky->setAnchorPoint(ccp(0, 0));
    this->backSkyHeight = this->backSky->getContentSize().height;
    this->addChild(this->backSky, -10);



    //背景的大船们

    this->backTileMap = CCTMXTiledMap::create(s_level01);
    this->addChild(this->backTileMap,-9);
    this->backTileMapHeight = this->backTileMap->getContentSize().height;

    this->backSkyHeight -= 48;
    this->backTileMapHeight -= 200;

    this->backSky->runAction(CCMoveBy::create(3.0f, ccp(0, -48)));
    this->backTileMap->runAction(CCMoveBy::create(3.0f, ccp(0, -200)));


    this->winSize = CCDirector::sharedDirector()->getWinSize();


    this->schedule(schedule_selector(GameLayer::moveBackGround), 3);
}
//移动背景
void GameLayer::moveBackGround(float dt)
{
    this->backSky->runAction(CCMoveBy::create(3.0f, ccp(0, -48)));
    this->backTileMap->runAction(CCMoveBy::create(3.0f,ccp(0,-200)));
    this->backSkyHeight -= 48;
    this->backTileMapHeight -= 200;


    if (this->backSkyHeight <= winSize.height)
    {
        if (!this->_isBackSkyReload)
        {
            this->backSkyRe = CCSprite::createWithSpriteFrameName("bg01.png");
            this->backSkyRe->setAnchorPoint(ccp(0, 0));
            this->addChild(this->backSkyRe, -10);
            this->backSkyRe->setPosition(ccp(0, winSize.height));
            this->_isBackSkyReload = true;
        }
        this->backSkyRe->runAction(CCMoveBy::create(3.0f, ccp(0, -48)));
    }
    if (this->backSkyHeight <= 0)
    {
        this->backSkyHeight = this->backSky->getContentSize().height;
        this->removeChild(this->backSky, true);
        this->backSky = this->backSkyRe;
        this->backSkyRe = nullptr;
        this->_isBackSkyReload = false;

    }

    if (this->backTileMapHeight <= winSize.height)
    {
        if (!this->_isBackTileReload)
        {
            this->backTileMapRe = CCTMXTiledMap::create(s_level01);
            this->addChild(this->backTileMapRe, -9);
            this->backTileMapRe->setPosition(0, winSize.height);

            this->_isBackTileReload = TRUE;

        }
        this->backTileMapRe->runAction(CCMoveBy::create(3.0f, ccp(0, -200)));

    }

    if (this->backTileMapHeight <= 0)
    {
        this->backTileMapHeight = this->backTileMapRe->getMapSize().height * this->backTileMapRe->getTileSize().height;

        this->removeChild(this->backTileMap, true);

        this->backTileMap = this->backTileMapRe;
        this->backTileMapRe = NULL;
        this->_isBackTileReload = FALSE;
    }
}


//void GameLayer::ccTouchesBegan( CCSet *pTouches, CCEvent *pEvent )
//{
//    if (this->game_status==GameState::PLAY)
//    {
//        this->processEvent(pTouches);
//    }
//    CCLOG("%s","ccTouchesBegan");
//}
//
////触摸移动
//void GameLayer::ccTouchesMoved( CCSet *pTouches, CCEvent *pEvent )
//{
//    CCLOG("%s","ccTouchesMoved");
//}
//
//
//
//
//void GameLayer::ccTouchesEnded( CCSet *pTouches, CCEvent *pEvent )
//{
//    CCLOG("%s","ccTouchesEnded");
//}


//都是尼玛单点触摸 行了吧 草

bool GameLayer::ccTouchBegan( CCTouch *pTouch, CCEvent *pEvent )
{
    //this->processEvent(pTouch);
    return true;
}

void GameLayer::ccTouchMoved( CCTouch *pTouch, CCEvent *pEvent )
{
    this->processEvent(pTouch);
}

void GameLayer::ccTouchEnded( CCTouch *pTouch, CCEvent *pEvent )
{
    this->processEvent(pTouch);
}

//处理滑动事件
void GameLayer::processEvent( CCTouch* touches )
{
    if (this->game_status==GameState::PLAY)
    {
        CCPoint delt = touches->getDelta();

        CCPoint curp = this->ship->getPosition();
        curp = ccpAdd(curp,delt);
        
        curp = ccpClamp(curp,CCPointZero,ccp(winSize.width,winSize.height));

        this->ship->setPosition(curp);
    }
}

//注册
void GameLayer::registerWithTouchDispatcher( void )
{
    CCDirector* pDirector = CCDirector::sharedDirector();
     pDirector->getTouchDispatcher()->addTargetedDelegate(this, 1, true);  
}




