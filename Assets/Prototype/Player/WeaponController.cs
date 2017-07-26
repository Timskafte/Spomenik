using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public bool isFiring;

    public ProjectileController projectile;
    public float projectileSpeed;

    public float timeBetweenProjectiles;
    public float shotCounter;

    public float abilityDamage = 2;

    private Transform projectileSpawnPoint;
    private PlayerController playerController;
    private PlayerStatManager playerStatsManager;

	void Start () {
        playerController = gameObject.GetComponentInParent<PlayerController>();
        playerStatsManager = gameObject.GetComponentInParent<PlayerStatManager>();
        projectileSpawnPoint = gameObject.transform.Find("ProjectileSpawner");
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
                newProjectile.crit = CritCalculation(playerStatsManager.stats.critChance);

                if (newProjectile.crit == true)
                {
                    newProjectile.damageToGive = abilityDamage * playerStatsManager.stats.critDamage;
                } else
                {
                    newProjectile.damageToGive = abilityDamage;
                }
            }
        } else
        {
            shotCounter = 0;
        }
		
	}

    bool CritCalculation(float chanceForCrit)
    {
        float rand = Random.Range(0f, 1f);
        //Debug.Log("crit roll is: ..." + rand + " ... with chance at: ..." + chanceForCrit);
        if (rand > chanceForCrit)
        {
            return false;
        }
        Debug.Log("crit rolled succesfully");
        return true;
    }
}
