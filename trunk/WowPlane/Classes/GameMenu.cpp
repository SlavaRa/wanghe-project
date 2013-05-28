#include "GameMenu.h"
#include "cocos2d.h"

using namespace cocos2d;


//³¡¾°
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



    CCSprite* bg = CCSprite::create("bg.jpg");

    bg->setPosition(ccp(size.width / 2 + origin.x, size.height / 2 + origin.y));

    this->addChild(bg);

    return true;
}
