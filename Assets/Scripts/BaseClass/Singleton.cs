using UnityEngine;

/// <summary>
/// 单例模式 基类
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T) + " (Singleton)";

                    // 确保singleton实例跨场景持久存在
                    DontDestroyOnLoad(singletonObject);
                }
            }

            return _instance;
        }
    }
}