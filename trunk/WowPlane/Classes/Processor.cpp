#include "Processor.h"


Processor::Processor(void)
{
}


Processor::~Processor(void)
{
}

//��װһ��
void Processor::notifyObserver( const char* notify,void* data )
{
	this->hanldNotification(notify,data);
}

void Processor::hanldNotification( const char* notify,void* data )
{

}


//���ظ���Ȥ����Ϣ�б�
vector<const char*> Processor::listNotificationInterest()
{
	//listNotify.clear();
	//this->listNotify.push_back("TEST_EVENT");
	//this->listNotify.push_back("TEST_EVENT2");
	return listNotify;
}

//ע��һ��������
void Processor::registerProcessor()
{

}

//��ע��һ��������
void Processor::unregiaterProcessor()
{

}


