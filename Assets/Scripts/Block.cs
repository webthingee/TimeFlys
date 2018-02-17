﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour 
{
    public int blockID = 1;
    
	void Start () 
    {
	    Colorizer(blockID);
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
}
