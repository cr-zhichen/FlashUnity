using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音频管理器
/// </summary>
public class AudioManager : Singleton<AudioManager>
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    /// <summary>
    /// 背景音乐
    /// </summary>
    private Dictionary<string, AudioClip> musicClips = new Dictionary<string, AudioClip>();

    /// <summary>
    /// 音效
    /// </summary>
    private Dictionary<string, AudioClip> sfxClips = new Dictionary<string, AudioClip>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// 添加音乐
    /// </summary>
    /// <param name="name"></param>
    /// <param name="clip"></param>
    public void AddMusic(string name, AudioClip clip)
    {
        musicClips.TryAdd(name, clip);
    }

    /// <summary>
    /// 添加音效
    /// </summary>
    /// <param name="name"></param>
    /// <param name="clip"></param>
    public void AddSfx(string name, AudioClip clip)
    {
        sfxClips.TryAdd(name, clip);
    }

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="name"></param>
    /// <param name="volume"></param>
    /// <param name="loop"></param>
    public void PlayMusic(string name, float volume = 1f, bool loop = true)
    {
        if (musicClips.TryGetValue(name, out var clip))
        {
            musicSource.clip = clip;
            musicSource.volume = volume;
            musicSource.loop = loop;
            musicSource.Play();
        }
    }

    /// <summary>
    /// 停止播放背景音乐
    /// </summary>
    public void StopMusic()
    {
        musicSource.Stop();
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="name"></param>
    /// <param name="volume"></param>
    public void PlaySfx(string name, float volume = 1f)
    {
        if (sfxClips.TryGetValue(name, out var clip))
        {
            sfxSource.PlayOneShot(clip, volume);
        }
    }

    /// <summary>
    /// 停止播放所有音效
    /// </summary>
    public void StopAllSfx()
    {
        sfxSource.Stop();
    }
}