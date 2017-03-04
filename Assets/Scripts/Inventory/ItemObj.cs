using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ItemObj : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler  {

    private Transform startParent;

    private CanvasGroup canvasGroup;

    private Tooltip tooltip;

    private bool inItem = false;

    private TooltipButton tooltipButton1;
    private TooltipButton tooltipButton2;

    private void Start()
    {
        startParent = transform.parent;
        canvasGroup = GetComponent<CanvasGroup>();

        tooltip = GameObject.FindGameObjectWithTag("Tooltip").GetComponent<Tooltip>();
        tooltipButton1 = GameObject.FindGameObjectWithTag("TooltipButton1").GetComponent<TooltipButton>();
        tooltipButton2 = GameObject.FindGameObjectWithTag("TooltipButton2").GetComponent<TooltipButton>();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            tooltip.ToggleTooltip(true, Input.mousePosition);
            tooltipButton1.actionMethod = DebugTest;
            tooltipButton2.actionMethod = DebugTest;

        }


    }

    private void DebugTest()
    {
        Debug.Log("We passed methods and used our tooltip");
    }
    private void GetItemChild()
    {

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        GetItemChild();


        transform.position = eventData.position;

        transform.SetParent(transform.parent.parent);

        //disable block raycast to fix highlight / mouseover issue
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {

        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetSlotInfo();
        canvasGroup.blocksRaycasts = true;


    }
    private void GetSlotInfo()
    {
        GameObject[] slots = GameObject.FindGameObjectsWithTag("Slot");

        foreach(var slot in slots)
        {
            if(slot.GetComponent<Slot>().isSelected == true)
            {
                //check is slot is not empty
                if(slot.transform.childCount >= 1)
                {
                    //Getting ItemObj from existing item slot
                    ItemObj otherItem = slot.transform.GetChild(0).GetComponent<ItemObj>();

                    //storing other object parent
                    Transform otherItemParent = otherItem.startParent;

                    //moving other item to our old parent position
                    otherItem.startParent = startParent;

                    //Set parent to new slot
                    startParent = otherItemParent;

                    otherItem.transform.SetParent(otherItem.startParent);
                    otherItem.transform.localPosition = Vector2.zero;
                }
                else
                {
                    startParent = slot.transform;
                }
                
                break;

            }
        }
        transform.SetParent(startParent);
        transform.localPosition = Vector2.zero;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        inItem = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inItem = false;
    }
}
