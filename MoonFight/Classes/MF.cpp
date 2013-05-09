#include "MF.h"


vector<CCNode*>* MF::ENEMYS = new vector<CCNode*>();
vector<CCNode*>* MF::ENEMYS_BULLETS = new vector<CCNode*>();
vector<CCNode*>* MF::PLAYER_BULLETS = new vector<CCNode*>();
vector<CCNode*>* MF::EXPLOSIONS = new vector<CCNode*>();
vector<CCNode*>* MF::SPARKS = new vector<CCNode*>();
vector<CCNode*>* MF::HITS = new vector<CCNode*>();

int MF::score = 0;
int MF::life = 4;


MF* MF::instance = new MF();

MF::MF(void)
{

}


MF::~MF(void)
{
}



//************************************
// Method:    getEnemys
// FullName:  MF::getEnemys
// Access:    public
// Returns:   vector<CCNode*>*
// Qualifier: ªÒ»°µ–»À
//************************************
vector<CCNode*>* MF::getEnemys()
{
    return ENEMYS;
}

//************************************
// Method:    getEnemysBullets
// FullName:  MF::getEnemysBullets
// Access:    public
// Returns:   vector<CCNode*>*
// Qualifier:
//************************************
vector<CCNode*>* MF::getEnemysBullets()
{
    return ENEMYS_BULLETS;
}

//************************************
// Method:    getPlayerBullets
// FullName:  MF::getPlayerBullets
// Access:    public
// Returns:   vector<CCNode*>*
// Qualifier:
//************************************
vector<CCNode*>* MF::getPlayerBullets()
{
    return PLAYER_BULLETS;
}

//************************************
// Method:    getExplosions
// FullName:  MF::getExplosions
// Access:    public
// Returns:   vector<CCNode*>*
// Qualifier:
//************************************
vector<CCNode*>* MF::getExplosions()
{
    return EXPLOSIONS;
}

//************************************
// Method:    getSparks
// FullName:  MF::getSparks
// Access:    public
// Returns:   vector<CCNode*>*
// Qualifier:
//************************************
vector<CCNode*>* MF::getSparks()
{
    return SPARKS;
}

//************************************
// Method:    getHits
// FullName:  MF::getHits
// Access:    public
// Returns:   vector<CCNode*>*
// Qualifier:
//************************************
vector<CCNode*>* MF::getHits()
{
    return HITS;
}

int MF::getScore()
{
    return MF::score;
}

void MF::setScore( int iscore )
{
    MF::score = iscore;
}

int MF::getLife()
{
    return MF::life;
}

void MF::setLife( int ilife )
{
    MF::life = score;
}

MF* MF::getInstance()
{
    return MF::instance;
}
