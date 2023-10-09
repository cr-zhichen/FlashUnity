/*****************************************

    文件：ReadConfig.cs
    作者：张程瑞
    日期：2023-08-08T08:46:48+08:00
    描述：从Resource文件夹中读取配置文件

******************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
#if UNITY_EDITOR
using ParrelSync;
#endif
using UnityEngine;

/// <summary>
/// 读取配置文件
/// </summary>
public static class ReadConfig
{
    #region 变量

    public static ConfigData configData { get; private set; }

    #endregion

    #region 方法

    /// <summary>
    /// 初始化配置文件
    /// </summary>
    public static void Init()
    {
#if UNITY_EDITOR
        if (ClonesManager.IsClone())
        {
            string jsonData = ClonesManager.GetArgument();
            if (jsonData != null)
            {
                configData = JsonConvert.DeserializeObject<ConfigData>(jsonData);
            }
            else
            {
                Debug.LogError("读取配置文件失败");
            }
        }
        else
        {
            LoadConfigFromStreamingAssets();
        }
#else
        LoadConfigFromStreamingAssets();
#endif
    }

    private static void LoadConfigFromStreamingAssets()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "config.json"); // 假设你的文件是JSON格式的
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            configData = JsonConvert.DeserializeObject<ConfigData>(jsonData);
        }
        else
        {
            Debug.LogError("读取配置文件失败");
        }
    }

    #endregion

    #region 类

    public class ConfigData
    {
        public string logLevel { get; set; } = "none";
        public string UID { get; set; }
        public string wsUrl { get; set; }
        public string coreUrl { get; set; }

        public string localIp { get; set; }
        public int localPort { get; set; }
    }

    #endregion
}