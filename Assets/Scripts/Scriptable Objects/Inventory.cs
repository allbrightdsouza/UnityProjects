using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items;
    public int noOfKeys;
    public int noOfCoins;

    public void AddItem(Item itemToAdd) {
        if(itemToAdd.isKey) {
            ++noOfKeys;
        } else {
            if( !items.Contains(itemToAdd)) {
                items.Add(itemToAdd);
            }
        }
    }
}
