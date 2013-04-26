#pragma once
#include "cocos2d.h"
using namespace cocos2d;
class Effect
{
public:
	static void playEffect(CCNode* parent,CCNode* target,cocos2d::SEL_CallFunc callback);
	static void removeFromParent(CCNode* sprite);
	static void spark(CCPoint* point,CCNode* parent,float scale,float duration);

	void killFlare(CCNode* flare);
};

