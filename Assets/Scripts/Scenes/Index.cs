using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Index : Singleton<Index>
{
    public Button switchSceneBtn;

    private void Awake()
    {
        Debug.Log("进入首页场景");
        switchSceneBtn
            .OnClickAsObservable()
            .Subscribe(_ =>
            {
                Observable
                    .FromCoroutine(_ => LoadSceneAsync("Game"))
                    .Subscribe();
            });
    }

    /// <summary>
    /// 异步加载场景
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        // 监听进度
        while (asyncOperation.progress < 0.9f)
        {
            Debug.Log($"加载进度：{asyncOperation.progress}");
            yield return null;
        }

        asyncOperation.allowSceneActivation = true;

        // 等待加载完成
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        Debug.Log("场景已加载。");
    }
}