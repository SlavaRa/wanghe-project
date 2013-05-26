#include "ObserverManager.h"


//��ʼ������
ObserverManager* ObserverManager::instance = new ObserverManager();





//************************************
// Method:    getInstance
// FullName:  ObserverManager::getInstance
// Access:    public static 
// Returns:   ObserverManager*
// Qualifier: ����ģʽ
//************************************
ObserverManager* ObserverManager::getInstance()
{
	return ObserverManager::instance;
}



//************************************
// Method:    registerObserver
// FullName:  ObserverManager::registerObserver
// Access:    public 
// Returns:   void
// Qualifier: ע��һ���۲���
// Parameter: const char * notify
// Parameter: IObserver * observer
//************************************
void ObserverManager::registerObserver( const char* notify,IObserver* observer )
{

}

//************************************
// Method:    unregisterObserver
// FullName:  ObserverManager::unregisterObserver
// Access:    public 
// Returns:   void
// Qualifier: ��ע��һ���۲���
// Parameter: const char * notify
// Parameter: IObserver * observer
//************************************
void ObserverManager::unregisterObserver( const char* notify,IObserver* observer )
{

}

//************************************
// Method:    sendNotification
// FullName:  ObserverManager::sendNotification
// Access:    public 
// Returns:   void
// Qualifier: ������Ϣ
// Parameter: const char * notify
// Parameter: IObserver * observer
// Parameter: void * data
//************************************
void ObserverManager::sendNotification( const char* notify,IObserver* observer,void* data )
{

}


//************************************
// Method:    getObservers
// FullName:  ObserverManager::getObservers
// Access:    public 
// Returns:   vector<IObserver*>
// Qualifier: ��ȡ�۲�����
//************************************
vector<IObserver*> ObserverManager::getObservers()
{
	return observers;
}



ObserverManager::ObserverManager()
{
	//��ʼ���������ݽṹ
}

ObserverManager::~ObserverManager()
{

}


