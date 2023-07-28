using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对象池（需实例化）
/// </summary>
public class ObjectPool<T> where T : Component
{
    private List<T> pool;
    private T prefab;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="prefab">需要实例化的预制体</param>
    /// <param name="size">需要创建对象池的大小</param>
    public ObjectPool(T prefab, int size)
    {
        this.prefab = prefab;
        pool = new List<T>();

        // 初始化对象池
        for (int i = 0; i < size; i++)
        {
            T obj = Object.Instantiate(prefab);
            obj.gameObject.SetActive(false);
            pool.Add(obj);
        }
    }

    /// <summary>
    /// 获取一个对象
    /// </summary>
    /// <returns></returns>
    public T Get()
    {
        foreach (T obj in pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        // 如果对象池中所有对象都在使用中，创建一个新的对象并添加到池中
        T newObj = Object.Instantiate(prefab);
        newObj.gameObject.SetActive(true);
        pool.Add(newObj);
        return newObj;
    }

    /// <summary>
    /// 返还一个对象
    /// </summary>
    /// <param name="obj">需要返还的对象</param>
    /// <returns></returns>
    public void Return(T obj)
    {
        obj.gameObject.SetActive(false);
    }
}