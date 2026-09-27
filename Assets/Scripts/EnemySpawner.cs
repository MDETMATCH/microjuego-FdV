using System;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner :  MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f; //Para ir aumentando la dificultad según pasa el tiempo
    private float spawnNext = 0;
    
    private void Update()
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinute;
            spawnRatePerMinute += spawnRateIncrement;

            float rand = Random.Range(-12, 12);
            
            Vector3 spawnPosition = new Vector3(rand, 9f, 1);

            GameObject meteor = MeteorPool.Instance.GetMeteor();
            meteor.transform.position = spawnPosition;
            meteor.transform.rotation = Quaternion.identity;
        }
    }
}
