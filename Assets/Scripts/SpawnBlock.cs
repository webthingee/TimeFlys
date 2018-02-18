using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour 
{
    public GameObject blockPrefab;
    public Transform blockDropContainer;
    public float minDropInterval = 2f;
    public float maxDropInterval = 5f;
    public Transform[] dropPositions;
    public GameObject[] dropPrize;
	
	void Start()
    {
        float dropTime = Random.Range(minDropInterval, maxDropInterval);
        StartCoroutine(DropBlock(dropTime));
    }   

    IEnumerator DropBlock (float _wait)
    {
        float dropTime = Random.Range(minDropInterval, maxDropInterval);
        Transform dropFrom = SelectDropPosition();
        
        int chanceOfPrize = Random.Range(1, 11);        
        if (chanceOfPrize < 3)
        {
            SpawnAPrize();
        }
        else
        {
            GameObject block = Instantiate(blockPrefab, dropFrom.position, Quaternion.identity, blockDropContainer);
            block.GetComponent<Block>().blockID = Random.Range(1,4);
        }
        
        yield return new WaitForSeconds(_wait);
        StartCoroutine(DropBlock(dropTime));
    }

    Transform SelectDropPosition ()
    {
        int i = Random.Range(0, dropPositions.Length);
        return dropPositions[i];
    }

    public void SpawnAPrize ()
    {
        int i = Random.Range(0, dropPrize.Length);
        Transform dropFrom = SelectDropPosition();
        
        Instantiate(dropPrize[i], dropFrom.position, Quaternion.identity, blockDropContainer);
    }
}
