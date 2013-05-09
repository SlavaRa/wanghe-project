#include "gameConfig.h"

#include "cocos2d.h"

Level MW::level = STAGE1;
CCArray* MW::KEYS = CCArray::create();
int MW::LIFE = 4;
int MW::SCORE = 0;
bool MW::SOUND = true;
Container MW::CONTAINER ={ CCArray::create(),CCArray::create(),CCArray::create(),CCArray::create(),CCArray::create(),CCArray::create()};
int MW::LIFEUP_SCORE[] = {50000,100000,150000,200000,250000,300000};