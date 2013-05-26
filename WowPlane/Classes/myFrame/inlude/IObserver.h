
#pragma once


class IObserver
{
public:
	//************************************
	// Method:    notifyObserver
	// FullName:  IObserver::notifyObserver
	// Access:    virtual public 
	// Returns:   void
	// Qualifier: 观察者的接口
	// Parameter: const char * notify
	// Parameter: void * data
	//************************************
	virtual void notifyObserver(const char* notify,void* data)=0;

private:

};