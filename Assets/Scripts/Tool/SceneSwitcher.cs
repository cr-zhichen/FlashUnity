using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 切换场景
/// </summary>
public static class SceneSwitcher
{
    /// <summary>
    /// 切换场景
    /// </summary>
    /// <param name="sceneName">场景名称</param>
    /// <returns></returns>
    public static void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// 切换场景
    /// </summary>
    /// <param name="sceneIndex">场景ID</param>
    /// <returns></returns>
    public static void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// 重新加载当前的场景
    /// </summary>
    /// <returns></returns>
    public static void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}