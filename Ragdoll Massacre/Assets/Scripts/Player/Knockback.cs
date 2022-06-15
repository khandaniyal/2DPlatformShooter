using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
 
    public float thrust;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D player = other.GetComponent<Rigidbody2D>();
            if (player != null)
            {
                player.isKinematic = false;
                Vector2 difference = player.transform.position - transform.position;
                difference = difference.normalized * thrust;
                player.AddForce(difference, ForceMode2D.Impulse);
                player.isKinematic = true;
            }
        }
    }
}
