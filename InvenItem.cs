using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Money, Heart, Weapon, Shild, PlusHeart
}

[Serializable]
public class InvenItem
{
    public ItemType itemType;
    public string itemName;
    public int itemValue;

    
    public Sprite itemImage;
    public Player_knights player;
    

    public bool Use()
    {
        if (itemImage == null)
            return false;

        bool isUsed = false;

        if(player.hasWeaponValue[itemValue % 2] != -1)
        {
            if(itemValue %2 == 0 )
                Inventory.instance.AddItem(player.hasWeaponValue[0]);
            else
                Inventory.instance.AddItem(player.hasWeaponValue[1]);
        }

        if (itemValue % 2 == 0)
        {
            player.hasWeapons[0] = true;
            player.hasWeaponValue[0] = itemValue;

        }
        else
        {
            player.hasWeapons[1] = true;
            player.hasWeaponValue[1] = itemValue;
        }

        isUsed = true;

        return isUsed;
    }

    public void Init()
    {
        itemImage = Resources.Load<Sprite>($"WeaponSprite/{itemName}");
        player = Player_knights.instance;
    }
}
