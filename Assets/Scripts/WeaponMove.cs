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

        weapon.transform.position = Vector2.MoveTowards(weapon.transform.position, goalPos, moveSpeed * Time.deltaTime);
	}
}
