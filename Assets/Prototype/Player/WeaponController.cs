using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public bool isFiring;

    public ProjectileController projectile;
    public float projectileSpeed;

    public float timeBetweenProjectiles;
    public float shotCounter;

    public Transform projectileSpawnPoint;
    private PlayerController playerController;

	void Start () {
        playerController = gameObject.GetComponentInParent<PlayerController>();
		
	}
	
	void Update () {

        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenProjectiles;
                ProjectileController newProjectile = Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
                newProjectile.speed = projectileSpeed;
                newProjectile.playerOwnership = playerController.playerNumber.ToString();
            }
        } else
        {
            shotCounter = 0;
        }
		
	}
}
