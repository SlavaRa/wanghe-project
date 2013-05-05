#pragma once
#include "gameConfig.h"

//���������ṹ��
struct ENEMY_STRUCT
{
	int type;
	int HP;
	const char* textTureName;
	const char* bulletType;
	ENEMY_MOVE_TYPE moveType;
	ENEMY_ATTACK_MODE attackMode;
	int scoreValue;

};

class EnemyType
{
public:
	EnemyType();
	~EnemyType();

	static ENEMY_STRUCT* getEnemyType();

private:

};
