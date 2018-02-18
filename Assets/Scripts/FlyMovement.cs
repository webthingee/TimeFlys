using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FlyMovement : MonoBehaviour 
{
	public float moveSpeed = 3f;
	public float animSpeed = 1f;
    public Animator animator;
    public Vector2 goalPos;
    public Vector2 newGoalPos;

    void Start () 
    {
        animSpeed = Random.Range(.5f, 2f);
        animator.SetFloat("AnimSpeed", animSpeed);
	}
	
	void Update () 
    {
        animator.SetFloat("AnimSpeed", animSpeed);
        //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        RandomFlyMovement();
	}

    public void RandomFlyMovement ()
    {
        /// MOVE
        if ((Vector2)transform.position == goalPos)
        {
            float i = Random.Range(-8, 8);
            float j = Random.Range(-4, 4);
            goalPos = new Vector2(i,j);

            animSpeed = Random.Range(.5f, 1.5f);
            moveSpeed = Random.Range(.5f, 2f);
        }

        transform.position = Vector2.MoveTowards(transform.position, goalPos, moveSpeed * Time.deltaTime);
    }
}
