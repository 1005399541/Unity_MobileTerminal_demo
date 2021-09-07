using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverSenceManager : MonoBehaviour
{
  //游戏结束时的场景


   /// <summary>
   /// 返回游戏界面
   /// </summary>
   public void ReturnSence()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-4);
    }
    /// <summary>
    /// 返回游戏场景
    /// </summary>
    public void ReturnStartSence()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -5);
    }
    /// <summary>
    /// 退出游戏
    /// </summary>
    public void Quitgame()
    {
        Application.Quit();
    }
}
