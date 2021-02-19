using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 8f;

    public Rigidbody2D rigidBody;

    Vector2 movement;
    Vector2 mousePosition;

    public Camera cam;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    private AudioSource source;

    public Animator bodyanimator;
    public Animator feetanimator;

    bool canShoot = true;


    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        /// To convert to world point,, mouse have screen pixel 
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        bodyanimator.SetFloat("speed", movement.sqrMagnitude);
        feetanimator.SetFloat("speed", movement.sqrMagnitude);
        Debug.Log("Speed"+ movement.sqrMagnitude);

        if (Input.GetButtonDown("Fire1")&& canShoot)
        {
            canShoot = false;
            Shoot();
        }
    }

    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * movementSpeed * Time.fixedDeltaTime);
      
        Vector2 lookDir = mousePosition - rigidBody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        rigidBody.rotation = angle;
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidBody.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        source.Play();
        bodyanimator.SetBool("isShooting",true);
        Invoke("stopShooting",0.5f);
    }

    void stopShooting()
    {
        canShoot = true;
        bodyanimator.SetBool("isShooting",false);
    }
}
