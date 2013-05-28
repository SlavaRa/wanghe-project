#pragma once
#include "IObserver.h"
#include <vector>
using namespace std;

class Processor :
	public IObserver
{
public:
	Processor(void);
	~Processor(void);

	void notifyObserver( const char* notify,void* data );
	void hanldNotification(const char* notify,void* data );

	vector<const char*> listNotify;
	vector<const char*> listNotificationInterest();

	void registerProcessor();
	void unregiaterProcessor();

};

