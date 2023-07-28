using UnityEngine;

/// <summary>
/// 从Resources文件夹中加载资源
/// </summary>
public static class ResourceLoader
{
    // 加载单个资源
    public static T LoadResource<T>(string path) where T : Object
    {
        T resource = Resources.Load<T>(path);
        if(resource == null)
        {
            Debug.LogError("加载资源失败 " + path);
        }
        return resource;
    }

    // 加载多个资源
    public static T[] LoadAllResources<T>(string path) where T : Object
    {
        T[] resources = Resources.LoadAll<T>(path);
        if(resources == null || resources.Length == 0)
        {
            Debug.LogError("加载资源失败 " + path);
        }
        return resources;
    }
}