using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType {
    key,
    enemy,
    button
}
public class Door : Interactable
{
    [Header("Door Variables")]
    public DoorType doorType;
    public bool open;

    public BoxCollider2D phyCollider;
    public Sprite doorSprite;
    private SpriteRenderer spriteRend;
    public Inventory playerInvetory;
    // Start is called before the first frame update
    void Start()
    {
        GameObject parent = transform.parent.gameObject;
        spriteRend = parent.GetComponent<SpriteRenderer>();
        phyCollider = parent.GetComponent<BoxCollider2D>();
    }

    override public void DoOnEnter() {

    }
    override public void DoOnExit() {

    }
    override public void OnInteract() {
        if(!open) {
            if(doorType == DoorType.key && playerInvetory.noOfKeys > 0 ) {
                spriteRend.sprite = null;
                phyCollider.enabled = false;
                open = true;
                playerInvetory.noOfKeys--;
            }
        } else {
            spriteRend.sprite = doorSprite;
            phyCollider.enabled = true;
            open = false;
            
            if(doorType == DoorType.key) 
            {
                
                playerInvetory.noOfKeys++;
            }
        }

    }

}
