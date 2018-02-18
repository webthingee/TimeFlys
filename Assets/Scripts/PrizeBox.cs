using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeBox : MonoBehaviour 
{
   public bool killAny;
   public bool nonStop;
   public bool rapidFire;
   
   public void GetPrize ()
   {
        if (killAny)
            GameMaster.instance.canKillAny = true;
       
        if (nonStop)
            GameMaster.instance.canNonStop = true;

        if (rapidFire)
            GameMaster.instance.canRapidFire = true;

        Destroy(this.gameObject);
   }
}
