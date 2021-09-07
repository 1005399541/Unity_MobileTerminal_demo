using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueproTwo : MonoBehaviour
{
    //中级饥饿蓝瓶
    public AudioClip audioeat;





    /// <summary>
    /// 拾取中级饥饿蓝瓶
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
        if (pc != null)
        {
            MusicManager.instance.PlayMusic(audioeat);
            pc.EmendationHunger(5);
            Destroy(this.gameObject);
        }

    }
}
