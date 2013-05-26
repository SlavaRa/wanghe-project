#include "ObserverManager.h"


//初始化单例
ObserverManager* ObserverManager::instance = new ObserverManager();





//************************************
// Method:    getInstance
// FullName:  ObserverManager::getInstance
// Access:    public static 
// Returns:   ObserverManager*
// Qualifier: 单例模式
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
// Qualifier: 注册一个观察者
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
// Qualifier: 反注册一个观察者
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
// Qualifier: 发送消息
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
// Qualifier: 获取观察者们
//************************************
vector<IObserver*> ObserverManager::getObservers()
{
	return observers;
}



ObserverManager::ObserverManager()
{
	//初始化各种数据结构
}

ObserverManager::~ObserverManager()
{

}


