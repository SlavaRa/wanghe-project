#include "GameMenu.h"
#include "cocos2d.h"

using namespace cocos2d;

CCScene* GameMenu::pScene = 0;

GameMenu::GameMenu(void)
{
}


GameMenu::~GameMenu(void)
{
}

//³¡¾°
CCScene* GameMenu::scene()
{
	if(pScene==0)
	{
		pScene = new CCScene();
	}
	return pScene;
}
