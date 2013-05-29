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

	//初始化各种东西



	return true;
}
