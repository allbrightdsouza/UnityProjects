using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public Signal contextSignal;
    public bool playerInRange;
    public bool canInteract = true;
    abstract public void OnInteract();
    abstract public void DoOnEnter();
    abstract public void DoOnExit();
    // Start is called before the first frame update
    void Awake() {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange && canInteract) {
            if(Input.GetButtonDown("Interact"))
                OnInteract();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger && canInteract)
        {
            playerInRange = true;
            contextSignal.Raise();
            DoOnEnter();
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger )
        {
            playerInRange = false;
            if(canInteract) {
                contextSignal.Raise();
                DoOnExit();
            }
        }
    }
}
