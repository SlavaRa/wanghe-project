#pragma once
#include "gameConfig.h"
#include "GameLayer.h"
#include "Level1.h"
#include <vector>
using namespace std;
class LevelManager
{
public:
    LevelManager(GameLayer &layer);
    ~LevelManager(void);

    GameLayer* gameLayer;

    vector<EnemyLevel*>* currentLevel;

    void setLevel(vector<EnemyLevel*>* enemies);
    void loadLevelResource(int datetime);
    void addEnemyToGameLayer(int enemyType);
private:
    int minuteToSecond(const char* minute);

};

