using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSenceManager : MonoBehaviour
{
  //开始游戏场景的管理




    /// <summary>
    /// 进入游戏
    /// </summary>
    public void Startgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    /// <summary>
    /// 退出游戏
    /// </summary>
    public void Quitgame()
    {
        Application.Quit();
    }
}
