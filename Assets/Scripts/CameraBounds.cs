using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //Half decent concept needs more thought
        // player = GameObject.FindGameObjectWithTag("Player");
        // Vector3 difference = player.transform.position - transform.position;
        // Debug.Log("pre Offset" + difference);

        // difference = new Vector3((int) (difference.x / 12.5), (int) (difference.y / 12.5) , 0);
        // Debug.Log("Offset" + difference);
        
        // Camera.main.GetComponent<CameraMovement>().SetCamBounds(difference*25);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
