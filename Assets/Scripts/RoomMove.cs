using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour {

    public Vector3 cameraChange;
    public Vector3 playerChange;
    private GameObject camBox;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;
    private bool startFade;

	// Use this for initialization
	void Start () {
        cam = GameObject.FindObjectOfType<CameraMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(startFade) {
            TextFade();
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            cam.SetCamBounds(cameraChange);   
            other.transform.position += playerChange;
            if(needText)
            {
                StartCoroutine(placeNameCo());
            }

        }
    }

    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        Color temp = placeText.color;
        temp.a = 1;
        placeText.color = temp;
        startFade = false;
        yield return new WaitForSeconds(2f);
        startFade = true;

        yield return new WaitForSeconds(4f);
        startFade = false;
        text.SetActive(false);

    }

    void TextFade() {
        Color temp = placeText.color;
        temp.a -= Time.deltaTime;
        placeText.color = temp;
    }
}