using System;
using UnityEngine;
using UnityEngine.UI;
public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector;
    private void OnEnable()
    {
        Invoke(nameof(ApagarBala), maxLifeTime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
    private void Update()
    {
        transform.Translate(targetVector * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Meteor meteoritoScript = collision.gameObject.GetComponent<Meteor>();
            if (meteoritoScript != null)
            {
                meteoritoScript.Dividir(targetVector);
            }
            else
            {
                collision.gameObject.SetActive(false);
            }

            IncreaseScore(50);
            UpdateScoreText();
            ApagarBala();
        }
        else if (collision.gameObject.CompareTag("EnemyFrag"))
        {   
            Destroy(collision.gameObject);
            IncreaseScore(25);
            UpdateScoreText();
            ApagarBala();
        }
    }

    private void IncreaseScore(int points)
    {
        Player.Score+=points;
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text =  "Puntos: " + Player.Score.ToString();
    }

    public void ApagarBala()
    {
        gameObject.SetActive(false);
    }
}
