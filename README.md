# FlashUnity

Unity游戏开发的快速开启框架

## Assets结构

``` shell
.
├── Animations # 此文件夹存放所有的动画文件和动画控制器
├── Audio # 此文件夹用于存放音频文件，如音效和背景音乐
├── Editor # 这个文件夹用于存放编辑器脚本，这些脚本只在Unity编辑器中运行
├── Materials # 这个文件夹用于存放材质文件，这些文件用于定义物体的表面属性
├── Models # 此文件夹存放所有的3D模型
├── Plugins # 这个文件夹用于存放Unity项目所需的各种插件
├── Prefabs # 此文件夹存放预设文件，预设可以被视为自定义的游戏对象模板
├── Resources # 这个文件夹用于存放通过Resources类动态加载的资源
├── Scenes # 此文件夹用于存放所有的场景文件
├── Scripts # 此文件夹用于存放所有的脚本文件
├── Settings # 这个文件夹用于存放项目的设置文件
├── Shaders # 这个文件夹用于存放渲染物体所用的着色器代码
├── StreamingAssets # 这个文件夹用于存放在运行时需要被读取的文件，例如视频文件
├── Textures # 此文件夹用于存放所有的纹理文件，如用于3D模型的表面的图片
└── UI # 这个文件夹用于存放所有与用户界面相关的文件，如按钮和文本框
```

## 插件列表

- [x] [DOTween](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676)
- [x] [UniRx](https://assetstore.unity.com/packages/tools/integration/unirx-reactive-extensions-for-unity-17276)
- [x] [RestClient](https://assetstore.unity.com/packages/tools/network/rest-client-for-unity-102501)

## 工具类

### 通用工具类

通用工具类在`Assets/Scripts/Utils`目录下

``` shell
.
├── Expand.cs # 扩展方法
├── IntervalRequest.cs # 间隔请求
├── ObjectPool.cs # 对象池
├── ResourceLoader.cs # 资源加载器
└── SceneSwitcher.cs # 场景切换器
```

### 事件管理器

事件管理器在`Assets/Scripts/Event`目录下

``` shell
.
├── EventCenter.cs # 事件中心
└── eNventType.cs # 事件类型
```

### 通用基类

通用基类在`Assets/Scripts/BaseClass`目录下

``` shell
.
└── Singleton.cs # 单例基类
```