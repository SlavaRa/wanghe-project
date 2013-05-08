#pragma once
#include "cocos2d.h"
USING_NS_CC;
class Explosion:public CCSprite
{
public:

	bool active;
	float tempWidth;
	float tempHeight;

	void destory();
	static void sharedExplosion();

	static Explosion* getOrCreateExplosion();

	Explosion(void);
	~Explosion(void);
};

