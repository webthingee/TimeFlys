using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour 
{
    public static GameMaster instance = null;

    public Image canKillAnyImage;
        public bool canKillAny = false;
    
    public Image canNonStopImage;
        public bool canNonStop = false;

    public Image canRapidFireImage;
        public bool canRapidFire = false;

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
        AdjustImageValue(canPauseTimeImage, canPauseTime);
    }

    public void AdjustImageValue (Image _image, bool _bool)
    {
        if (_bool)
        {
            _image.color = Color.white; // use % and link to a timer
        }
        else
        {
            _image.color = Color.grey;
        }
    }
}
