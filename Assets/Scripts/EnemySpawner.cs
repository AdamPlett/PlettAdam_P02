using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float SpawnTime = 7.5f;
    public AudioSource spawnSFX;
    private float SpawnTimer;
    private float randX, randZ;
    private Vector3 SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTimer = SpawnTime;
        SpawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position.x + " " + transform.position.y + " " + transform.position.z);
        SpawnTimer -= Time.deltaTime;
        if (SpawnTimer<=0)
        {
            spawnSFX.Play();
            randX = Random.Range(-43.2f,37.8f);
            randZ = Random.Range(-35.98f, 47.55f);
            SpawnPoint = SpawnPoint + new Vector3(randX,0,randZ);
            Instantiate(Enemy, SpawnPoint, Quaternion.identity);
            Debug.Log(SpawnPoint.x + " " + SpawnPoint.y + " " + SpawnPoint.z);
            ResetTimer();
        }
    }
    private void ResetTimer()
    {
        SpawnTimer = SpawnTime;
        SpawnPoint = transform.position;
        //Debug.Log(SpawnPoint.x + " " + SpawnPoint.y + " " + SpawnPoint.z);
        if (SpawnTime>1.5) SpawnTime=SpawnTimer-.5f;
    }
}
