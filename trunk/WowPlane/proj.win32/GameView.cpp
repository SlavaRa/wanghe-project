#include "GameView.h"



CCScene* GameView::scene()
{
	CCScene* scene = CCScene::create();
	GameView* layer = GameView::create();
	scene->addChild(layer);
	return scene;
}

bool GameView::init()
{
	if (!CCLayer::init())
	{
		return false;
	}

	CCSize size = CCDirector::sharedDirector()->getVisibleSize();
	CCPoint origin = CCDirector::sharedDirector()->getVisibleOrigin();

	//初始化各种东西
	CCSprite* bg = CCSprite::create("gameview.jpg");
	this->addChild(bg);
	bg->setPosition(ccp(size.width / 2 + origin.x, size.height / 2 + origin.y));
	return true;
}
