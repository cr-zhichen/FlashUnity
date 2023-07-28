using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// 数据保存与加载管理器 必须使用[Serializable]标记需要保存的数据类
/// </summary>
public static class SaveLoadManager
{
    
    /// <summary>
    /// 保存数据
    /// </summary>
    /// <param name="data">需要保存的数据</param>
    /// <param name="fileName">文件保存的名称</param>
    /// <typeparam name="T">需要保存数据的类型</typeparam>
    /// <returns></returns>
    public static void Save<T>(T data, string fileName) where T : class
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(Path.Combine(Application.persistentDataPath, fileName), FileMode.Create);

        try
        {
            formatter.Serialize(stream, data);
        }
        catch (Exception e)
        {
            Debug.LogError("保存数据失败 " + e.Message);
        }
        finally
        {
            stream.Close();
        }
    }

    /// <summary>
    /// 加载数据
    /// </summary>
    /// <param name="fileName">需要加载数据的文件名</param>
    /// <typeparam name="T">需要加载数据的类型</typeparam>
    /// <returns>获取到的保存数据</returns>
    public static T Load<T>(string fileName) where T : class
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        if (!File.Exists(path))
        {
            Debug.LogError("未能找到文件 " + path);
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        try
        {
            T data = (T)formatter.Deserialize(stream);
            return data;
        }
        catch (Exception e)
        {
            Debug.LogError("加载数据失败 " + e.Message);
            return null;
        }
        finally
        {
            stream.Close();
        }
    }
}