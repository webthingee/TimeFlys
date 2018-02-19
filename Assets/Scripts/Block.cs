using UnityEngine;

public class Block : MonoBehaviour 
{
    public int blockID = 1;
    AudioSource blockAudio;
    
	void Start () 
    {
	    Colorizer(blockID);
        blockAudio = GetComponent<AudioSource>();
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        blockAudio.Play();

        if (transform.position.y > GameMaster.instance.heightLimit)
        {
            GameMaster.instance.LoadGameOver();
        }
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
