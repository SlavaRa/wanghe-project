#include "Ship.h"
#include "cocos2d.h"
using namespace cocos2d;

//构造函数
Ship::Ship()
{
	this->speed = 220;
	this->bulletSpeed = 900;
	this->HP = 5;
	this->bulletTypeValue = 1;
	this->bulletPowerValue = 1;
	this->throwBombing = false;
	this->canBeAttack = true;
	this->isThrowingBomb = false;
	this->zOrder = 3000;
	this->maxBulletPowerValue = 4;
	this->appearPosition = ccp(160, 60);
	this->hurtColorLife = 0;
	this->active = true;
	this->timeTick = 0;

	this->initWithSpriteFrameName("ship01.png");
	this->setTag(zOrder);
	this->setPosition(this->appearPosition);


	//CCMultableArray<>

	//CCArray<CCSpriteFrame*> *frames = new
	CCSpriteFrameCache *cache = CCSpriteFrameCache::sharedSpriteFrameCache();
	CCSpriteFrame *frame0 = cache->spriteFrameByName("ship01.png");
	CCSpriteFrame *frame1 = cache->spriteFrameByName("ship02.png");
	CCArray *frames = CCArray::createWithCapacity(2);
	frames->addObject(frame0);
	frames->addObject(frame1);
	CCAnimation *animation = CCAnimation::createWithSpriteFrames(frames, 0.1f);
	CCAnimate *animate = CCAnimate::create(animation);
	this->runAction(CCRepeatForever::create(animate));

	this->schedule(schedule_selector(Ship::shoot), 1 / 6);

	this->born();
}

//析构函数
Ship::~Ship()
{

}

void Ship::update(float dt)
{
	if (this->HP <= 0)
	{
		this->active = false;
		this->destory();
	}
	this->timeTick += dt;
	if (timeTick > 0.1)
	{
		timeTick = 0;
		if (this->hurtColorLife > 0)
		{
			this->hurtColorLife--;
		}
		if (this->hurtColorLife == 1)
		{
			this->setColor(ccc3(255, 255, 255));
		}
	}
}

void Ship::shoot(float dt)
{
	int offset = 13;
	CCPoint point = this->getPosition();
	CCSize size = this->getContentSize();
	//TODO 未完成 去写子弹了
}

void Ship::destory()
{

}

void Ship::hurt()
{

}

void Ship::collideRect(CCPoint p)
{

}

void Ship::born()
{

}