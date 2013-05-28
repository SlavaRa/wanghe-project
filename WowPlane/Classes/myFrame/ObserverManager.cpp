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
	for (vector<ObserverStruct*>::iterator it = ObserverManager::getInstance()->getObservers().begin();it!=ObserverManager::getInstance()->getObservers().end();it++)
	{
		if (strcmp(notify,(*it)->notify)==0)
		{
			(*it)->observers->push_back(observer);
			//如果之前有类似的消息 直接扔进去 返回	
			return;
		}
	}

	//临时创建一个结构体
	ObserverStruct* tempStruct = new ObserverStruct();
	tempStruct->notify = notify;
	tempStruct->observers->push_back(observer);

	ObserverManager::getInstance()->getObservers().push_back(tempStruct);

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
	for (vector<ObserverStruct*>::iterator it = ObserverManager::getInstance()->getObservers().begin();it!=ObserverManager::getInstance()->getObservers().end();it++)
	{
		if (strcmp(notify,(*it)->notify)==0)
		{
			for (vector<IObserver*>::iterator it2 = (*it)->observers->begin();it2!=(*it)->observers->end();it2++)
			{
				if (observer==(*it2))
				{
					 (*it)->observers->erase(it2);
					 return;
				}
			}
			return;
		}
	}
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
	vector<IObserver*> tempObserver;
	for (vector<ObserverStruct*>::iterator it = ObserverManager::getInstance()->getObservers().begin();it!=ObserverManager::getInstance()->getObservers().end();it++)
	{
		if (strcmp(notify,(*it)->notify)==0)
		{
			for (vector<IObserver*>::iterator it2 = (*it)->observers->begin();it2!=(*it)->observers->begin();it2++)
			{
				tempObserver.push_back((*it2));
			}
		}
	}

	for (vector<IObserver*>::iterator it3 = tempObserver.begin();it3!=tempObserver.begin();it3++)
	{
		(*it3)->notifyObserver(notify,data);
	}
}


//************************************
// Method:    getObservers
// FullName:  ObserverManager::getObservers
// Access:    public 
// Returns:   vector<ObserverStruct*>
// Qualifier: 获取观察者们
//************************************
vector<ObserverStruct*> ObserverManager::getObservers()
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




