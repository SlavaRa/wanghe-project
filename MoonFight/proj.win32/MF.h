#pragma once
#include <vector>
#include "cocos2d.h"
using namespace std;
USING_NS_CC;

class MF
{

public:


	//************************************
	// Method:    getEnemys
	// FullName:  MF::getEnemys
	// Access:    public 
	// Returns:   vector<CCNode*>*
	// Qualifier:	获取敌人
	//************************************
	vector<CCNode*>* getEnemys();


	//************************************
	// Method:    getEnemysBullets
	// FullName:  MF::getEnemysBullets
	// Access:    public 
	// Returns:   vector<CCNode*>*
	// Qualifier:	获取敌人的子弹
	//************************************
	vector<CCNode*>* getEnemysBullets();

	//************************************
	// Method:    getPlayerBullets
	// FullName:  MF::getPlayerBullets
	// Access:    public 
	// Returns:   vector<CCNode*>*
	// Qualifier: 获取玩家的子弹
	//************************************
	vector<CCNode*>* getPlayerBullets();

	//************************************
	// Method:    getExplosions
	// FullName:  MF::getExplosions
	// Access:    public 
	// Returns:   vector<CCNode*>*
	// Qualifier: 获取爆炸效果
	//************************************
	vector<CCNode*>* getExplosions();

	//************************************
	// Method:    getSparks
	// FullName:  MF::getSparks
	// Access:    public 
	// Returns:   vector<CCNode*>*
	// Qualifier: 获取火花
	//************************************
	vector<CCNode*>* getSparks();

	//************************************
	// Method:    getHits
	// FullName:  MF::getHits
	// Access:    public 
	// Returns:   vector<CCNode*>*
	// Qualifier: 获取打击效果
	//************************************
	vector<CCNode*>* getHits();
	/*获取分数*/
	int getScore();
	/*设置分数*/
	void setScore(int iscore);
	/*获取生命数*/
	int getLife();
	/*设置生命数*/
	void setLife(int ilife);


	static MF* getInstance();


	~MF(void);
	
private:
	
	static MF* instance;

	static vector<CCNode*> *ENEMYS;
	static vector<CCNode*> *ENEMYS_BULLETS;
	static vector<CCNode*> *PLAYER_BULLETS;
	static vector<CCNode*> *EXPLOSIONS;
	static vector<CCNode*> *SPARKS;
	static vector<CCNode*> *HITS;

	/*分数*/
	static int score;
	/*生命*/
	static int life;

	MF(void);
	
};

