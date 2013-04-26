#include "Level1.h"

//Level1

vector<EnemyLevel*> enemies;

Level1::Level1()
{

}

Level1::~Level1()
{

}

vector<EnemyLevel*>* Level1::getEnemies()
{
	return &enemies;
}


void Level1::initLevel1()
{
	EnemyLevel* el1 = new EnemyLevel;
	el1->ShowType = "Repeate";
	el1->ShowTime = "00:02";
	el1->Types.push_back(0);
	el1->Types.push_back(1);
	el1->Types.push_back(2);


	EnemyLevel* el2 = new EnemyLevel;
	el2->ShowType = "Repeate";
	el2->ShowTime = "00:05";
	el2->Types.push_back(3);
	el2->Types.push_back(4);
	el2->Types.push_back(5);

	Level1::getEnemies()->push_back(el1);
	Level1::getEnemies()->push_back(el2);
}


