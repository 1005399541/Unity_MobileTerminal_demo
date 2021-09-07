using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTwoPlayer : MonoBehaviour
{


    public GameObject UIManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Player"))
        {
            UIManager.gameObject.SetActive(true);
            Debug.Log("找到");
        }
    }
}
