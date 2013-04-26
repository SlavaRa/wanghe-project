#pragma once
#ifndef __GAME_CONFIG__
#define __GAME_CONFIG__
#include "cocos2d.h"
using namespace cocos2d;

static const int SOUND = 0x01;

//Òþ²ØµÄÎ»ÖÃ
static const CCPoint GL_HIDE_POSITION = ccp(-10.0f, -10.0f);

enum GameState
{
	HOME = 1,
	PLAY = 2,
	OVER = 3
};

enum Level
{
	STAGE1 = 1,
	STAGE2 = 2,
	STAGE3 = 3
};

enum ENEMY_MOVE_TYPE
{
	ATTACK = 0,
	VERTICAL = 1,
	HORIZONTAL = 2,
	OVERLAP = 3
};

enum BULLET_TYPE
{
	PLAYER = 1,
	ENEMY = 2
};

enum WEAPON_TYPE
{
	ONE = 1
};

enum UNIT_TAG
{
	ENEMY_BULLET_TAG = 900,
	PLAYER_BULLET_TAG = 901,
	ENEMY_TAG = 1000,
	PLAYER_TAG = 1000
};


enum ENEMY_ATTACK_MODE
{
	NORMAL=1,
	TSUIHIKIDAN=2
};

struct Container
{
	CCArray* ENEMYS;
	CCArray* ENEMY_BULLETS;
	CCArray* PLAYER_BULLETS;
	CCArray* EXPLOSIONS;
	CCArray* SPARKS;
	CCArray* HITS;
};


class MW
{
public:
	static CCArray* KEYS;
	static Level level;
	static ENEMY_MOVE_TYPE Enemy_Move_Type;
	static int DELTA_X;
	static int OFFSET_X;
	static int LIFE;
	static int SCORE;
	static bool SOUND;
	static double ROT;
	static int LIFEUP_SCORE[];

	static Container CONTAINER;

};




#endif