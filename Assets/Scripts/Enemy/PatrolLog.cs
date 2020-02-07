using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : Log
{
    [Header("Patrol Points")]
    public Transform[] path;
    public int curPoint;
    public Transform curGoal;

    [Header("Fine Tuning")]
    public float roundingDistance;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        anim.SetBool("awake",true);
        curGoal = path[0];
        curPoint = 0;
    }

    // Update is called once per frame
    public override void CheckDistance()
    {
        if(Vector3.Distance(target.position, 
                            transform.position) <= chaseRadius
           && Vector3.Distance(target.position,
                               transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position,
                                                         target.position,
                                                         moveSpeed * Time.deltaTime);
                // changeAnim((temp - transform.position).normalized);
                SetAnimFloat((temp - transform.position).normalized);
                myRigidbody.MovePosition(temp);
                // ChangeState(EnemyState.walk);
                anim.SetBool("awake", true);
            }
        }else if (Vector3.Distance(target.position,
                            transform.position) > chaseRadius)
        {
            if(Vector2.Distance(transform.position,curGoal.position) > roundingDistance) {
                Vector3 temp = Vector3.MoveTowards(transform.position,
                                                            curGoal.position,
                                                            moveSpeed * Time.deltaTime);
                SetAnimFloat((temp - transform.position).normalized);
                myRigidbody.MovePosition(temp);
                anim.SetBool("awake", true);
            } else {
                ChangeGoal();
            }
        }
    }

    private void ChangeGoal() {
        if(curPoint == path.Length -1 ) {
            curPoint = 0;
            curGoal = path[0];
        }
        else 
        {
                curPoint++;
                curGoal = path[curPoint];
        }
    }
}
