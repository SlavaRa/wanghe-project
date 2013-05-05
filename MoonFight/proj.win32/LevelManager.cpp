#include "LevelManager.h"
#include "Level1.h"
#include "Enemy.h"
#include "EnemyType.h"
#include "GameLayer.h"
#include <vector>

using namespace std;

LevelManager::LevelManager(GameLayer& layer)
{

    this->gameLayer = &layer;

    this->currentLevel = Level1::getEnemies();

    this->setLevel(currentLevel);
}


LevelManager::~LevelManager(void)
{

}

//添加敌人到图层
void LevelManager::addEnemyToGameLayer( int enemyType )
{
    Enemy* enemy = Enemy::getOrCreateEnemy(EnemyType::getEnemyType()[enemyType]);
    CCPoint point = ccp(80 + (GameLayer::getInstance()->winSize.width - 160) * CCRANDOM_0_1(), GameLayer::getInstance()->winSize.height);
    CCSize enemycs = enemy->getContentSize();
    enemy->setPosition(point);


    CCPoint offset;
    CCAction* tmpAction;


    switch (enemy->moveType)
    {
		case ENEMY_MOVE_TYPE::ATTACK:
			offset = this->gameLayer->ship->getPosition();
			tmpAction = CCMoveTo::create(1,offset);
			break;
		case ENEMY_MOVE_TYPE::VERTICAL:
			offset = ccp(0,-GameLayer::getInstance()->winSize.height-enemycs.height);
			tmpAction=CCMoveBy::create(4,offset);
			break;
		case ENEMY_MOVE_TYPE::HORIZONTAL:
			offset = ccp(0,-100-200*CCRANDOM_0_1());
			//TODO 回调
			break;
		case ENEMY_MOVE_TYPE::OVERLAP:

			break;
		default:
			break;
    }
}



void LevelManager::loadLevelResource( int datetime )
{
    for (vector<EnemyLevel*>::iterator it = currentLevel->begin(); it != currentLevel->end(); it++)
    {
        if ((*it)->ShowType == "Once")
        {
            if ((*it)->iShowTime == datetime)
            {
                for (vector<int>::iterator itEnemy = (*it)->Types.begin(); itEnemy != (*it)->Types.end(); itEnemy++)
                {
                    this->addEnemyToGameLayer(*itEnemy);
                }
            }
        }
        else if ((*it)->ShowType = "Repeat")
        {
            if (datetime % (*it)->iShowTime == 0)
            {
                for (vector<int>::iterator itEnemy2 = (*it)->Types.begin(); itEnemy2 != (*it)->Types.end(); itEnemy2++)
                {
                    this->addEnemyToGameLayer(*itEnemy2);
                }
            }
        }
    }
}

int LevelManager::minuteToSecond( const char* minute )
{
    char m[2];
    char s[2];
    strncpy(m, minute, 2);
    m[sizeof(m) - 1] = '\0';

    char *sp = const_cast<char*>(minute);
    sp += 3;
    strncpy(s, sp, 2);
    s[sizeof(s) - 1] = '\0';

    int im = atoi(m);
    int is = atoi(s);


    return im * 60 + is;
}

void LevelManager::setLevel( vector<EnemyLevel*>* enemies )
{
    int i = 0;
    for (vector<EnemyLevel*>::iterator it = enemies->begin(); it != enemies->end(); it++)
    {
        (*it)->iShowTime = minuteToSecond((*it)->ShowTime);
    }
}
