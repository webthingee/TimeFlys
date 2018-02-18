using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FlyMovement : MonoBehaviour 
{
	public float moveSpeed = 3f;
	public float animSpeed = 1f;
    public Animator animator;

    void Start () 
    {
        animator.SetFloat("AnimSpeed", animSpeed);
	}
	
	void Update () 
    {
        animator.SetFloat("AnimSpeed", animSpeed);
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
	}
}
