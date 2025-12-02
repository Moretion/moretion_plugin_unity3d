# moretion_plugin_unity3d
## 1. 简介
本文档将帮助你使用本插件，在unity3d中实时接收并驱动来自魔迅动捕软件MotionStudio（以下简称：MS）的动作捕捉数据。
MS软件支持实时传输实时和离线动捕数据，实时数据是指连接设备时的数据，离线数据指回放数据。通过在MotionStudio开启数据广播，并在Unity3D中建立和MS的网络连接，即可轻松接收并驱动角色模型。

## 2. Assets
[moretion_plugin_unity_V1.0.0.unitypackage](https://github.com/Moretion/moretion_plugin_unity3d/raw/main/UnityPackage/moretion_plugin_unity_V1.0.0.unitypackage)

## 3. 快速跑通Demo
### 3.1 插件下载并导入项目
下载上述Assets中的moretion_plugin_unity.unitypackage包
在unity中点击Asset>Import Package>Custom Package选择刚刚下载的插件包然后导入到项目中


<p align="center">
  <img src="https://github.com/Moretion/moretion_plugin_unity3d/blob/main/Images/importPlugin1.png" alt="提示图" width="500"/>
</p>

<p align="center">
  <img src="https://github.com/Moretion/moretion_plugin_unity3d/blob/main/Images/importPlugin2.png" alt="提示图" width="500"/>
</p>

### 3.2 MS开启数据广播
在MS功能列表中选中“数据广播”，按下图进行相关配置
<p align="center">
  <img src="https://github.com/Moretion/moretion_plugin_unity3d/blob/main/Images/dataBroadcast.png" alt="提示图" width="500"/>
</p>

### 3.3 unity中运行场景
在Assets\Moretion\InertiaCapture\Scenes\目录下双击打开MotionTransformsScene场景。在Hierarchy面板选中“MotionDriver”物体，在Inspector面板修改“MotionSouceManager”脚本的SocketType、Server_ip、Server_port的值（和MS数据广播中设置的一致）。
上述配置完成后在unity中点击运行按钮就可看到机器人的姿态和MS中一致。注意：运行unity的电脑和运行MS的电脑需要在同一局域网内。
<p align="center">
  <img src="https://github.com/Moretion/moretion_plugin_unity3d/blob/main/Images/unitySetting1.png" alt="提示图" width="500"/>
</p>

## 4. 代码库教程

```
Assets
│─── Moretion                                             [魔迅]
│    │
│    │—— InertiaCapture                                   [惯性动捕]
│    │      │——Editor
│    │          │——EditorMotionSourceManagerInspect.cs    [编辑器扩展管理]
│    │          │——EditorMotionTransformsInstance.cs      [编辑器扩展-用户选择不同的socketType面板展示不同属性]
│    │      │——Materials                                  [模型材质]
│    │      │——Models                                     [机器人&手模型]
│    │      │——Plugins                                    [引用插件]
│    │          │——Newtonsoft.Json.dll                    [json解析库]
│    │          │——Motion_RecognizeHG.dll                 [手势识别库]
│    │             │——model                               [训练的模型]
│    │                │——svm_model_left_hand              [手势识别库引用的模型]
│    │                │——svm_model_right_hand             [手势识别库引用的模型]
│    │      │——Scenes
│    │         │——MotionAnimatorScene                     [Animator方式驱动机器人Demo]
│    │         │——MotionGestureRecognitionScene           [手势识别Demo]
│    │         │——MotionHandScene                         [驱动手Demo]
│    │         │——MotionTransformsScene                   [Transform方式驱动机器人Demo]
│    │      │——Scripts
│    │         │——DataConvert.cs                          [bvh不同欧拉角顺规转换]
│    │         │——GestureManager.cs                       [手势管理]
│    │         │——MonoSingleton.cs                        [通用单例]
│    │         │——MotionAnimatorInstance.cs               [Animator方式驱动模型实例]
│    │         │——MotionConnect.cs                        [socket连接相关]
│    │         │——MotionData.cs                           [魔迅动捕json数据实例]
│    │         │——MotionInstance.cs                       [驱动模型实例基类]
│    │         │——MotionSourceManager.cs                  [动捕数据入口]
│    │         │——MotionTransformsInstance.cs             [Transform方式驱动模型实例]
│    │         │——ServerInteraction.cs                    [和MS服务端网络接口交互（可忽略）]
│    │
│    │—— InertiaCapture                                   [通用脚本]
│    │
```

## 5. 模型要求
- 模型所有骨骼自身坐标系为左手坐标系，x轴向右，y向上，z向前

- 左右手各个手指由三部分组成，手指近端、中端、末端组成

- 模型初始姿态必须为T Pose，且T pose下各个骨骼旋转最好为0

模型初始姿态示意图:
<p align="center">
  <img src="https://github.com/Moretion/moretion_plugin_unity3d/blob/main/Images/robot.png" alt="提示图" width="500"/>
</p>

<p align="center">
  <img src="https://github.com/Moretion/moretion_plugin_unity3d/blob/main/Images/hand.png" alt="提示图" width="500"/>
</p>


模型初始姿态不是T-POSE，需要手动设置为T-POSE(手指同理)

<p align="center">
  <img src="https://github.com/Moretion/moretion_plugin_unity3d/blob/main/Images/modelSetting.gif" alt="提示图" width="500"/>
</p>



## 6. 模型骨骼要求
全身模型骨骼要求:(满足的越多动作越精细)
<table>
  <tr>
    <th style="text-align: center;">骨骼</th>
    <th style="text-align: center;">重要程度</th>
  </tr>
  <tr>
    <td style="text-align: center;">头</td>
    <td style="text-align: center;">高</td>
  </tr>
  <tr>
    <td style="text-align: center;">臀</td>
    <td style="text-align: center;">高</td>
  </tr>
  <tr>
    <td style="text-align: center;">臀部向上第一脊椎</td>
    <td style="text-align: center;">低</td>
  </tr>
  <tr>
    <td style="text-align: center;">臀部向上第二脊椎</td>
    <td style="text-align: center;">高</td>
  </tr>
  <tr>
    <td style="text-align: center;">臀部向上第三脊椎</td>
    <td style="text-align: center;">低</td>
  </tr>
  <tr>
    <td style="text-align: center;">肩</td>
    <td style="text-align: center;">低</td>
  </tr>
  <tr>
    <td style="text-align: center;">大臂</td>
    <td style="text-align: center;">高</td>
  </tr>
  <tr>
    <td style="text-align: center;">小臂</td>
    <td style="text-align: center;">高</td>
  </tr>
    <tr>
    <td style="text-align: center;">手</td>
    <td style="text-align: center;">高</td>
  </tr>
    <tr>
    <td style="text-align: center;">大腿</td>
    <td style="text-align: center;">高</td>
  </tr>
    <tr>
    <td style="text-align: center;">小腿</td>
    <td style="text-align: center;">高</td>
  </tr>
    <tr>
    <td style="text-align: center;">脚</td>
    <td style="text-align: center;">高</td>
  </tr>
  <tr>
    <td style="text-align: center;">脚尖</td>
    <td style="text-align: center;">低</td>
  </tr>
  <tr>
    <td style="text-align: center;"> ··· </td>
    <td style="text-align: center;"> ··· </td>
  </tr>
</table>



手模型骨骼要求:(满足的越多动作越精细)
<table>
  <tr>
    <th style="text-align: center;">骨骼</th>
    <th style="text-align: center;">重要程度</th>
  </tr>
  
  <tr>
    <td style="text-align: center;">拇指近端</td>
    <td style="text-align: center;">高</td>
  </tr>
  
  <tr>
    <td style="text-align: center;">拇指中端</td>
    <td style="text-align: center;">高</td>
  </tr>
  
  <tr>
    <td style="text-align: center;">拇指末端</td>
    <td style="text-align: center;">中</td>
  </tr>
  
  <tr>
    <td style="text-align: center;">食指近端</td>
    <td style="text-align: center;">高</td>
  </tr>
  
  <tr>
    <td style="text-align: center;">食指中端</td>
    <td style="text-align: center;">高</td>
  </tr>
  
  <tr>
    <td style="text-align: center;">食指末端</td>
    <td style="text-align: center;">中</td>
  </tr>
  
  <tr>
    <td style="text-align: center;">中指近端</td>
    <td style="text-align: center;">高</td>
  </tr>
  
  <tr>
    <td style="text-align: center;">中指中端</td>
    <td style="text-align: center;">高</td>
  </tr>
  
  <tr>
    <td style="text-align: center;">中指末端</td>
    <td style="text-align: center;">中</td>
  </tr>
  
  <tr>
    <td style="text-align: center;">无名指近端</td>
    <td style="text-align: center;">高</td>
  </tr>
  
  <tr>
    <td style="text-align: center;">无名指中端</td>
    <td style="text-align: center;">高</td>
  </tr>
  
  <tr>
    <td style="text-align: center;">无名指末端</td>
    <td style="text-align: center;">中</td>
  </tr>
  
  <tr>
    <td style="text-align: center;">小拇指近端</td>
    <td style="text-align: center;">高</td>
  </tr>
  
   <tr>
    <td style="text-align: center;">小拇指中端</td>
    <td style="text-align: center;">高</td>
  </tr>
  
  <tr>
    <td style="text-align: center;">小拇指远端</td>
    <td style="text-align: center;">中</td>
  </tr>
  
  <tr>
    <td style="text-align: center;"> ··· </td>
    <td style="text-align: center;"> ··· </td>
  </tr>
</table>



## 7. 如何驱动MotionStudio多角色？
7.1 将MotionSourceManager.cs中变量MotionInstances[]数量设置为MS中角色数量

<p align="center">
  <img src="https://github.com/Moretion/moretion_plugin_unity3d/blob/main/Images/actorSetting1.png" alt="提示图" width="500"/>
</p>

7.2 为MotionSourceManager.cs中变量MotionInstances赋值

<p align="center">
  <img src="https://github.com/Moretion/moretion_plugin_unity3d/blob/main/Images/actorSetting2.png" alt="提示图" width="500"/>
</p>


7.3 设置对应继承MotionInstance.cs实例的ActorID

<p align="center">
  <img src="https://github.com/Moretion/moretion_plugin_unity3d/blob/main/Images/actorSetting3.png" alt="提示图" width="500"/>
</p>

<p align="center">
  <img src="https://github.com/Moretion/moretion_plugin_unity3d/blob/main/Images/actorSetting4.png" alt="提示图" width="500"/>
</p>


## 8. 常见问题

### 8.1 手势识别打包后程序运行闪退
打包后将工程中Motion_RecognizeHG.dll和model文件夹拷贝至xxx.exe同一级目录
<p align="center">
  <img src="https://github.com/Moretion/moretion_plugin_unity3d/blob/main/Images/gesture1.png" alt="提示图" width="500"/>
</p>

<p align="center">
  <img src="https://github.com/Moretion/moretion_plugin_unity3d/blob/main/Images/gesture2.png" alt="提示图" width="500"/>
</p>
