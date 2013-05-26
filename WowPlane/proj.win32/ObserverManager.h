#pragma once

#include "IObserver.h"
#include <vector>

using namespace std;

class ObserverManager
{
public:

	//************************************
	// Method:    getInstance
	// FullName:  ObserverManager::getInstance
	// Access:    public static 
	// Returns:   ObserverManager*
	// Qualifier: ����ģʽ
	//************************************
	static ObserverManager* getInstance();

	//************************************
	// Method:    registerObserver
	// FullName:  ObserverManager::registerObserver
	// Access:    public static
	// Returns:   void 
	// Qualifier: ע��һ���۲���
	// Parameter: const char * notify  ��Ϣ��
	// Parameter: IObserver * observer �۲���
	//************************************
	static void registerObserver(const char* notify,IObserver* observer);
	//************************************
	// Method:    unregisterObserver
	// FullName:  ObserverManager::unregisterObserver
	// Access:    public static
	// Returns:   void
	// Qualifier:��ע��һ���۲���
	// Parameter: const char * notify	��Ϣ��
	// Parameter: IObserver * observer	�۲���
	//************************************
	static void unregisterObserver(const char* notify,IObserver* observer);

	//************************************
	// Method:    sendNotification
	// FullName:  ObserverManager::sendNotification
	// Access:    public static
	// Returns:   void
	// Qualifier: ����һ����Ϣ��
	// Parameter: const char * notify	��Ϣ��
	// Parameter: IObserver * observer	�۲���
	// Parameter: void * data			����
	//************************************
	static void sendNotification(const char* notify,IObserver* observer,void* data);


	vector<IObserver*> getObservers();



	ObserverManager();

	~ObserverManager();

private:
	static ObserverManager* instance;
	vector<IObserver*> observers;

};

