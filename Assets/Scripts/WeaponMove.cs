using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour 
{
	public GameObject weapon;
    public bool leftGun;
    public float moveSpeed = 2f;
    public float topPos = 4f;
	public float bottomPos = -4f;
    public Vector2 goalPos = Vector2.zero;

    void Start()
    {
        goalPos = weapon.transform.position; 
        goalPos.y = leftGun ? topPos : bottomPos; 
    }

	void Update () 
    {
		/// MOVE
        if (weapon.transform.position.y == topPos)
        {
            goalPos.y = bottomPos;
        }  
        if (weapon.transform.position.y == bottomPos)
        {
            goalPos.y = topPos;
        }         

        moveSpeed += Input.GetAxis("Vertical");        
        if (moveSpeed >= 10f) { moveSpeed = 10f; }
        if (moveSpeed <= 0f) { moveSpeed = 1f; }

        // if (leftGun)
        // {
        //     if (Input.GetKey("a"))
        //     {
        //         weapon.transform.Translate(new Vector2 (-Input.GetAxis("Vertical"), 0) * moveSpeed * Time.deltaTime);
        //         //weapon.transform.position = Vector2.MoveTowards(weapon.transform.position, goalPos, moveSpeed * Time.deltaTime);
        //         // @TODO light up, show can move
        //     }
        // }

        // if (!leftGun)
        // {
        //     if (Input.GetKey("d"))
        //     {
        //         weapon.transform.Translate(new Vector2 (Input.GetAxis("Vertical"), 0) * moveSpeed * Time.deltaTime);
        //         //weapon.transform.position = Vector2.MoveTowards(weapon.transform.position, goalPos, moveSpeed * Time.deltaTime);
        //     }
        // }
        
        weapon.transform.position = Vector2.MoveTowards(weapon.transform.position, goalPos, moveSpeed * Time.deltaTime);

	}
}
