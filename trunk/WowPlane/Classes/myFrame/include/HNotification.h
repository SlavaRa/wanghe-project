#pragma once

#include "IObserver.h"

struct HNotification
{
	/*
	 *��Ϣ
	 */
	const char * notify;
	/*
	 *�۲���
	 */
	IObserver* observer;
	/*
	 *����
	 */
	void* data;
};