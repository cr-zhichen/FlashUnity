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
                    Debug.LogError("场景中需要一个 " + typeof(T) + " 的实例，但没有找到");
                }
            }
            return _instance;
        }
    }
}