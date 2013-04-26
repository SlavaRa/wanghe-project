#include "HitEffect.h"


HitEffect::HitEffect(void)
{
	this->initWithSpriteFrameName("hit.png");
	ccBlendFunc blend = {GL_SRC_ALPHA , GL_ONE};
	this->setBlendFunc(blend);
}


HitEffect::~HitEffect(void)
{
}

void HitEffect::reset( CCPoint position,float rotation,float scale )
{
	this->setPosition(position);
	this->setRotation(rotation);
	this->setScale(scale);

	CCActionInterval* scaleAction = CCScaleTo::create(0.3f,2.0f,2.0f);
	this->runAction(CCSequence::create(CCFadeOut::create(0.3f),callfunc_selector(HitEffect::destory)));
}

void HitEffect::destory()
{
	//this->setPosition();
}

void HitEffect::getOrCreateHitEffect( CCPoint position,float rotation,float scale )
{

}
