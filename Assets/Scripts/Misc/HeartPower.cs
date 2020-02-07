using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPower : PowerUp
{
    public FloatValue playerHealth;
    public FloatValue heartContainers;
    public float amountToIncrease;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DoOnTrigger() {
        playerHealth.RuntimeValue += amountToIncrease;
        if(playerHealth.RuntimeValue/2 >= heartContainers.RuntimeValue) {
            playerHealth.RuntimeValue = heartContainers.RuntimeValue * 2;
        }
    }
}
