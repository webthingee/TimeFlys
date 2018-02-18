using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour 
{
    public static GameMaster instance = null;
    
    public Text scoreText;
    public int score;

    public float timerDefault;
    public float heightLimit;

    public GameObject gameOverCanvas;

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

    void Awake ()
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

	void Start ()
    {
        Time.timeScale = 1f;
        gameOverCanvas.SetActive(false);

        canKillAnyCooldown = timerDefault;
        canNonStopCooldown = timerDefault;
        canRapidFireCooldown = timerDefault;
    }

	void Update ()
    {	
        AdjustImageValue(canKillAnyImage, canKillAny);
        AdjustImageValue(canRapidFireImage, canRapidFire);
        AdjustImageValue(canNonStopImage, canNonStop);
        AdjustImageValue(canPauseTimeImage, canPauseTime); // needs null

        if (Input.GetKeyDown("b"))
        {
            FindObjectOfType<SpawnBlock>().SpawnAPrize();
        }

        scoreText.text = score.ToString();
    }

    public void AdjustImageValue (Image _image, bool _bool)
    {
        if (_bool)
        {
            _image.color = Color.white; // use % and link to a timer
            
            if (canKillAnyCooldown >= 0 && canKillAny) {
                canKillAnyCooldown -= Time.deltaTime;
            }
            else {
                canKillAny = false;
                canKillAnyCooldown = timerDefault; 
            }

            if (canNonStopCooldown >= 0 && canNonStop) {
                canNonStopCooldown -= Time.deltaTime;
            }
            else {
                canNonStop = false;
                canNonStopCooldown = timerDefault; 
            }

            if (canRapidFireCooldown >= 0 && canRapidFire) {
                canRapidFireCooldown -= Time.deltaTime;
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

    public void LoadGameOver ()
    {
        Debug.Log("Game Over");
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartMainMenu ()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
