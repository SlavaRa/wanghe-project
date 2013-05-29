#include "GameMenu.h"
#include "cocos2d.h"
#include "GameView.h"
using namespace cocos2d;


//场景
CCScene* GameMenu::scene()
{
    CCScene* scene = CCScene::create();
    GameMenu* layer = GameMenu::create();
    scene->addChild(layer);
    return scene;
}

bool GameMenu::init()
{
    if (!CCLayer::init())
    {
        return false;
    }

    CCSize size = CCDirector::sharedDirector()->getVisibleSize();
    CCPoint origin = CCDirector::sharedDirector()->getVisibleOrigin();


    //背景图片
    CCSprite* bg = CCSprite::create("bg.jpg");
    bg->setPosition(ccp(size.width / 2 + origin.x, size.height / 2 + origin.y));
    this->addChild(bg);

    CCMenuItemImage* itemImage = CCMenuItemImage::create("btn.jpg","btn.jpg",this,menu_selector(GameMenu::startGameCallBack));
    itemImage->setPosition(ccp(size.width / 2 + origin.x, size.height / 2 + origin.y-100));

    CCMenu* pMenu = CCMenu::create(itemImage, NULL);
    pMenu->setPosition(CCPointZero);
    this->addChild(pMenu, 1);
    return true;
}

//点击开始按钮的回调
void GameMenu::startGameCallBack(CCObject* pSender)
{
    CCLOG("%s","many bu kaopu");
    CCScene* scene = GameView::scene();
    CCDirector::sharedDirector()->replaceScene(scene);
}
