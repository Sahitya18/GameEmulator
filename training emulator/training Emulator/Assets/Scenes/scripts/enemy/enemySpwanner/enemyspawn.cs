using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawn : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject[] spawnPositions;
    [SerializeField]
    GameObject enemy;

    public static enemyspawn instance; 

    public GameObject spawnedObject;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        startspawning();
    }

    // Update is called once per frame
    void Update()
    {
        //enemySpawner();
    }
    public void enemySpawner()
    {
        int randomPosition = Random.Range(0, spawnPositions.Length);
       spawnedObject= Instantiate(enemy, spawnPositions[randomPosition].transform.position, transform.rotation);

    }
    IEnumerator enemySpawnDelay()
    {
        yield return new WaitForSecondsRealtime(1f);

        while (true)
        {
            enemySpawner();
            yield return new WaitForSecondsRealtime(3f);
            Destroy(spawnedObject);
        }

    }
    public void startspawning()
    {
        StartCoroutine(enemySpawnDelay());
    }
}
