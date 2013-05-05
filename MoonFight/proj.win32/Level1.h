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
	static bool initialed;
	static vector<EnemyLevel*>* enemies;
	static vector<EnemyLevel*>* getEnemies();
private:

};

