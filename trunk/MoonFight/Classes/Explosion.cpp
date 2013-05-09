#include "Explosion.h"
#include "cocos2d.h"
#include "resource.h"
#include "cocos2d.h"
#include "MF.h"
#include "GameLayer.h"
#include <stdio.h>
using namespace std;

USING_NS_CC;

//构造函数
Explosion::Explosion(void)
{
	this->active = true;

	CCSpriteFrame* frame = CCSpriteFrameCache::sharedSpriteFrameCache()->spriteFrameByName("explosion_01.png");
	this->initWithSpriteFrame(frame);
	CCSize size = this->getContentSize();

	this->tempHeight = size.height;
	this->tempWidth = size.width;

	CCAnimation* animation = CCAnimationCache::sharedAnimationCache()->animationByName("Explosion");

	this->runAction(CCSequence::create(CCAnimate::create(animation),CCCallFunc::create(this,callfunc_selector(Explosion::destory)),NULL));

	ccBlendFunc blend = {GL_SRC_ALPHA,GL_ONE};
	this->setBlendFunc(blend);
}

Explosion::~Explosion(void)
{

}

//销毁
void Explosion::destory()
{
	this->getParent()->removeChild(this);
}

void Explosion::sharedExplosion()
{
	CCSpriteFrameCache::sharedSpriteFrameCache()->addSpriteFramesWithFile(s_explosion_plist);
	CCArray *frames = CCArray::createWithCapacity(35);

	for (int i =1;i<=35;i++)
	{
		string s1 = "explosion_";
		string s2 = ".png";
		string s3 = "";

		if (i<10)
		{
			char num[10]="\0";
			sprintf(num,"%d",i);
			s3+="0";
			s3+=num;
		}
		else
		{
			char nu[10]="\0";
			sprintf(nu,"%d",i);
			s3+=nu;
		}
		s1+=s3;
		s1+=s2;

		CCSpriteFrame* frame = CCSpriteFrameCache::sharedSpriteFrameCache()->spriteFrameByName(s1.c_str());
		frames->addObject(frame);
	}
	CCAnimation* animation = CCAnimation::createWithSpriteFrames(frames,0.04f);
	CCAnimationCache::sharedAnimationCache()->addAnimation(animation,"Explosion");
}

Explosion* Explosion::getOrCreateExplosion()
{
	for (vector<CCNode*>::iterator it = MF::getInstance()->getExplosions()->begin();it!=MF::getInstance()->getExplosions()->end();it++)
	{
		if (((Explosion*)(*it))->active == false)
		{
			((Explosion*)(*it))->active = true;
			CCAnimation* animation = CCAnimationCache::sharedAnimationCache()->animationByName("Explosion");
			((Explosion*)(*it))->runAction(CCSequence::create(CCAnimate::create(animation),callfunc_selector(Explosion::destory),NULL));

			return ((Explosion*)(*it));
		}
	}

	Explosion* explosion = new Explosion();
	GameLayer::getInstance()->addExplosions(explosion);
	MF::getInstance()->getExplosions()->push_back(explosion);
	return explosion;
}



