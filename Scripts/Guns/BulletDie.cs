using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDie : MonoBehaviour
{
    public GameObject dieEffect;
    public float damage, dieTime;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject colGameObj = col.gameObject;
        if (colGameObj.tag != "Player")
        {
            if (colGameObj.GetComponent<Health>() != null)
            {
                colGameObj.GetComponent<Health>().takeDamage(damage);
            }
            die();
        }
    }

    void die()
    {
        if (dieEffect != null)
        {
            Instantiate(dieEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
