using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContinousSpawner : MonoBehaviour {

    public EnemyController enemyMob;
    public float spawnCooldown = 2f;
    private float currentSpawnCooldown = 2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        currentSpawnCooldown -= Time.deltaTime;

        if (currentSpawnCooldown <= 0)
        {
            Instantiate(enemyMob, gameObject.transform.position, gameObject.transform.rotation);
            currentSpawnCooldown = spawnCooldown;
            
        }



	}
}
