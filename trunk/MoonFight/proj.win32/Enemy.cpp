#include "Enemy.h"
#include "gameConfig.h"
#include "cocos2d.h"
using namespace cocos2d;

Enemy::Enemy(ENEMY_STRUCT& arg)
{
	this->eID = 0;
	this->enenmyType = 1;
	this->active = true;
	this->speed = 200;
	this->bulletSpeed = -200;
	this->HP = arg.HP;
	this->bulletPowerValue = 1;
	this->moveType=arg.moveType;
	this->scoreValue = arg.scoreValue;
	this->zOrder = 1000;
	this->delayTime = 1 + 1.2 * CCRANDOM_0_1();
	this->attackMode = ENEMY_MOVE_TYPE::VERTICAL;
	this->_hurtColorLife = 0;

	this->timeTick=0;

	this->initWithSpriteFrameName(arg.textTureName);
	//this->schedule(schedule_selector(Enemy::shoot),delayTime);
}

Enemy::~Enemy(void)
{

}

void Enemy::update( int dt )
{
	CCPoint p = this->getPosition();
	if ((p.x < 0 || p.x > 320) && (p.y < 0 || p.y > 480))
	{
		this->active = false;
	}

	this->timeTick+=dt;
	if (this->timeTick>0.1)
	{
		this->timeTick=0;
		if (this->_hurtColorLife>0)
		{
			this->_hurtColorLife--;
		}
		this->setColor(ccc3(255,255,255));
	}

	//if(p.x<0||p.x>SHARED_GAME_LAYER->screenRect.width)
	//{

	//}
}


void Enemy::collideRect()
{
	
}

void Enemy::hurt()
{

}

void Enemy::shoot()
{

}



void Enemy::destory()
{

}

Enemy* Enemy::getOrCreateEnemy( ENEMY_STRUCT& arg )
{
	return NULL;
}
