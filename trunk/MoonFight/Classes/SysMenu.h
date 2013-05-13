#pragma once
#ifndef __SYS_MENU_H__
#define	__SYS_MENU_H__

#include "cocos2d.h"
#include "SimpleAudioEngine.h"
using namespace cocos2d;

class SysMenu:public cocos2d::CCLayer
{
public:

	virtual bool init();

	CCSprite* ship;

	static cocos2d::CCScene* scene();

	void menuNewGameCallBack(CCObject* pSender);
	void menuGameSettingCallBack(CCObject* pSender);
	void menuAboutCallBack(CCObject* pSender);
	void onButtonEffect();
	void update(float dt);

	void newGame();

	virtual void keyBackClicked();

	CREATE_FUNC(SysMenu);
};
#endif
