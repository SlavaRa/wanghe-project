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
	for (vector<ObserverStruct*>::iterator it = ObserverManager::getInstance()->getObservers().begin();it!=ObserverManager::getInstance()->getObservers().end();it++)
	{
		if (strcmp(notify,(*it)->notify)==0)
		{
			(*it)->observers->push_back(observer);
			//���֮ǰ�����Ƶ���Ϣ ֱ���ӽ�ȥ ����	
			return;
		}
	}

	//��ʱ����һ���ṹ��
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
// Qualifier: ��ע��һ���۲���
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
// Qualifier: ������Ϣ
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
// Qualifier: ��ȡ�۲�����
//************************************
vector<ObserverStruct*> ObserverManager::getObservers()
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




