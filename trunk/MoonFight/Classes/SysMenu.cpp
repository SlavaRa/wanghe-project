#include "SysMenu.h"
#include "resource.h"
#include "gameConfig.h"
#include "SimpleAudioEngine.h"
#include "GameLayer.h"
#include "Effect.h"
using namespace cocos2d;

CCScene* SysMenu::scene()
{
	CCScene* scene = NULL;
	do
	{
		scene = CCScene::create();
		CC_BREAK_IF(!scene);

		CCLayer* layer = SysMenu::create();
		CC_BREAK_IF(!layer);

		scene->addChild(layer);

	} while (0);
	return scene;
}

bool SysMenu::init()
{
	bool ret = false;
	do
	{
		CCSpriteFrameCache::sharedSpriteFrameCache()->addSpriteFramesWithFile(s_texttureOpaquePack_plist);
		CCSpriteFrameCache::sharedSpriteFrameCache()->addSpriteFramesWithFile(s_textureTransparentPack_plist);

		CCSize size = CCDirector::sharedDirector()->getWinSize();

		//±³¾°
		CCSprite* loading = CCSprite::create(s_loading);
		loading->setAnchorPoint(ccp(0,0));
		this->addChild(loading);
		//LOGO 
		CCSprite* logo = CCSprite::create(s_logo);
		logo->setAnchorPoint(ccp(0,0));
		logo->setPosition(ccp(0,250));
		this->addChild(logo);

		CCSprite* newGameNormal			= CCSprite::create(s_menu,CCRectMake(0,0,126,33));
		CCSprite* newGameSelect			= CCSprite::create(s_menu,CCRectMake(0,33,126,33));
		CCSprite* newGameDisable		= CCSprite::create(s_menu,CCRectMake(0,33*2,126,33));
		
		CCSprite* gameSettingNormal		= CCSprite::create(s_menu,CCRectMake(126,0,126,33));
		CCSprite* gameSettingSelect		= CCSprite::create(s_menu,CCRectMake(126,33,126,33));
		CCSprite* gameSettingDisable	= CCSprite::create(s_menu,CCRectMake(126,33*2,126,33));

		CCSprite* aboutNormal			= CCSprite::create(s_menu,CCRectMake(126*2,0,126,33));
		CCSprite* aboutSelect			= CCSprite::create(s_menu,CCRectMake(126*2,33,126,33));
		CCSprite* aboutDisable			= CCSprite::create(s_menu,CCRectMake(126*2,33*2,126,33));

		CCMenuItemSprite* newGame = CCMenuItemSprite::create(newGameNormal,newGameSelect,newGameDisable,
			this,menu_selector(SysMenu::menuNewGameCallBack));
		CCMenuItemSprite* gameSetting = CCMenuItemSprite::create(gameSettingNormal,gameSettingSelect,gameSettingDisable,
			this,menu_selector(SysMenu::menuGameSettingCallBack));
		CCMenuItemSprite* about = CCMenuItemSprite::create(aboutNormal,aboutSelect,aboutDisable,
			this,menu_selector(SysMenu::menuAboutCallBack));


		CCMenu* menu = CCMenu::create(newGame,gameSetting,about,NULL);
		menu->alignItemsVerticallyWithPadding(10);
		this->addChild(menu,1,2);
		menu->setPosition(size.width/2,size.height/2-80);

		this->schedule(schedule_selector(SysMenu::update),0.1f);

		this->ship = CCSprite::createWithSpriteFrameName("ship01.png");
		this->addChild(ship,0,4);

		CCPoint p = ccp(CCRANDOM_0_1()*size.width,0);

		ship->setPosition(p);
		ship->runAction(CCMoveBy::create(2,ccp(CCRANDOM_0_1()*size.width,p.y+size.height+100)));

		CocosDenshion::SimpleAudioEngine::sharedEngine()->setEffectsVolume(0.7f);
		CocosDenshion::SimpleAudioEngine::sharedEngine()->playBackgroundMusic(s_mainMainMusic,true);

		this->setKeypadEnabled(true);

		ret = true;

	}while (0);

	return ret;
}

void SysMenu::update(float dt)
{
	if (this->ship->getPosition().y>480)
	{
		CCSize size = CCDirector::sharedDirector()->getWinSize();
		CCPoint p = ccp(CCRANDOM_0_1()*size.width,10);
		this->ship->setPosition(p);
		this->ship->runAction(CCMoveBy::create(2,ccp(CCRANDOM_0_1()*size.width,p.y+480)));
	}
}


void SysMenu::menuAboutCallBack(CCObject* pSender)
{

}


void SysMenu::menuNewGameCallBack(CCObject* pSender)
{

	Effect::playEffect(this,this, cocos2d::SEL_CallFunc(&SysMenu::newGame));
}


void SysMenu::menuGameSettingCallBack(CCObject* pSender)
{

}

void SysMenu::onButtonEffect()
{
	if(SOUND==1)
	{
		CocosDenshion::SimpleAudioEngine::sharedEngine()->playEffect(s_buttonEffect);
	}
}

void SysMenu::newGame()
{
	CocosDenshion::SimpleAudioEngine::sharedEngine()->playEffect(s_buttonEffect,true);

	CCScene* sc = CCScene::create();
	sc->addChild(GameLayer::create());
	//sc->addChild();
	CCDirector::sharedDirector()->replaceScene(CCTransitionFade::create(1.2f,sc));
}

void SysMenu::keyBackClicked()
{
	CCDirector::sharedDirector()->end();
}


