using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotDragEvent : MonoBehaviour
{
    //---------------------------------------싱글톤----------------------------------------------------------------
    private static SlotDragEvent _instance;
    public static SlotDragEvent Slot { get => _instance; }
    //---------------------------------------싱글톤----------------------------------------------------------------

    //---------------------------------------변수 및 프로퍼티------------------------------------------------------

    [SerializeField]
    private Image _dragImage;

    Define.MouseState mouseState=Define.MouseState.Click;
    Slot _dragSlot;
    public Slot DragSlot { get => _dragSlot; set => _dragSlot = value; }
    public Define.MouseState MouseState { get => mouseState; set => mouseState = value; }
    public Image DragImage { get => _dragImage; set => _dragImage = value; }

    //---------------------------------------변수 및 프로퍼티------------------------------------------------------


    void Start()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        
    }

    public void ChangeSlotItem(Slot dropSlot)
    {
        InvenItem temp;
        temp = DragSlot.invenItem;
        DragSlot.invenItem = dropSlot.invenItem;
        dropSlot.invenItem = temp;

        Inventory.instance.items[DragSlot.slotnum] = DragSlot.invenItem;
        Inventory.instance.items[dropSlot.slotnum] = dropSlot.invenItem;
        
    }
}
