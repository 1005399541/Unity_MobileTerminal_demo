using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SenceManager: MonoBehaviour
{
    //关卡总界面
 



    /// <summary>
    /// 到一关
    /// </summary>
    public void Startlevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    /// <summary>
    /// 到第二关
    /// </summary>
    public void Startlevel2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        


    }
    /// <summary>
    /// 到第三关
    /// </summary>
    public void Startlevel3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
     


    }
}
