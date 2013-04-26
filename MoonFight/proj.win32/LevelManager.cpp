#include "LevelManager.h"
#include "Level1.h"
#include "Enemy.h"


LevelManager::LevelManager(GameLayer &layer)
{
	Level1::initLevel1();

	this->gameLayer=&layer;

	this->currentLevel = Level1::getEnemies();

}


LevelManager::~LevelManager(void)
{
}

void LevelManager::addEnemyToGameLayer( int enemyType )
{
	//ENEMY_STRUCT* enemy = Enemy::getOrCreateEnemy();
}

void LevelManager::loadLevelResource( int datetime )
{

}

int LevelManager::minuteToSecond( const char* minute )
{
	char m[2];
	char s[2];
	strncpy(m,minute,2);
	m[sizeof(m)-1]='\0';

	char *sp = const_cast<char*>(minute);
	sp+=3;
	strncpy(s,sp,2);
	s[sizeof(s)-1]='\0';

	int im = atoi(m);
	int is = atoi(s);


	return im*60+is;
}

void LevelManager::setLevel( vector<EnemyLevel*>* enemies )
{
	int i=0;
	for (vector<EnemyLevel*>::iterator it=enemies->begin();it!=enemies->end();it++)
	{
		(*it)->iShowTime=minuteToSecond((*it)->ShowTime);
	}
}
