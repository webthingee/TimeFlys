// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMovement : MonoBehaviour 
{
    public float moveSpeed = 2f;
    public LayerMask wall;

    public Vector2 currentDirection = Vector2.zero;
    public Vector2 changeDirection = Vector2.zero;
    public Vector2 goalPos = Vector2.zero;
    public Vector2 leavingPos = Vector2.zero;

    private void Update()
    {
        /// INPUT
        if (Input.GetAxis("Vertical") > 0f)
        {
            changeDirection = Vector2.up;
        }
        if (Input.GetAxis("Horizontal") > 0f)
        {
            changeDirection = Vector2.right;
        }
        if (Input.GetAxis("Vertical") < 0f)
        {
            changeDirection = Vector2.down;
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            changeDirection = Vector2.left;
        }
        
        /// MOVE
        if ((Vector2)transform.position == goalPos)
        {
            if (!DirectionBlocked(changeDirection))
            {
                currentDirection = changeDirection;
            }
            goalPos = goalPos + currentDirection;

        }        
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, goalPos, moveSpeed * Time.deltaTime);
        }
    }

    private bool DirectionBlocked (Vector2 _direction)
    {
        var rayStart = transform.position;
        var rayDir = _direction;
        float rayDist = 1f;

        Debug.DrawRay(rayStart, rayDir * rayDist, Color.green);

        return Physics2D.Raycast(rayStart, rayDir, rayDist, wall);
        // RaycastHit2D[] hits = Physics2D.RaycastAll(rayStart, rayDir, rayDist);
        // {
        //     if (hits.Length > 1)
        //     {
        //         foreach (RaycastHit2D hit in hits)
        //         {
        //             if (1 << hit.collider.gameObject.layer == wall)
        //                 return true;
        //         }
        //     }
        // }
        // return false;
    }

    // private void OnCollisionEnter2D(Collision2D _other)
    // {
    //     if (gameObject.tag == "Player")
    //     {
    //         foreach (ContactPoint2D hit in _other.contacts)
    //         {
    //             GameObject other = hit.collider.gameObject;
    //             if (other.transform.position != transform.position)
    //             {
    //                 GridMovement gridMovement = other.GetComponent<GridMovement>();
    //                 if (other.GetComponent<Hero>())
    //                 {
    //                     if (gridMovement.enabled == false)
    //                     {
    //                         other.transform.parent = this.transform.parent;
    //                         gridMovement.enabled = true;
    //                         gridMovement.goalPos = transform.position;
    //                     }
    //                     else
    //                     {
    //                         break;
    //                     }
    //                 }
    //                 else
    //                 {
    //                     Vector3Int cell = obstacleMap.WorldToCell(hit.point + currentDirection);
    //                     Debug.Log(obstacleMap.GetTile(cell).name);
    //                     if (obstacleMap.GetTile(cell).name != null)
    //                     {
    //                         var children = transform.parent.childCount - 1;
    //                         for (int i = children; i > -1; i--)
    //                         {
    //                             transform.parent.GetChild(i).GetComponent<Character>().Death();
    //                         }
    //                     } 
    //                 }
    //             }
    //         }   
    //     }
    // }
}
