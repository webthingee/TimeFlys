using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour 
{
    public GameObject blockPrefab;
    public float minDropInterval = 2f;
    public float maxDropInterval = 5f;
    public Transform[] dropPositions;
	
	void Start()
    {
        float dropTime = Random.Range(minDropInterval, maxDropInterval);
        StartCoroutine(DropBlock(dropTime));
    }   

    IEnumerator DropBlock (float _wait)
    {
        float dropTime = Random.Range(minDropInterval, maxDropInterval);
        Transform dropFrom = SelectDropPosition();

        yield return new WaitForSeconds(_wait);
        
        GameObject block = Instantiate(blockPrefab, dropFrom.position, Quaternion.identity);
        block.GetComponent<Block>().blockID = Random.Range(1,4);
        
        StartCoroutine(DropBlock(dropTime));
    }

    Transform SelectDropPosition ()
    {
        int i = Random.Range(0, dropPositions.Length);
        return dropPositions[i];
    }
}
