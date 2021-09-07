using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    //管理声音的单例模式1



    private AudioSource audioSource;

    public static MusicManager instance { get; private set; }

    private void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }






    /// <summary>
    /// 播放声音文件
    /// </summary>
    public void PlayMusic(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }


}
