#ifndef __SHIP_H__
#define __SHIP_H__

#include "ICollideRect.h"
#include "cocos2d.h"
using namespace cocos2d;
class Ship:public CCSprite,public ICollideRect
{
public:
	int speed;
	int bulletSpeed;
	int HP;
	int bulletTypeValue;
	int bulletPowerValue;
	bool throwBombing;
	bool canBeAttack;
	bool isThrowingBomb;
	int zOrder;
	int maxBulletPowerValue;
	CCPoint appearPosition;
	int hurtColorLife;
	bool active;
	float timeTick;

	//构造函数
	Ship();
	//析构函数
	~Ship();

	void update(float dt);
	void shoot(float dt);
	void destory();
	void hurt();
	void born();
	CCRect collideRect();
};

#endif