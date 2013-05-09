#include "Enemy.h"
#include "gameConfig.h"
#include "cocos2d.h"
#include "Bullet.h"
#include "GameLayer.h"
#include "resource.h"
#include "SimpleAudioEngine.h"
#include <vector>
#include "MF.h"
#include "Explosion.h"

using namespace std;
using namespace cocos2d;

Enemy::Enemy(ENEMY_STRUCT& arg)
{
	this->eID = 0;
	this->enemyType = 1;
	this->active = true;
	this->speed = 200;
	this->bulletSpeed = -200;
	this->HP = arg.HP;
	this->bulletPowerValue = 1;
	this->moveType = arg.moveType;
	this->scoreValue = arg.scoreValue;
	this->zOrder = 1000;
	this->delayTime = 1 + 1.2 * CCRANDOM_0_1();
	this->attackMode = NORMAL;
	this->_hurtColorLife = 0;

	this->timeTick = 0;

	this->initWithSpriteFrameName(arg.textTureName);
	this->schedule(schedule_selector(Enemy::shoot), delayTime);
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

	this->timeTick += dt;
	if (this->timeTick > 0.1)
	{
		this->timeTick = 0;
		if (this->_hurtColorLife > 0)
		{
			this->_hurtColorLife--;
		}
		this->setColor(ccc3(255, 255, 255));
	}

	if(p.x<0||p.x>GameLayer::getInstance()->screenRect.size.width||p.y<0||p.y>GameLayer::getInstance()->screenRect.size.height||this->HP<=0)
	{
		this->active=false;
		this->destory();
	}
}


CCRect Enemy::collideRect()
{
	CCPoint p = this->getPosition();
	CCSize size = this->getContentSize();

	return  CCRectMake((p.x-size.width/2),(p.y-size.height/4),size.width,size.height/2);
}

void Enemy::hurt()
{
	this->_hurtColorLife=2;
	this->HP--;
	this->setColor(ccc3(255,0,0));
}

void Enemy::shoot(float dt)
{
	CCPoint p = this->getPosition();
	Bullet* b = Bullet::getOrCreateBullet(this->bulletSpeed,"W2.png",this->attackMode,3000,ENEMY_BULLET_TAG);
	b->setPosition(p);
}



void Enemy::destory()
{
	Explosion *explosion =Explosion::getOrCreateExplosion();
	explosion->setPosition(this->getPosition());
	//GameLayer::getInstance()->addExplosions(explosion);

	CocosDenshion::SimpleAudioEngine::sharedEngine()->playEffect(s_explodeEffect);
	this->stopAllActions();
	this->unschedule(schedule_selector(Enemy::shoot));

	this->removeFromParent();


	this->setPosition(GL_HIDE_POSITION);
}

Enemy* Enemy::getOrCreateEnemy( ENEMY_STRUCT& arg )
{
	for (vector<CCNode*>::iterator it=MF::getInstance()->getEnemys()->begin();it!=MF::getInstance()->getEnemys()->end();it++)
	{
		if (((Enemy*)(*it))->active==false && ((Enemy*)(*it))->enemyType==arg.type)
		{
			((Enemy*)(*it))->HP=arg.HP;
			((Enemy*)(*it))->active=true;
			((Enemy*)(*it))->moveType=arg.moveType;
			((Enemy*)(*it))->scoreValue=arg.scoreValue;
			((Enemy*)(*it))->attackMode=arg.attackMode;
			((Enemy*)(*it))->_hurtColorLife=0;
			((Enemy*)(*it))->setColor(ccc3(255,255,255));

			((Enemy*)(*it))->schedule(schedule_selector(Enemy::shoot),((Enemy*)(*it))->delayTime);
			return ((Enemy*)(*it));
		}
	}

	Enemy* enemy = new Enemy(arg);
	GameLayer::getInstance()->addEnemy(enemy,enemy->zOrder,ENEMY_TAG);
	MF::getInstance()->getEnemys()->push_back(enemy);

	return enemy;
}
