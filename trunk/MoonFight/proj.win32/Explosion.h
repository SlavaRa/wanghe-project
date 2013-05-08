#pragma once
#include "cocos2d.h"
USING_NS_CC;
class Explosion:public CCSprite
{
public:

	float tempWidth;
	float tempHeight;

	void destory();
	static void sharedExplosion();

	Explosion(void);
	~Explosion(void);
};

