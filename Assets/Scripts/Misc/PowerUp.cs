using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public Signal powerUpSignal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public abstract void DoOnTrigger() ;
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D target) {
        if(target.CompareTag("Player") && !target.isTrigger) {
            DoOnTrigger();
            powerUpSignal.Raise();
            Destroy(gameObject);
        }
    }
}
