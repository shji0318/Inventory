using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    public ItemData itemData;
    public List<InvenItem> itemDB = new List<InvenItem>();

    [Serializable]
    public class ItemData
    {
        public List<InvenItem> items = new List<InvenItem>();
    }
    
    
    
    private void Awake()
    {
        if(instance ==null)
            instance = this;

        TextAsset textAsset = Resources.Load<TextAsset>("Data/itemData");
        ItemData itemData = JsonUtility.FromJson<ItemData>(textAsset.text);
        itemDB = itemData.items;

        foreach (InvenItem iv in itemDB)
            iv.Init();
    }
    
}
