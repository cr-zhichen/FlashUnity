using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

/// <summary>
/// 定时器请求
/// </summary>
public class IntervalRequest : Singleton<IntervalRequest>
{
    // 定义一个事件，当定时结束后触发
    public event Action OnTimeElapsed;

    //是否自动调用
    public bool autoStart = true;

    // 定时器的默认时间
    public float defaultSeconds = 60f;

    // 每个委托调用之间的延迟
    public float delayBetweenInvocations = 0.001f;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        StartCoroutine(Timer(defaultSeconds));
    }

    public IEnumerator Timer(float seconds)
    {
        do
        {
            yield return new WaitForSeconds(0.1f);
            Debug.Log("触发定时器，调用所有委托");
            if (OnTimeElapsed != null)
            {
                foreach (var handler in OnTimeElapsed.GetInvocationList())
                {
                    try
                    {
                        ((Action)handler)?.Invoke();
                    }
                    catch (Exception e)
                    {
                        ("倒计时请求内存在错误:" + e.Message + "\n\n" + "堆栈跟踪信息：" + e.StackTrace).LogError();
                    }

                    // 在每个委托调用之后等待一段时间
                    yield return new WaitForSeconds(delayBetweenInvocations);
                }
            }

            yield return new WaitForSeconds(seconds -
                                            (OnTimeElapsed?.GetInvocationList().Length ?? 0) * delayBetweenInvocations);
        } while (autoStart);
    }

    /// <summary>
    /// 立即重置定时器，立即触发OnTimeElapsed事件
    /// </summary>
    public void ResetTimer()
    {
        StopAllCoroutines();
        StartCoroutine(Timer(defaultSeconds));
    }
}