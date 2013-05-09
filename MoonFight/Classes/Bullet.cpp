#include "Bullet.h"
#include "HitEffect.h"
#include "cocos2d.h"
#include <vector>
#include "MF.h"
#include "GameLayer.h"
#include "gameConfig.h"


Bullet::Bullet(float bulletSpeed, const char* weaponType, ENEMY_ATTACK_MODE attackMode)
{
	this->active = true;
	this->xVelocity = 0;
	this->yVelocity = -bulletSpeed;
	this->power = 1;
	this->HP = 1;
	this->moveType = ATTACK;
	this->zOrder = 3000;
	this->attackMode = attackMode;
	this->parentType = PLAYER;

	this->initWithSpriteFrameName(weaponType);
	ccBlendFunc blend = {GL_SRC_ALPHA,GL_ONE};
	this->setBlendFunc(blend);
}


Bullet::~Bullet(void)
{

}

void Bullet::update( float dt )
{
	CCPoint p = this->getPosition();
	p.x-=this->xVelocity*dt;
	p.y-=this->yVelocity*dt;

	this->setPosition(p);
	//TODO 判断点是不是在屏幕之外
	if (p.x<0||p.x>GameLayer::getInstance()->screenRect.size.width||p.y<0||p.y>GameLayer::getInstance()->screenRect.size.height)
	{
		this->active=false;
		this->destory();
	}

}

Bullet* Bullet::getOrCreateBullet( float bulletSpeed, const char* weaponType, ENEMY_ATTACK_MODE attackMode, int zOrde, UNIT_TAG mode )
{
	if (mode == PLAYER_BULLET_TAG)
	{
		for (vector<CCNode*>::iterator it = MF::getInstance()->getPlayerBullets()->begin();it != MF::getInstance()->getPlayerBullets()->end();it++)
		{
			if(((Bullet*)(*it))->active==false)
			{
				((Bullet*)(*it))->HP=1;
				((Bullet*)(*it))->active=true;

				return ((Bullet*)(*it));
			}
		}

		Bullet* b = new Bullet(bulletSpeed,weaponType,attackMode);
		GameLayer::getInstance()->addBullet(b,zOrde,mode);
		MF::getInstance()->getPlayerBullets()->push_back(b);
		return b;
	}
	else
	{
		for (vector<CCNode*>::iterator it = MF::getInstance()->getEnemysBullets()->begin();it != MF::getInstance()->getEnemysBullets()->end();it++)
		{
			if(((Bullet*)(*it))->active==false)
			{
				((Bullet*)(*it))->HP=1;
				((Bullet*)(*it))->active=true;

				return ((Bullet*)(*it));
			}
		}

		Bullet* b = new Bullet(bulletSpeed,weaponType,attackMode);
		GameLayer::getInstance()->addBullet(b,zOrde,mode);
		MF::getInstance()->getEnemysBullets()->push_back(b);
		return b;
	}
	return NULL;
}

void Bullet::destory()
{
	HitEffect::getOrCreateHitEffect(this->getPosition(),CCRANDOM_0_1()*360,0.75);
	this->setPosition(GL_HIDE_POSITION);

}

void Bullet::hurt()
{
	this->HP--;
}

CCRect Bullet::collideRect()
{
	CCPoint p = this->getPosition();
	return CCRectMake(p.x-3,p.y-3,6,6);
}
