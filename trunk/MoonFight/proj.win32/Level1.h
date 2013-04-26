#pragma once
#include <vector>
using namespace std;

struct EnemyLevel
{
	const char* ShowType;
	const char* ShowTime;
	int iShowTime;
	vector<int> Types;
};



class Level1
{
public:
	Level1();
	~Level1();

	static vector<EnemyLevel*>* getEnemies();
	static void initLevel1();
private:

};

//void initLevel1();

