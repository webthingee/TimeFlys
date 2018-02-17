﻿using System.Collections;
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
        //transform.GetChild(0).transform.Rotate(Vector3.forward * 500f * Time.deltaTime);
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
            }
            else if (other.GetComponent<Block>().blockID == projectileID) // Same Color
            {
                GameObject explode = Instantiate(impactEffect, other.transform.position, Quaternion.identity);
                explode.GetComponent<SpriteRenderer>().color = GetIDColor(projectileID);
                Destroy(other.gameObject);
            }
            
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

    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     Debug.Log(other.collider.name);
        
    //     if (other.collider.tag == "Block")
    //     {
    //         if (other.collider.GetComponent<BlockDrop>().blockID == projectileID)
    //         {
    //             Destroy(other.gameObject);
    //         }
    //     }

    //     Destroy(this.gameObject);
    // }

	// void Impact()
	// {
	// 	var impactPoint = transform.position;
	// 	Instantiate(impactEffect, impactPoint, impactEffect.transform.rotation);
	// 	Destroy(this.gameObject);
	// }

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
