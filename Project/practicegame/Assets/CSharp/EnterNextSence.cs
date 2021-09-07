using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterNextSence : MonoBehaviour
{
    //通过房子进入下一个场景
   

    private void Start()
    {
      
    }
    /// <summary>
    /// 碰撞检测
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
        if (pc != null)
        {
           

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            pc.transform.localPosition = new Vector3(-8,5,0);
           
        }
    }
}
