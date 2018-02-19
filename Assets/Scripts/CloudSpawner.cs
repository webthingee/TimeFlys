using System.Collections;
using UnityEngine;

public class CloudSpawner : MonoBehaviour 
{
    public GameObject[] clouds;
    public float minDropInterval = 2f;
    public float maxDropInterval = 5f;
	
	void Start()
    {
        float sendCloudTime = Random.Range(minDropInterval, maxDropInterval);
        StartCoroutine(SendCloud(sendCloudTime));
    }   

    IEnumerator SendCloud (float _wait)
    {
        Vector2 sendCloudFrom = SelectPosition();

        int i = Random.Range(0, clouds.Length);
        Instantiate(clouds[i], sendCloudFrom, Quaternion.identity, transform);

        yield return new WaitForSeconds(_wait);
        
        float sendCloudTime = Random.Range(minDropInterval, maxDropInterval);
        StartCoroutine(SendCloud(sendCloudTime));
    }

    Vector2 SelectPosition ()
    {
        float j = Random.Range(3f, 5f);
        return new Vector2(transform.position.x, j);
    }
}
