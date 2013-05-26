#pragma once

#include "IObserver.h"

struct HNotification
{
	/*
	 *消息
	 */
	const char * notify;
	/*
	 *观察者
	 */
	IObserver* observer;
	/*
	 *数据
	 */
	void* data;
};