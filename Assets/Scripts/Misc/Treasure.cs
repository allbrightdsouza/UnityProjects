using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure : Interactable
{
    [Header("Treasure Variables")]

    public GameObject dialogBox;
    public Text dialogText;
    [TextArea]
    private string[] dialogLines;
    private int curLine;
    private Animator anim;

    public Signal itemReceived;

    public Item itemInside;
    public Inventory playerInventory;
    void Start() {
        anim = GetComponent<Animator> ();
    }
    override public void DoOnEnter () {
    }    
    override public void OnInteract () {
        if(dialogBox.activeInHierarchy) {
            if(curLine < dialogLines.Length) {
                dialogText.text = dialogLines[curLine++];
            } else 
            {
                dialogBox.SetActive(false);  
                //Lower animation
                itemReceived.Raise();
                canInteract = false;
            }
        } else {
            //Open box animation
            anim.SetBool("open",true);
            //update inventory
            playerInventory.currentItem = itemInside;
            playerInventory.AddItem(itemInside);
            //Remove Question mark
            contextSignal.Raise();
            //Setup dialog
            dialogLines = itemInside.description.Split('\n');
            curLine = 0;
            dialogText.text = dialogLines[curLine++];
            dialogBox.SetActive(true);

            //Player animation and item visual
            itemReceived.Raise();
        }
    }
    override public void DoOnExit () {
    }    
}
