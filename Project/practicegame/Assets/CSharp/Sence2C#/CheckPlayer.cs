using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(GameObject.Find("Player"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("找到");
        }
    }
}
