using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody _rigid;
    public float thrustForce = 5f;
    public float rotationSpeed = 100f;
    public static int Score = 0;
    public static bool isDead = false;
    
    public float xBorderLimit = 10f;
    public float yBorderLimit = 8f;
    
    public InputAction accelerateAction;
    public InputAction rotateAction;
    public InputAction shootAction;

    public GameObject gun;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        accelerateAction.Enable();
        rotateAction.Enable();
        shootAction.Enable();
    }

    private void OnDisable()
    {
        accelerateAction.Disable();
        rotateAction.Disable();
        shootAction.Disable();
    }
    private void Update()
    {
        var newPos = transform.position;
        if (newPos.x > xBorderLimit)
            newPos.x = -transform.position.x + 1;
        else if (newPos.y > yBorderLimit)
            newPos.y = -transform.position.y + 1;
        else if (newPos.x < -xBorderLimit)
            newPos.x = -transform.position.x - 1;
        else if (newPos.y < -yBorderLimit)
            newPos.y = -transform.position.y - 1;
        transform.position = newPos;
        
        float rotationInput = rotateAction.ReadValue<float>();
        transform.Rotate(0,0,rotationInput * rotationSpeed * Time.deltaTime);
        float thrustInput = accelerateAction.ReadValue<float>();
        Vector3 thrustDirection = transform.right;
        
        _rigid.AddForce(thrustDirection * thrustForce * thrustInput * Time.deltaTime);

        if (shootAction.WasPressedThisFrame())
        {
            GameObject bullet = BulletPool.Instance.GetBullet();

            if (gun != null)
            {
                bullet.transform.position = gun.transform.position;
            }
            else
            {
                bullet.transform.position = transform.position;
            }
            bullet.transform.rotation = Quaternion.identity;
            Bullet balaScript = bullet.GetComponent<Bullet>();
            
            balaScript.targetVector = transform.right;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isDead = true;
        }

    }


}
