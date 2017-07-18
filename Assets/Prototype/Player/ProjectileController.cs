﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public float speed;
    public string playerOwnership;
    
    public float lifeTime = 1f;

    public int damageToGive;
    public int threatToGive;

    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        lifeTime -= Time.deltaTime;


        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    //private void OnCollisionEnter(Collision other)
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive, threatToGive, playerOwnership);
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}