using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip _HeroATKClip;
    public AudioClip _HeroHurtClip;

    private AudioSource _AudioSource;

    private void Awake()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 播放音效_音频源A
    /// </summary>
    /// <param name="audioClip">音频剪辑</param>
    public void PlayAudio(AudioClip audioClip)
    {
        if (audioClip)
        {
            _AudioSource.clip = audioClip;
            _AudioSource.Play();
        }
        else
        {
            Debug.Log("该音频文件不存在");
        }
    }
}
