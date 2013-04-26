#pragma once
#ifndef __BULLET_H__
#define __BULLET_H__

#include "cocos2d.h"
#include "gameConfig.h"
using namespace cocos2d;

class Bullet:public CCSprite
{
public:
	Bullet(float bulletSpeed,const char* weaponType,ENEMY_ATTACK_MODE attackMode);
	~Bullet(void);

	bool active;
	int xVelocity;
	int yVelocity;
	int power;
	int HP;
	ENEMY_MOVE_TYPE moveType;
	int zOrder;
	int attackMode;
	BULLET_TYPE parentType;
	
	static Bullet* getOrCreateBullet(float bulletSpeed,const char* weaponType,ENEMY_ATTACK_MODE attackMode,int zOrde,UNIT_TAG mode);
	
	void update(float dt);
	void hurt();
	CCRect collideRect(CCPoint p);
	void destory();

};

#endif