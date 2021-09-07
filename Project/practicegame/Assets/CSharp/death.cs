using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    //死亡

    public AudioClip audiodeath;//死亡声音文件

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
        if (pc != null)
        {
            MusicManager.instance.PlayMusic(audiodeath);
            Invoke("PlayerDeath", 2f);
        }
    }
    public void PlayerDeath()
    {
        SceneManager.LoadScene("GameOverSence");
        
    }
}
