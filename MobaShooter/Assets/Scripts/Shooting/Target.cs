﻿using UnityEngine;

public class Target : MonoBehaviour {

    //Target health
    public float health = 50f;

    //TakeDamage gets called from the gun or explosive when it hits an object
    public void TakeDamage(float damageAmmount)
    {
        health -= damageAmmount;
        if (health <= 0) {
            Die();
        }
    }

    void Die()
    {
        //Die just destroys the gameobject the script is called on for now
        Destroy(gameObject);
    }
}
