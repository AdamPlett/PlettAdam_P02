using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float SpawnTime = 7.5f;
    private float SpawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTimer = SpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimer -= Time.deltaTime;
        if (SpawnTimer<=0)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
            ResetTimer();
        }
    }
    private void ResetTimer()
    {
        SpawnTimer = SpawnTime;
        if (SpawnTime>1.5) SpawnTime=SpawnTimer-.5f;
    }
}
