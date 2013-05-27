#pragma once

#include "IObserver.h"
#include <vector>

using namespace std;


//消息与观察者结构体
struct ObserverStruct
{
	//消息名称
	const char* notify;
	//观察者
	vector<IObserver*>* observers;
};

class ObserverManager
{
public:

	//************************************
	// Method:    getInstance
	// FullName:  ObserverManager::getInstance
	// Access:    public static 
	// Returns:   ObserverManager*
	// Qualifier: 单例模式
	//************************************
	static ObserverManager* getInstance();

	//************************************
	// Method:    registerObserver
	// FullName:  ObserverManager::registerObserver
	// Access:    public static
	// Returns:   void 
	// Qualifier: 注册一个观察者
	// Parameter: const char * notify  消息名
	// Parameter: IObserver * observer 观察者
	//************************************
	static void registerObserver(const char* notify,IObserver* observer);
	//************************************
	// Method:    unregisterObserver
	// FullName:  ObserverManager::unregisterObserver
	// Access:    public static
	// Returns:   void
	// Qualifier:反注册一个观察者
	// Parameter: const char * notify	消息名
	// Parameter: IObserver * observer	观察者
	//************************************
	static void unregisterObserver(const char* notify,IObserver* observer);

	//************************************
	// Method:    sendNotification
	// FullName:  ObserverManager::sendNotification
	// Access:    public static
	// Returns:   void
	// Qualifier: 发送一个消息，
	// Parameter: const char * notify	消息名
	// Parameter: ObserverStruct * observer	观察者
	// Parameter: void * data			数据
	//************************************
	static void sendNotification(const char* notify,IObserver* observer,void* data);


	vector<ObserverStruct*> getObservers();

	ObserverManager();

	~ObserverManager();

private:
	static ObserverManager* instance;
	vector<ObserverStruct*> observers;

};

