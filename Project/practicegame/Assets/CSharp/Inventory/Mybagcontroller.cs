using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/// <summary>
/// 实现拖拽，物品的使用
/// </summary>
public class Mybagcontroller : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public BagClass MyBag;
    private Transform StartPosition;
    

    public void OnBeginDrag(PointerEventData eventData)
    {
        StartPosition.position = transform.position;
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts=false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        //if (eventData.pointerCurrentRaycast.gameObject.name == "useprop")
        //{
        //    //Destroy(this.gameObject);
        //    //DragItemnumber--;
        //    StartPosition.position = transform.position;
        //    GetComponent<CanvasGroup>().blocksRaycasts = true;
        //}
     
    }
}
