using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour 
{
    public static GameMaster instance = null;

    public float timerDefault;

    public Image canKillAnyImage;
        public bool canKillAny = false;
        public float canKillAnyCooldown = 10f;
    
    public Image canNonStopImage;
        public bool canNonStop = false;
        public float canNonStopCooldown = 10f;


    public Image canRapidFireImage;
        public bool canRapidFire = false;
        public float canRapidFireCooldown = 10f;


    public Image canPauseTimeImage;
        public bool canPauseTime = false;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
            
            //if not, set instance to this
            instance = this;
        
        //If instance already exists and it's not this:
        else if (instance != this)
            
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);    
        
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

	void Start()
    {
        //CanKillAny (false);
    }

	void Update ()
    {	
        AdjustImageValue(canKillAnyImage, canKillAny);
        AdjustImageValue(canRapidFireImage, canRapidFire);
        AdjustImageValue(canNonStopImage, canNonStop);
        AdjustImageValue(canPauseTimeImage, canPauseTime); // needs null
    }

    public void AdjustImageValue (Image _image, bool _bool)
    {
        if (_bool)
        {
            _image.color = Color.white; // use % and link to a timer
            
            if (canKillAnyCooldown >= 0 && canKillAny) {
                canKillAnyCooldown -= Time.deltaTime;
                Debug.Log(canKillAnyCooldown);
            }
            else {
                canKillAny = false;
                canKillAnyCooldown = timerDefault; 
            }

            if (canNonStopCooldown >= 0 && canNonStop) {
                canNonStopCooldown -= Time.deltaTime;
                Debug.Log(canNonStopCooldown);
            }
            else {
                canNonStop = false;
                canNonStopCooldown = timerDefault; 
            }

            if (canRapidFireCooldown >= 0 && canRapidFire) {
                canRapidFireCooldown -= Time.deltaTime;
                Debug.Log(canRapidFireCooldown);
            }
            else {
                canRapidFire = false;
                canRapidFireCooldown = timerDefault; 
            }
        }
        else
        {
            _image.color = Color.grey;
        }
    }
}
