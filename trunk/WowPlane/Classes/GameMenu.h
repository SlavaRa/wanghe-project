#pragma once
#include "cocos2d.h"
using namespace cocos2d;

class GameMenu:public cocos2d::CCLayer
{
public:
	virtual bool init();
	static CCScene* scene(); 


	CREATE_FUNC(GameMenu);
};

