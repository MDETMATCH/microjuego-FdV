using UnityEngine;
using System.Collections.Generic;
public class MeteorPool : MonoBehaviour
{
    public static MeteorPool Instance;
    public GameObject asteroidPrefab;
    public int poolSize = 20;
    private Queue<GameObject> meteorQueue = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject go = Instantiate(asteroidPrefab, transform);
            go.SetActive(false);
            meteorQueue.Enqueue(go);
        }
    }

    public GameObject GetMeteor()
    {
        GameObject meteor = meteorQueue.Dequeue();
        meteor.SetActive(true);
        meteorQueue.Enqueue(meteor);
        return meteor;
    }
}
