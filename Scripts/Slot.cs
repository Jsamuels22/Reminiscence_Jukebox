﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    public GameObject Item
    {


        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0). gameObject;

            }
            return null;
        }


    }


    //#region IDropHandler implementation
    //public void OnDrop(PointerEventData eventData)
    //{
    //    if(!Item)
    //    {
    //        DragAndDrop.itemBeingDragged.transform.SetParent(transform);
    //    }
    //}
    //#endregion
}