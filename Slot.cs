using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,IPointerUpHandler,IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    public int slotnum;
    public InvenItem invenItem;
    public Image itemIcon;
    public Vector2 itemPosition;


    private void Awake()
    {
        invenItem.player = Player_knights.instance;
    }
    public void UpdateSlotUI()
    {        
        itemIcon.sprite = invenItem.itemImage;
        itemIcon.gameObject.SetActive(true);

    }

    public void RemoveSlot()
    {
        invenItem = null;
        itemIcon.gameObject.SetActive(false);
    }

    // PointerUp -> Drop -> EndDrag 순으로 작동되는거 확인

    public void OnPointerUp(PointerEventData eventData)
    {
        if (SlotDragEvent.Slot.MouseState != Define.MouseState.Click)
            return;
        
        if (this.invenItem==null)
            return;

        bool isUse = invenItem.Use();
        if(isUse)
        {
            Inventory.instance.RemoveItem(slotnum);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {        
        SlotDragEvent.Slot.MouseState = Define.MouseState.Drag;

        if (this.invenItem == null)
        {
            SlotDragEvent.Slot.MouseState = Define.MouseState.Click;
            return;
        }
            

        SlotDragEvent.Slot.DragImage.gameObject.SetActive(true);
        SlotDragEvent.Slot.DragImage.sprite = itemIcon.sprite;
        SlotDragEvent.Slot.DragImage.transform.position = eventData.position;

        ChangeAlpha(0.5f);

        SlotDragEvent.Slot.DragSlot = this;
        // 시작 오브젝트의 invenitem 정보 받기
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(SlotDragEvent.Slot.MouseState != Define.MouseState.Drag)
            return;
        SlotDragEvent.Slot.DragImage.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (SlotDragEvent.Slot.MouseState != Define.MouseState.Drag)
            return;
        SlotDragEvent.Slot.MouseState = Define.MouseState.Click;
        SlotDragEvent.Slot.DragImage.gameObject.SetActive(false);
        SlotDragEvent.Slot.DragImage.sprite = null;
        SlotDragEvent.Slot.DragSlot = null;
        
        ChangeAlpha(1f);

        Player_knights.instance.inventory.onChangeItem();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (SlotDragEvent.Slot.DragSlot == null || this.invenItem==null)
            return;
        
        SlotDragEvent.Slot.ChangeSlotItem(this);
        
    }

    public void ChangeAlpha(float f)
    {
        Color color = itemIcon.color;
        color.a = f;
        itemIcon.color = color;
    }
}
