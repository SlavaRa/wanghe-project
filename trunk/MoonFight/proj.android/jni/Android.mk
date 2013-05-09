LOCAL_PATH := $(call my-dir)

include $(CLEAR_VARS)

LOCAL_MODULE := game_shared

LOCAL_MODULE_FILENAME := libgame

LOCAL_CPP_EXTENSION := .cpp

LOCAL_SRC_FILES := hellocpp/main.cpp \
                   ../../Classes/AppDelegate.cpp \
                   ../../Classes/Level1.cpp \
                   ../../Classes/gameConfig.cpp \
                   ../../Classes/Bullet.cpp \
                   ../../Classes/Effect.cpp \
                   ../../Classes/Enemy.cpp \
                   ../../Classes/EnemyType.cpp \
                   ../../Classes/Explosion.cpp \
                   ../../Classes/GameLayer.cpp \
                   ../../Classes/HitEffect.cpp \
                   ../../Classes/ICollideRect.cpp \
                   ../../Classes/LevelManager.cpp \
                   ../../Classes/MF.cpp \
                   ../../Classes/Ship.cpp \
                   ../../Classes/SysMenu.cpp \
                   
LOCAL_C_INCLUDES := $(LOCAL_PATH)/../../Classes                   

LOCAL_WHOLE_STATIC_LIBRARIES := cocos2dx_static cocosdenshion_static cocos_extension_static
            
include $(BUILD_SHARED_LIBRARY)

$(call import-add-path, F:\cocos2d\cocos2d-2.1beta3-x-2.1.1\cocos2d-2.1beta3-x-2.1.1)\
$(call import-add-path, F:\cocos2d\cocos2d-2.1beta3-x-2.1.1\cocos2d-2.1beta3-x-2.1.1\cocos2dx\platform\third_party\android\prebuilt)\

$(call import-module,CocosDenshion/android) \
$(call import-module,cocos2dx) \
$(call import-module,extensions)
