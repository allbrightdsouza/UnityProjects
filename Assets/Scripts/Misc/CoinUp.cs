using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinUp : PowerUp
{
    public Inventory playerInventory;
    public int amountToIncrease;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void DoOnTrigger() {
        playerInventory.noOfCoins += amountToIncrease;
    }
}
