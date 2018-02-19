using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour 
{
    public static GameMaster instance = null;
    
    #region Props  
    public Text scoreText;
    public int score;
    public bool gameIsRunning;
    private float currentTimeScale;

    [Header("Guns")]
    public FiringCtrl leftGun;
    public FiringCtrl rightGun;    
    public float heightLimit;
    public float weaponChangeTime = 10f;
    public float weaponChangeTimeCooldown;
    public Slider weaponChangeTimeSlider;

    [Header("Canvas Overlays")]
    public GameObject gameOverCanvas;
    public GameObject pauseCanvas;

    [Header("Special Weapons")]
    public float timerDefault;

    [Header("Kill Any")]
    public Image canKillAnyImage;
    private bool canKillAny = false;
    public float canKillAnyCooldown = 10f;
    public Slider canKillAnySlider;

    [Header("Non Stop")]
    public Image canNonStopImage;
    private bool canNonStop = false;
    public float canNonStopCooldown = 10f;
    public Slider canNonStopSlider;

    [Header("Rapid Fire")]
    public Image canRapidFireImage;
    private bool canRapidFire = false;
    public float canRapidFireCooldown = 10f;
    public Slider canRapidFireSlider;
    #endregion

    #region Getters and Setters
    public bool CanKillAny
    {
        get
        {
            return canKillAny;
        }

        set
        {
            canKillAny = value;
            canKillAnyCooldown = timerDefault;
        }
    }

    public bool CanNonStop
    {
        get
        {
            return canNonStop;
        }

        set
        {
            canNonStop = value;
            canNonStopCooldown = timerDefault;
        }
    }

    public bool CanRapidFire
    {
        get
        {
            return canRapidFire;
        }

        set
        {
            canRapidFire = value;
            canRapidFireCooldown = timerDefault;
        }
    }

    #endregion

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
        pauseCanvas.SetActive(false);
        gameIsRunning = true;

        canKillAnyCooldown = timerDefault;
        canNonStopCooldown = timerDefault;
        canRapidFireCooldown = timerDefault;

        weaponChangeTimeCooldown = weaponChangeTime;
    }

	void Update ()
    {	
        AdjustImageValue(canKillAnyImage, CanKillAny);
        AdjustImageValue(canRapidFireImage, CanRapidFire);
        AdjustImageValue(canNonStopImage, CanNonStop);

        if (Input.GetKeyDown("b"))
        {
            FindObjectOfType<SpawnBlock>().SpawnAPrize();
        }

        if (Input.GetKeyDown("p") || Input.GetKeyDown("q"))
        {
            PauseGame();
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
            
            if (canKillAnyCooldown >= 0 && CanKillAny) {
                canKillAnyCooldown -= Time.deltaTime;
            }
            else {
                CanKillAny = false;
                canKillAnyCooldown = timerDefault; 
            }

            if (canNonStopCooldown >= 0 && CanNonStop) {
                canNonStopCooldown -= Time.deltaTime;
            }
            else {
                CanNonStop = false;
                canNonStopCooldown = timerDefault; 
            }

            if (canRapidFireCooldown >= 0 && CanRapidFire) {
                canRapidFireCooldown -= Time.deltaTime;
            }
            else {
                CanRapidFire = false;
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

    public void PauseGame ()
    {
        currentTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
    }

    public void UnPauseGame ()
    {
        Time.timeScale = currentTimeScale;
        pauseCanvas.SetActive(false);
    }
}
