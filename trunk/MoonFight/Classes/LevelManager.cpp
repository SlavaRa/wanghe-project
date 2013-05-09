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
    
    int newX=0;

    CCPoint offset;
    CCActionInterval* tmpAction;

    CCActionInterval* a0;
    CCActionInterval* a1;

    CCCallFunc* callback;
    switch (enemy->moveType)
    {
    case ATTACK:
        offset = this->gameLayer->ship->getPosition();
        tmpAction = CCMoveTo::create(1, offset);
        break;
    case VERTICAL:
        offset = ccp(0, -GameLayer::getInstance()->winSize.height - enemycs.height);
        tmpAction = CCMoveBy::create(4, offset);
        break;
    case HORIZONTAL:
        offset = ccp(0, -100 - 200 * CCRANDOM_0_1());
        //TODO 回调
        a0 = CCMoveBy::create(0.5f, offset);
        a1 = CCMoveBy::create(1, ccp(-50 - 100 * CCRANDOM_0_1(), 0));

        callback = CCCallFuncN::create(enemy, callfuncN_selector(LevelManager::moveCallBack));
        //BUG
        tmpAction = CCSequence::create(a0, a1, callback,NULL);

        break;
    case OVERLAP:
        newX = (enemy->getPosition().x <= GameLayer::getInstance()->winSize.width / 2) ? 320 : -320;
        a0 = CCMoveBy::create(4,ccp(newX,-240));
        a1 = CCMoveBy::create(4,ccp(-newX,-320));
        tmpAction = CCSequence::create(a0,a1,NULL);

        break;
    default:
        break;
    }


    enemy->runAction(tmpAction);
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

//有BUG
int LevelManager::minuteToSecond( const char* minute )
{
    char m[2];
    char s[2];
    strncpy(m, minute, 2);

    char *sp = const_cast<char*>(minute);
    sp += 3;
    strncpy(s, sp, 2);
    //s[sizeof(s) - 1] = '\0';

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

void LevelManager::moveCallBack( CCNode* node )
{
    CCDelayTime* a2 = CCDelayTime::create(1);
    CCActionInterval* a3 = CCMoveBy::create(1, ccp(100 + 100 * CCRANDOM_0_1(), 0));
   
    node->runAction(CCRepeatForever::create(CCSequence::create(a2, a3, a2->copy(), a3->reverse(),NULL)));
}
