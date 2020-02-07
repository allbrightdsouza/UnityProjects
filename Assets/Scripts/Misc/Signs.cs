using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Signs : Interactable
{   
    [Header("Sign Variables")]
    public GameObject dialogBox;
    public Text dialogText;
    [TextArea]
    public string dialogString;
    private string[] dialogLines;
    private int curLine;

    void Start() {
        curLine = 0;
        dialogLines = dialogString.Split('\n');
    }
    override public void OnInteract() {
        if(dialogBox.activeInHierarchy) {
            if(curLine < dialogLines.Length) {
                dialogText.text = dialogLines[curLine++];
            } else 
            {
                dialogBox.SetActive(false);            
            }
        } else {
            dialogBox.SetActive(true);
            dialogText.text = dialogLines[curLine++];
        }
        
    }

    override public void DoOnEnter() {
    }

    override public void DoOnExit() {
        dialogBox.SetActive(false);

    }
}
