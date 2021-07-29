using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class PlayerAimWeapon : MonoBehaviour
{
    private Vector2 direction;
    public int isLeftorRight;
    
    [Header("Gun components and variables")]
    public Transform Gun;
    public GameObject bullet;
    public float bulletSpeed;
    public Transform shootPoint;
    public float fireRate;
    private float readyNextShot;
    
    [Header("Gun Animator uwu")] 
    public Animator gunAnimator;

    private void Update()
    {
    /* el mouse following no va estar activo de momento //// RECORDATORIO UPDATEARLO
     
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Gun.position;
        faceMouse();
    */

    if (Time.time > readyNextShot)
    {
        readyNextShot = Time.time + 1 / fireRate;
        shoot();
    }
        
    }

    private void faceMouse()
    {
        Gun.transform.right = direction;
    }

    private void shoot()
    {
        if (Input.GetMouseButton(isLeftorRight))
        {
            GameObject bulletIns = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            bulletIns.GetComponent<Rigidbody2D>().AddForce(bulletIns.transform.right * bulletSpeed);
            gunAnimator.SetTrigger("Shoot");
            Destroy(bulletIns, 3f);
        }
    }
}

