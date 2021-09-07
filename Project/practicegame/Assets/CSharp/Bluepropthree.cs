using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bluepropthree : MonoBehaviour
{
    //高级饥饿蓝瓶
    public AudioClip audioeat;




    /// <summary>
    /// 拾取高级饥饿蓝瓶
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
        if (pc != null)
        {
            MusicManager.instance.PlayMusic(audioeat);
            pc.EmendationHunger(10);
            Destroy(this.gameObject);
        }

    }
}
