/*****************************************

    文件：LogToFile.cs
    作者：张程瑞
    日期：2023-08-10T11:06:02+08:00
    描述：在Unity编译打包后，将Log保存到文件中

******************************************/

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// 保存Log
/// </summary>
public class LogToFile : Singleton<LogToFile>
{
    private string logDirectoryPath;
    private string logFilePath;
    private string logLevel; //日志等级 none debug warn error

#if !UNITY_EDITOR
    public void Init()
    {
        DontDestroyOnLoad(this);

        logLevel = ReadConfig.configData.logLevel;

        // 创建保存日志的目录路径
        logDirectoryPath = Path.Combine(Application.dataPath, "Log");
        if (!Directory.Exists(logDirectoryPath))
        {
            Directory.CreateDirectory(logDirectoryPath);
        }

        // 使用时间戳命名日志文件
        string timeStamp = System.DateTime.Now.ToString("yyyyMMddHHmmss");
        logFilePath = Path.Combine(logDirectoryPath, $"{timeStamp}_gameLog.txt");

        // 添加日志回调
        Application.logMessageReceived += HandleLog;

        base.Awake();
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        // 根据日志等级判断是否保存
        if (ShouldLog(type))
        {
            // 将日志保存到文件中
            File.AppendAllText(logFilePath, $"[{type}] {logString}\n{stackTrace}\n\n");
        }
    }

    private bool ShouldLog(LogType type)
    {
        switch (logLevel)
        {
            case "none":
                return false;
            case "error":
                return type == LogType.Error || type == LogType.Exception;
            case "warn":
                return type == LogType.Warning || type == LogType.Error || type == LogType.Exception;
            case "debug":
                return true; // debug级别保存所有日志
            default:
                return false;
        }
    }

    private void OnDestroy()
    {
        // 当对象被销毁时，移除日志回调
        Application.logMessageReceived -= HandleLog;
    }
#else
    public void Init()
    {
        Destroy(gameObject);
    }
#endif
}