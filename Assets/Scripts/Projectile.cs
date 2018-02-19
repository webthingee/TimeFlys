using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{
    public int projectileID = 1;

    public float projectileSpeed = 22f;
	public GameObject impactEffect;

    public bool canKillAny = false;
    public bool canNonStop = false;

    void Start()
    {
        Colorizer(projectileID);
    }

    void Update () 
	{
		transform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.tag == "Block")
        {
            if (canKillAny) // Any Color
            {
                GameObject explode = Instantiate(impactEffect, other.transform.position, Quaternion.identity);
                explode.GetComponent<SpriteRenderer>().color = GetIDColor(projectileID); 
                Destroy(other.gameObject);

                GameMaster.instance.score += 100;
            }
            else if (other.GetComponent<Block>().blockID == projectileID) // Same Color
            {
                GameObject explode = Instantiate(impactEffect, other.transform.position, Quaternion.identity);
                explode.GetComponent<SpriteRenderer>().color = GetIDColor(projectileID);
                Destroy(other.gameObject);

                GameMaster.instance.score += 100;
            }

            if (!canNonStop) // Destroy Bullet
                Destroy(this.gameObject);
        }

        if (other.tag == "Prize")
        {
            other.GetComponent<PrizeBox>().GetPrize();
            
            GameObject explode = Instantiate(impactEffect, other.transform.position, Quaternion.identity);
            explode.GetComponent<SpriteRenderer>().color = Color.gray;
            
            GameMaster.instance.score += 100;

            if (!canNonStop) // Destroy Bullet
                Destroy(this.gameObject);
        }
        // Component damageableComponent = other.gameObject.GetComponent(typeof(IDamageable)); // nullable value
		// if (other.tag != "Player")
		// {
		// 	if (damageableComponent)
		// 	{
		// 		(damageableComponent as IDamageable).TakeDamage();
		// 	}
		// 	//Impact();
		// }
	}

    void Colorizer (int _ID)
    {
        switch (_ID)
        {
            case 1:
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 2:
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case 3:
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            default:
                break;
        }
    }

    Color GetIDColor (int _ID)
    {
        switch (_ID)
        {
            case 1:
                return Color.red;
            case 2:
                return Color.white;
            case 3:
                return Color.blue;
            default:
                return Color.white;
        }
    }
}
