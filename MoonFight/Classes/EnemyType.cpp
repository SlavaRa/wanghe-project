#include "EnemyType.h"
#include "gameConfig.h"


ENEMY_STRUCT e1 ={
	0,
	1,
	"E0.png",
	"W2.png",
	ATTACK,
	NORMAL,
	15
};

ENEMY_STRUCT e2 ={
	1,
	2,
	"E1.png",
	"W2.png",
	ATTACK,
	NORMAL,
	40
};

ENEMY_STRUCT e3 ={
	2,
	4,
	"E2.png",
	"W2.png",
	HORIZONTAL,
	TSUIHIKIDAN,
	60
};

ENEMY_STRUCT e4 ={
	3,
	6,
	"E3.png",
	"W2.png",
	VERTICAL,
	NORMAL,
	80
};

ENEMY_STRUCT e5 ={
	4,
	8,
	"E4.png",
	"W2.png",
	OVERLAP,
	TSUIHIKIDAN,
	100
};

ENEMY_STRUCT e6 ={
	5,
	10,
	"E5.png",
	"W2.png",
	HORIZONTAL,
	NORMAL,
	150
};

static struct ENEMY_STRUCT ENEMY_TYPE[] = {e1,e2,e3,e4,e5,e6};

EnemyType::EnemyType()
{
}

EnemyType::~EnemyType()
{
}

ENEMY_STRUCT* EnemyType::getEnemyType()
{
	return ENEMY_TYPE;
}



