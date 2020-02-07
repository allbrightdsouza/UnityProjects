using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
    walk,
    attack,
    interact,
    stagger
}

public enum LastAxis {
    none, 
    horizonatal,
    vertical
}

public class PlayerMovement : MonoBehaviour {


    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;
    public VectorValue startingPosition;
    public VectorValue startingDirection;
    public Inventory playerInventory;

    public LastAxis curAxis;
    public SpriteRenderer itemSprite;
    public Signal screenShake;

	// Use this for initialization
	void Start () {
        currentState = PlayerState.walk;
        curAxis = LastAxis.none;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        // animator.SetFloat("moveX", 0);
        // animator.SetFloat("moveY", -1);
        transform.position = startingPosition.initialValue;
        animator.SetFloat("moveX", startingDirection.initialValue.x);
        animator.SetFloat("moveY", startingDirection.initialValue.y);
	}
	
	// Update is called once per frame
	void Update () {
        if(currentState == PlayerState.interact) 
            return;
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("Attack") && currentState != PlayerState.attack 
           && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk )
        {
            UpdateAnimationAndMove();
        }
	}

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    public void RaiseItem() {

        if(playerInventory.currentItem != null) {
            if(currentState == PlayerState.interact) {
                animator.SetBool("pickUp",false);
                currentState = PlayerState.walk;
                itemSprite.sprite = null;
                playerInventory.currentItem = null;

            } else {
                animator.SetBool("pickUp",true);
                currentState = PlayerState.interact;
                itemSprite.sprite = playerInventory.currentItem.sprite;
            }
        }
    }
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            if(curAxis == LastAxis.none) {
                if(change.x != 0) {
                    curAxis = LastAxis.horizonatal;
                } 
                if(change.y != 0) {
                    curAxis = LastAxis.vertical;
                }
            } else {
                if(!(change.x != 0 && change.y != 0)) {
                    if(change.x != 0) 
                        curAxis = LastAxis.horizonatal;
                    else 
                        curAxis = LastAxis.vertical;
                }
            }

            if(curAxis == LastAxis.horizonatal) {
                animator.SetFloat("moveX", change.x);
                animator.SetFloat("moveY", 0);
            }
            else {
                animator.SetFloat("moveX", 0);
                animator.SetFloat("moveY", change.y);
            }
            animator.SetBool("walking", true);
            
        }
        else
        {
            animator.SetBool("walking", false);
            curAxis = LastAxis.none;
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }

    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        screenShake.Raise();
        if (currentHealth.RuntimeValue > 0)
        {

            StartCoroutine(KnockCo(knockTime));
        }else{
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.walk;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}