#pragma once
#include "cocos2d.h"
#include "EnemyType.h"
#include "ICollideRect.h"
using namespace cocos2d;
class Enemy:public CCSprite,public ICollideRect
{
public:
	Enemy(ENEMY_STRUCT &arg);
	~Enemy(void);

	int eID;
	int enemyType;
	bool active;
	int speed;
	int bulletSpeed;
	int HP;
	int bulletPowerValue;
	int moveType;
	int scoreValue;
	int zOrder;
	int delayTime;
	ENEMY_ATTACK_MODE attackMode;
	int _hurtColorLife;

	void update(int dt);
	void destory();
	void shoot(float dt);
	void hurt();
	CCRect collideRect();
	static Enemy* getOrCreateEnemy(ENEMY_STRUCT& arg);
private:
	int timeTick;
};

