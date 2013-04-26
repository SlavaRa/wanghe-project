#pragma once
#include "cocos2d.h"
#include "EnemyType.h"
using namespace cocos2d;
class Enemy:public CCSprite
{
public:
	Enemy(ENEMY_STRUCT &arg);
	~Enemy(void);

	int eID;
	int enenmyType;
	bool active;
	int speed;
	int bulletSpeed;
	int HP;
	int bulletPowerValue;
	int moveType;
	int scoreValue;
	int zOrder;
	int delayTime;
	int attackMode;
	int _hurtColorLife;

	void update(int dt);
	void destory();
	void shoot();
	void hurt();
	void collideRect();
	static Enemy* getOrCreateEnemy(ENEMY_STRUCT& arg);
private:
	int timeTick;
};

