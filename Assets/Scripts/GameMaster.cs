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

    public float weaponChangeTime = 10f;
    public float weaponChangeTimeCooldown;
    public Slider weaponChangeTimeSlider;

    public GameObject gameOverCanvas;

    public Image canKillAnyImage;
        public bool canKillAny = false;
        public float canKillAnyCooldown = 10f;
        public Slider canKillAnySlider;

    
    public Image canNonStopImage;
        public bool canNonStop = false;
        public float canNonStopCooldown = 10f;
        public Slider canNonStopSlider;


    public Image canRapidFireImage;
        public bool canRapidFire = false;
        public float canRapidFireCooldown = 10f;
        public Slider canRapidFireSlider;


    public Image canPauseTimeImage;
        public bool canPauseTime = false;

    public FiringCtrl leftGun;
    public FiringCtrl rightGun;

    public bool gameIsRunning;

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
        //DontDestroyOnLoad(gameObject);
    }

	void Start ()
    {
        Time.timeScale = 1f;
        gameOverCanvas.SetActive(false);
        gameIsRunning = true;

        canKillAnyCooldown = timerDefault;
        canNonStopCooldown = timerDefault;
        canRapidFireCooldown = timerDefault;

        weaponChangeTimeCooldown = weaponChangeTime;
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

        if (gameIsRunning)
        {
            Time.timeScale += 0.0001f; //0.00001f;

            WeaponChangeTimer();

            weaponChangeTimeSlider.value = weaponChangeTimeCooldown;
            canKillAnySlider.value = canKillAnyCooldown;
            canNonStopSlider.value = canNonStopCooldown;
            canRapidFireSlider.value = canRapidFireCooldown;
        }
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

    public void WeaponChangeTimer ()
    {
        if (weaponChangeTimeCooldown >= 0) 
        {        
            weaponChangeTimeCooldown -= Time.deltaTime;
        }
        else 
        {
            leftGun.weaponID = Random.Range(1,4);
            rightGun.weaponID = Random.Range(1,4);        
            weaponChangeTimeCooldown = weaponChangeTime; 
        }
    }

    public void LoadGameOver ()
    {
        gameIsRunning = false;
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame ()
    {
        SceneManager.LoadScene("Playground");
    }

    public void StartMainMenu ()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
