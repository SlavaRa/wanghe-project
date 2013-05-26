
#pragma once


class IObserver
{
public:
	//************************************
	// Method:    notifyObserver
	// FullName:  IObserver::notifyObserver
	// Access:    virtual public 
	// Returns:   void
	// Qualifier: �۲��ߵĽӿ�
	// Parameter: const char * notify
	// Parameter: void * data
	//************************************
	virtual void notifyObserver(const char* notify,void* data)=0;

private:

};