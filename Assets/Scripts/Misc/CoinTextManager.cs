using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTextManager : MonoBehaviour
{
    public TMP_Text text;
    public Inventory playerInventory;
    // Start is called before the first frame update
    void Start() {
        text.text = playerInventory.noOfCoins.ToString();
    }
    public void UpdateCoinCount() {
        text.text = playerInventory.noOfCoins.ToString();
    }
}
