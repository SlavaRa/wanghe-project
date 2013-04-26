#pragma once
#include "cocos2d.h"
using namespace cocos2d;
class HitEffect:public CCSprite
{
public:
	HitEffect(void);
	~HitEffect(void);

	bool active;

	void reset(CCPoint position,float rotation,float scale);
	void destory();
	static void getOrCreateHitEffect(CCPoint position,float rotation,float scale);
};

