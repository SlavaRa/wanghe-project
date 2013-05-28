#include "Processor.h"


Processor::Processor(void)
{
}


Processor::~Processor(void)
{
}

//包装一下
void Processor::notifyObserver( const char* notify,void* data )
{
	this->hanldNotification(notify,data);
}

void Processor::hanldNotification( const char* notify,void* data )
{

}


//返回感兴趣的消息列表
vector<const char*> Processor::listNotificationInterest()
{
	//listNotify.clear();
	//this->listNotify.push_back("TEST_EVENT");
	//this->listNotify.push_back("TEST_EVENT2");
	return listNotify;
}

//注册一个处理器
void Processor::registerProcessor()
{

}

//反注册一个处理器
void Processor::unregiaterProcessor()
{

}


