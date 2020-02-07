using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour {

    public GameObject contextClue;

    public bool curstate;
    public void SwitchState()
    {
        curstate = !curstate;
        contextClue.SetActive(curstate);
    }

}