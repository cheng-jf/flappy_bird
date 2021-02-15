# Flappybird

所有资源来源于Unity Asset Store（贴图： 2D Sprites pack；音乐：Tap and Fly、Free Music Tracks For Games）

## **背景**

天空和草地，调整到合适的位置

**场景切换**

两个场景：start（开始界面）和flappybird（运行界面）。当点击开始界面中的按钮切换到运行界面,点击restart按钮重新开始游戏。

问题：这里开始start button一直没反应，因为直接从主游戏场景复制过来的，没有**EventSystem**无法处理事件。

**草地移动**

使用两块草地无限循环来体现鸟的飞翔。给草地添加Box Collider，使鸟撞地后停止。添加Rigidbody并将body type设为Kinematic（使用脚本移动），两块草地拼接作为一个整体向左移动，当移出视野范围让其回到开始的位置。通过改变tranform组件的位置实现无限滚动效果。

## 鸟

**鸟的飞翔动画**

选中鸟为鸟添加动画，创三个clip，分别是still、fly、die。将三个鸟的状态放在三个关键帧上。在Animator中对这三个clip作流程控制。游戏开始**点击**鼠标或空格后，still（默认状态）—>fly**，播放完后，**fly—>still，撞死后still—>die。设置两个trigger（die，fly）来触发状态的切换，希望立即切换的状态需要取消Has Exit Time的勾选

**脚本控制**

要使鸟在空中飞翔，当点击鼠标需要给鸟向上的力使其往上飞，并触发“fly”。添加Rigidbody使用脚本给其加向上的力。

当鸟撞到地板或者管子，鸟死亡，触发”die“，同时需要出现gameover和分数清算的画面，可点击重新开始。创建一个空对象作为游戏控制对象，添加游戏控制脚本来管理鸟这个对象以及游戏的主循环。

## **阻碍**

每个管子添加Box Collider，两个管子作为一个整体添加Box Collider （勾选is trigger使鸟能穿过，调整作为小鸟出口加分）和Rigidbody（body type设为Kinematic，使用脚本移动）。

与草地类似，改变ransform使其向左移动。将其作为一个prefab。

用一个脚本附加到游戏控制对象上来管理多根管道的出现，在Y轴的位置设置随机范围。

为了区分加分区域和管道，对其分别设置addscore tag和obstacle tag。在鸟中添加OnTriggerEnter2D方法遇到加分的collider加分，遇到obstacle的collider让其死亡并调用gameover方法。

## 音乐音效

音乐需要添加AudioSource组件。添加背景音乐使用游戏控制脚本控制，游戏开始时播放，死亡时停止播放。

对鸟添加飞翔音效、撞击音效、加分音效、死亡音效。

## 脚本一览

- **BackGround**

  控制草地移动实现小鸟飞翔效果

- **BirdController**

  控制鸟的一系列行为，包括飞翔、音效、遇到阻碍和通过阻碍的行为。

- **Gameplayer**

  负责控制整个游戏。包括控制背景音乐、实现加分操作，鸟死亡的操作。

- **PipeController**

  使管道移动

- **Pipline**

  控制多个管道在Y轴随机产生

- **StartGame**

  控制start button的脚本，使其实现点击就切换到主游戏的场景

- **RestartGame**

  控制restart button的脚本，使其实现点击就切换到主游戏的场景

  **最终效果：**

  <video src="./media/single.mp4"></video>

# Flappybirds

**双人版flappy bird** 

**改进功能**:

1. 一只鸟改成两只鸟一前一后一起往前飞
2. 每只鸟通过计一分，两只都通过后额外加两分
3. 一只死亡后另一只可以继续飞，但只计一分
4. 两只都死亡，才算游戏结束
5. 通过的音效根据鸟的数量来播放

直接复制原来的鸟，为了区别两只鸟，将第二只鸟颜色改变了下。为了实现两只鸟的计分和播放音效功能，在tag为addscore的管子添加计分脚本。通过判断在该根管子上通过鸟的个数来加分和播放音效。

在游戏控制脚本GamePlayer加全局静态变量die1和die2来记录两只鸟的死亡，在控制鸟的脚本BirdController中修改对应的值，当两只鸟都死后调用才GamOver方法。

bird作为预制件，用GamePlayer统一管理。

  **最终效果：**

<video src="./media/double.mp4"></video>