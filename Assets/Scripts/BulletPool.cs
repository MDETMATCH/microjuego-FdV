using UnityEngine;
using System.Collections.Generic;
public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;
    public GameObject bulletPrefab;
    public int poolSize = 30;
    private Queue<GameObject> bulletQueue = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < poolSize ; i++)
        {
            GameObject go = Instantiate(bulletPrefab, transform);
            go.SetActive(false);
            bulletQueue.Enqueue(go);
        }
    }

    public GameObject GetBullet()
    {
        GameObject bullet = bulletQueue.Dequeue();
        bullet.SetActive(true);
        bulletQueue.Enqueue(bullet);
        return bullet;
    }
}
