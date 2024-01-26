using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Serializable]
    public class Item
    {
        public int ID;
        public string Name;
        public Sprite Image;
    }

    public List<Item> Items;
}
