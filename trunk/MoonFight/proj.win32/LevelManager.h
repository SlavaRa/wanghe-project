#pragma once
#include "gameConfig.h"
#include "GameLayer.h"
#include "Level1.h"
#include <vector>
using namespace std;
class LevelManager
{
public:
    LevelManager(GameLayer& layer);
    ~LevelManager(void);
	GameLayer* gameLayer;
    //当前敌人的的等级数组
    vector<EnemyLevel*>* currentLevel;

    void setLevel(vector<EnemyLevel*>* enemies);
    void loadLevelResource(int datetime);
    void addEnemyToGameLayer(int enemyType);
	void moveCallBack(CCNode* node);

private:
    int minuteToSecond(const char* minute);
};

