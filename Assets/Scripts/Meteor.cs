using System;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public Rigidbody asteroidFragPrefab1;
    public Rigidbody asteroidFragPrefab2;
    public float fragmentSpeed = 5f;
    
    
    public void Dividir(Vector3 bulletDirection)
    {
        Rigidbody frag1 = Instantiate(asteroidFragPrefab1, transform.position, Quaternion.identity);
        Rigidbody frag2 = Instantiate(asteroidFragPrefab2, transform.position, Quaternion.identity);
        
        Vector3 direction1 = Quaternion.Euler(0f, 0f, 45f) * bulletDirection;
        Vector3 direction2 = Quaternion.Euler(0f, 0f, -45f) * bulletDirection;
        
        frag1.AddForce(direction1.normalized * fragmentSpeed, ForceMode.Impulse);
        frag1.AddTorque(transform.forward * fragmentSpeed,  ForceMode.Impulse);
        frag2.AddForce(direction2.normalized * fragmentSpeed, ForceMode.Impulse);
        frag2.AddTorque(-transform.forward * fragmentSpeed,  ForceMode.Impulse);
        
        Destroy(frag1.gameObject, 3f);
        Destroy(frag2.gameObject, 3f);
        ApagarMeteorito();
    }

    private void OnEnable()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Vector3.zero;
        rb.linearVelocity = Vector3.zero;
        Invoke(nameof(ApagarMeteorito), 4f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void ApagarMeteorito()
    {
        gameObject.SetActive(false);
    }
    
}
