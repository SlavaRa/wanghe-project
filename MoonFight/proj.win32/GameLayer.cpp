#pragma once
#include "GameLayer.h"
#include "resource.h"
#include "Ship.h"
#include "gameConfig.h"
#include "LevelManager.h"
#include "MF.h"
#include "ICollideRect.h"
#include "Explosion.h"
#include <vector>
using namespace std;

GameLayer* GameLayer::SHARED_GAME_LAYER = new GameLayer();

GameLayer::GameLayer( void )
{

}



bool GameLayer::init()
{
    SHARED_GAME_LAYER = this;

    game_status = GameState::PLAY;
    //不透明图层
    CCTexture2D* texOpaque = CCTextureCache::sharedTextureCache()->addImage(s_texttureOpaquePack);
    this->texOpaqueBatch = CCSpriteBatchNode::createWithTexture(texOpaque);
    ccBlendFunc blend = {GL_SRC_ALPHA, GL_ONE};
    this->texOpaqueBatch->setBlendFunc(blend);
    this->addChild(texOpaqueBatch);


    //透明的图层
    CCTexture2D* texTransparent = CCTextureCache::sharedTextureCache()->addImage(s_textureTransparentPack);
    this->texTransparentBatch = CCSpriteBatchNode::createWithTexture(texTransparent);
    this->addChild(texTransparentBatch);

    this->ship = new Ship();
    this->texTransparentBatch->addChild(ship, this->ship->zOrder, UNIT_TAG::PLAYER_TAG);


    Explosion::sharedExplosion();

    
    this->levelManager = new LevelManager(*this);


    this->iniBackGround();

    screenRect = CCRectMake(0, 0, winSize.width, winSize.height + 10);

    this->setTouchEnabled(true);

    this->scheduleUpdate();
    this->schedule(schedule_selector(GameLayer::scoreCounter), 1);

    return true;
}

GameLayer::~GameLayer( void )
{

}

//更新
void GameLayer::update( float dt )
{
    this->checkIsCollide();
    this->removeInactiveUnit(dt);
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
    this->addChild(this->backTileMap, -9);
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
    this->backTileMap->runAction(CCMoveBy::create(3.0f, ccp(0, -200)));
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
    if (this->game_status == GameState::PLAY)
    {
        CCPoint delt = touches->getDelta();

        CCPoint curp = this->ship->getPosition();
        curp = ccpAdd(curp, delt);

        curp = ccpClamp(curp, CCPointZero, ccp(winSize.width, winSize.height));

        this->ship->setPosition(curp);
    }
}

//注册
void GameLayer::registerWithTouchDispatcher( void )
{
    CCDirector* pDirector = CCDirector::sharedDirector();
    pDirector->getTouchDispatcher()->addTargetedDelegate(this, 1, true);
}

GameLayer* GameLayer::getInstance()
{
    return SHARED_GAME_LAYER;
}

//移除不活动的对象
void GameLayer::removeInactiveUnit( float dt )
{

    CCArray* _array  = this->texOpaqueBatch->getChildren();
    CCObject* _object;
    CCARRAY_FOREACH(_array, _object)
    {
        if (((CCNode*)_object)->getTag()==UNIT_TAG::PLAYER_TAG)
        {
            if(_object&&(((Ship*)_object)->active==true))
            {
                ((Ship*)_object)->update(dt);
            }
        }
        else
        {
            if(_object&&(((Bullet*)_object)->active==true))
            {
                ((Bullet*)_object)->update(dt);
            }
        }
    }


    CCArray* _arrayEnemy = this->texTransparentBatch->getChildren();
    CCObject* _objectEnemy;
    CCARRAY_FOREACH(_arrayEnemy,_objectEnemy)
    {
        //应该把这些玩意抽象一下
        if (((CCNode*)_objectEnemy)->getTag()==UNIT_TAG::PLAYER_TAG)
        {
            if(_objectEnemy&&(((Ship*)_objectEnemy)->active==true))
            {
                ((Ship*)_objectEnemy)->update(dt);
            }
        }
        else
        {
            if(_objectEnemy&&(((Enemy*)_objectEnemy)->active==true))
            {
                ((Enemy*)_objectEnemy)->update(dt);
            }
        }
    }
}

void GameLayer::addBullet( Bullet* b, int zOrder, int mode )
{
    this->texOpaqueBatch->addChild(b, zOrder, mode);
}

void GameLayer::addEnemy( Enemy* enemy, int zOrder, int mode )
{
    this->texTransparentBatch->addChild(enemy , zOrder, mode);
}

void GameLayer::scoreCounter(float dt)
{
    if (this->game_status==GameState::PLAY)
    {
        this->time++;

        this->levelManager->loadLevelResource(this->time);
    }
}

//碰撞检测
void GameLayer::checkIsCollide()
{
    for (vector<CCNode*>::iterator it = MF::getInstance()->getEnemys()->begin();it!=MF::getInstance()->getEnemys()->end();it++)
    {
        //与玩家子弹的碰撞
        for (vector<CCNode*>::iterator itb = MF::getInstance()->getPlayerBullets()->begin();itb!=MF::getInstance()->getPlayerBullets()->end();itb++)
        {
            if (colledeRect((dynamic_cast<ICollideRect*>(*it)),(dynamic_cast<ICollideRect*>(*itb))))
            {
                ((Enemy*)(*it))->hurt();
                ((Bullet*)(*it))->hurt();
                if (!screenRect.intersectsRect((*it)->boundingBox()))
                {
                     ((Bullet*)(*it))->destory();
                }
            }
        }
        //与玩家的碰撞

        if (colledeRect((dynamic_cast<ICollideRect*>(*it)),(dynamic_cast<ICollideRect*>(ship))))
        {
            if (this->ship->active)
            {
                this->ship->hurt();
                ((Enemy*)(*it))->hurt();
            }
        }
    }


    for (vector<CCNode*>::iterator iteb=MF::getInstance()->getEnemysBullets()->begin();iteb!=MF::getInstance()->getEnemysBullets()->end();iteb++)
    {
        if (colledeRect((dynamic_cast<ICollideRect*>(*iteb)),(dynamic_cast<ICollideRect*>(ship))))
        {
            if (this->ship->active)
            {
                this->ship->hurt();
                ((Enemy*)(*iteb))->hurt();
            }
        }
        if (!screenRect.intersectsRect((*iteb)->boundingBox()))
        {
            ((Bullet*)(*iteb))->destory();
        }
    }
}

//碰撞检测
bool GameLayer::colledeRect(ICollideRect* rect1,ICollideRect* rect2 )
{
    CCRect r1 = rect1->collideRect();
    

    CCRect r2 = rect2->collideRect();
    return r1.intersectsRect(r2);
}