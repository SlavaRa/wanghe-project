#include "Effect.h"
#include "resource.h"
#include "cocos2d.h"

using namespace cocos2d;

void Effect::playEffect(CCNode* parent,CCNode* target,cocos2d::SEL_CallFunc callback)
{
	CCSprite* flare = CCSprite::create(s_flare);
	ccBlendFunc blend = {GL_SRC_ALPHA , GL_ONE};
	flare->setBlendFunc(blend);
	parent->addChild(flare);
	flare->setOpacity(0);
	flare->setPosition(ccp(-30,297));
	flare->setRotation(-120);
	flare->setScale(0.2f);

	CCActionInterval* opacityAnim = CCFadeTo::create(0.5,255);
	CCActionInterval* opacDim = CCFadeTo::create(1,0);
	CCActionInterval* biggeAnim = CCScaleBy::create(0.7f,1.2f,1.2f);
	CCActionInterval* biggerEase = CCEaseSineOut::create(biggeAnim);
	CCActionInterval* moveAnim = CCMoveBy::create(0.5,ccp(328,0));
	CCActionInterval* easeMove = CCEaseSineOut::create(moveAnim);
	CCActionInterval* rotateAnim = CCRotateBy::create(2.5,90);
	CCActionInterval* rotateEase = CCEaseExponentialOut::create(rotateAnim);
	CCActionInterval* bigger = CCScaleTo::create(0.5,1);

	CCFiniteTimeAction* onComplete = CCCallFunc::create(target,callback);
	CCFiniteTimeAction* killflare = CCCallFuncN::create(flare,callfuncN_selector(Effect::killFlare));

	flare->runAction(CCSequence::create(opacityAnim,biggerEase,opacDim,killflare,onComplete,NULL));
	flare->runAction(easeMove);
	flare->runAction(rotateEase);
	flare->runAction(bigger);
}


void Effect::spark(CCPoint* point,CCNode* parent,float scale,float duration)
{
	scale	=	scale	?scale		:0.3f;
	duration=	duration?duration	:0.5f;

	CCSprite* one	= CCSprite::createWithSpriteFrameName("explode1.png");
	CCSprite* two	= CCSprite::createWithSpriteFrameName("explode2.png");
	CCSprite* three = CCSprite::createWithSpriteFrameName("explode3.png");

	one->setPosition(*point);
	two->setPosition(*point);
	three->setPosition(*point);
	//TODO 

	


}


void Effect::removeFromParent(CCNode* node)
{
	node->removeFromParent();
}

void Effect::killFlare(CCNode* sender)
{
	sender->removeFromParent();
}