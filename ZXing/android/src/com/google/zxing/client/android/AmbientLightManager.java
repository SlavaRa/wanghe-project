/*
 * Copyright (C) 2012 ZXing authors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package com.google.zxing.client.android;

import android.content.Context;
import android.content.SharedPreferences;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;
import android.preference.PreferenceManager;
import com.google.zxing.client.android.camera.CameraManager;
import com.google.zxing.client.android.camera.FrontLightMode;

/**
 * 检测环境光，在很黑暗的情况下，打开闪光灯，然后光照充足的时候关闭
 * Detects ambient light and switches on the front light when very dark, and off again when sufficiently light.
 *
 * @author Sean Owen
 * @author Nikolaus Huber
 */
final class AmbientLightManager implements SensorEventListener {

  //  黑暗阀值  勒克斯（照明单位）
  private static final float TOO_DARK_LUX = 45.0f;
  private static final float BRIGHT_ENOUGH_LUX = 450.0f;

  private final Context context;
  private CameraManager cameraManager;
  private Sensor lightSensor;

  AmbientLightManager(Context context)
  {
    this.context = context;
  }

  void start(CameraManager cameraManager)
  {
    this.cameraManager = cameraManager;
    SharedPreferences sharedPrefs = PreferenceManager.getDefaultSharedPreferences(context);
    if (FrontLightMode.readPref(sharedPrefs) == FrontLightMode.AUTO)
    {
      //  获取传感器服务
      SensorManager sensorManager = (SensorManager) context.getSystemService(Context.SENSOR_SERVICE);
      // 获取一个光传感器
      lightSensor = sensorManager.getDefaultSensor(Sensor.TYPE_LIGHT);
      if (lightSensor != null)
      {
        //  注册监听
        //  这个类实现 SensorEventListener 接口
        //  回调onSensorChanged函数
        sensorManager.registerListener(this, lightSensor, SensorManager.SENSOR_DELAY_NORMAL);
      }
    }
  }

  void stop() {
    if (lightSensor != null) {
      SensorManager sensorManager = (SensorManager) context.getSystemService(Context.SENSOR_SERVICE);
      sensorManager.unregisterListener(this);
      cameraManager = null;
      lightSensor = null;
    }
  }

  @Override
  public void onSensorChanged(SensorEvent sensorEvent)
  {
    //  当前环境的光照强度
    float ambientLightLux = sensorEvent.values[0];
    if (cameraManager != null)
    {
      if (ambientLightLux <= TOO_DARK_LUX)
      {
        //  如果小于 黑暗阀值
        //  打开手电筒
        cameraManager.setTorch(true);
      }
      else if (ambientLightLux >= BRIGHT_ENOUGH_LUX)
      {
        //  如果大于明亮的阀值 关闭手电筒
        cameraManager.setTorch(false);
      }
    }
  }

  @Override
  public void onAccuracyChanged(Sensor sensor, int accuracy) {
    // do nothing
  }

}
