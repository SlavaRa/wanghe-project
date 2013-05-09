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
	// Qualifier:	��ȡ����
	//************************************
	vector<CCNode*>* getEnemys();


	//************************************
	// Method:    getEnemysBullets
	// FullName:  MF::getEnemysBullets
	// Access:    public 
	// Returns:   vector<CCNode*>*
	// Qualifier:	��ȡ���˵��ӵ�
	//************************************
	vector<CCNode*>* getEnemysBullets();

	//************************************
	// Method:    getPlayerBullets
	// FullName:  MF::getPlayerBullets
	// Access:    public 
	// Returns:   vector<CCNode*>*
	// Qualifier: ��ȡ��ҵ��ӵ�
	//************************************
	vector<CCNode*>* getPlayerBullets();

	//************************************
	// Method:    getExplosions
	// FullName:  MF::getExplosions
	// Access:    public 
	// Returns:   vector<CCNode*>*
	// Qualifier: ��ȡ��ըЧ��
	//************************************
	vector<CCNode*>* getExplosions();

	//************************************
	// Method:    getSparks
	// FullName:  MF::getSparks
	// Access:    public 
	// Returns:   vector<CCNode*>*
	// Qualifier: ��ȡ��
	//************************************
	vector<CCNode*>* getSparks();

	//************************************
	// Method:    getHits
	// FullName:  MF::getHits
	// Access:    public 
	// Returns:   vector<CCNode*>*
	// Qualifier: ��ȡ���Ч��
	//************************************
	vector<CCNode*>* getHits();
	/*��ȡ����*/
	int getScore();
	/*���÷���*/
	void setScore(int iscore);
	/*��ȡ������*/
	int getLife();
	/*����������*/
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

	/*����*/
	static int score;
	/*����*/
	static int life;

	MF(void);
	
};

