using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudControl : MonoBehaviour 
{
	public float moveSpeed = 3f;

    void Start () 
    {
        moveSpeed = Random.Range(.5f, 2f);

        // spawn clouds behind moutians 50% of the time
        int rand = Random.Range(1,101);
        if (rand % 2 == 0) 
        {
            GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = -12;
        }
	}
	
	void Update () 
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
	}
}
