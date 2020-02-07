using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;
    public float smoothing;

    private Vector2 halfLength;
    private Vector2 maxPosition;
    private Vector2 minPosition;
    public BoxCollider2D boundBox;
    private Vector3 camOffset;

    private Animator anim;
    public VectorValue camOffsetStorage;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        halfLength.y = Camera.main.orthographicSize;
        halfLength.x = ((float) Screen.width / Screen.height) * halfLength.y;
        SetCamBounds(camOffsetStorage.initialValue);
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x,
                                                 target.position.y,
                                                 transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x,
                                           minPosition.x + halfLength.x,
                                           maxPosition.x - halfLength.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,
                                           minPosition.y + halfLength.y,
                                           maxPosition.y - halfLength.y);
            
            transform.position = Vector3.Lerp(transform.position,
                                             targetPosition, smoothing *Time.deltaTime);
            //transform.position = Vector3.Lerp(transform.position,
            //                                 targetPosition, smoothing);
        }
    }

    public void SetCamBounds(Vector3 offset) {
        Debug.Log("min" + boundBox.bounds.min);
        Debug.Log("max" + boundBox.bounds.max);
        camOffset += offset;
        minPosition = camOffset + boundBox.bounds.min;
        maxPosition = camOffset + boundBox.bounds.max;
    }
    // private Vector3 RoundPosition(Vector3 position)
    // {
    //     float xOffset = position.x % .0625f;
    //     if(xOffset != 0)
    //     {
    //         position.x -= xOffset;
    //     }
    //     float yOffset = position.y % .0625f;
    //     if(yOffset != 0)
    //     {
    //         position.y -= yOffset;
    //     }
    //     return position;
    // }

    public void BeginKick(){
        anim.SetBool("shake",true);
        StartCoroutine(EndKick());
    }

    IEnumerator EndKick() {
        yield return null;
        anim.SetBool("shake",false);

    }
}