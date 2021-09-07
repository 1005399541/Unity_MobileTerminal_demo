using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWoridProp : MonoBehaviour
{

    //在世界里可以放入背包的物品（碰到自动放入背包）

    public BagClass MyBag;//放入的背包
    public Item OnWorldItem;//放入的物品

    public AudioClip audioeat;


    void Start()
    {
        
    }


    void Update()
    {
        //Debug.Log(MyBag.ItemList.Count);
    }



    /// <summary>
    ///  放入背包
    /// </summary>
    public void addProp()
    {
        if (!MyBag.ItemList.Contains(OnWorldItem))
        {
            for (int i = 0; i < MyBag.ItemList.Count; i++)
            { if (MyBag.ItemList[i] == null)
                {
                    MyBag.ItemList[i] = OnWorldItem;
                    Debug.Log("拾取物品");
                    Destroy(this.gameObject); return;
                }
            }
 
        }
        if (MyBag.ItemList.Contains(OnWorldItem))
        {
            OnWorldItem.Itemnumber += 1;
            Debug.Log("物品加一");
            Destroy(this.gameObject);
           
        }
        MusicManager.instance.PlayMusic(audioeat);
        InventoryManger.instance.RefreshBag();
    }




    /// <summary>
    ///  拾取物品
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();
        if (pc != null)
        {
          addProp();
        }
    }
}
