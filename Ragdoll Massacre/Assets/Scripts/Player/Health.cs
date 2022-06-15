using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float initialHealth;
    private float hp;

    public GameObject dieEffeect;
    
    void Start()
    {
        hp = initialHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            die();
        }
    }

    void die()
    {
        if (dieEffeect != null)
        {
            Instantiate(dieEffeect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }


}
