using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeBox : MonoBehaviour 
{
   public bool killAny;
   public bool nonStop;
   public bool rapidFire;
   
    AudioSource audioSource;
    
	void Start () 
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        audioSource.Play();

        if (transform.position.y > GameMaster.instance.heightLimit)
        {
            GameMaster.instance.LoadGameOver();
        }
    }
   
   public void GetPrize ()
   {
        if (killAny)
            GameMaster.instance.CanKillAny = true;
       
        if (nonStop)
            GameMaster.instance.CanNonStop = true;

        if (rapidFire)
            GameMaster.instance.CanRapidFire = true;

        Destroy(this.gameObject);
   }
}
