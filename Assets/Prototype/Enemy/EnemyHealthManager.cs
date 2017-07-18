using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealthManager : MonoBehaviour {

    public float health;
    private float currentHealth;
    private EnemyController enemyController;
    private Image healthBar;
    private Text monsterName;

    public string[] nameforMonsters = { "bob", "ray", "T-Chains" };


    void Start () {
        currentHealth = health;
        enemyController = gameObject.GetComponent<EnemyController>();
        healthBar = transform.FindChild("EnemyCanvas").FindChild("HealthBG").FindChild("Health").GetComponent<Image>();
        monsterName = transform.FindChild("EnemyCanvas").FindChild("MonsterName").GetComponent<Text>();

        int nameIndex = Random.Range(0, (nameforMonsters.Length - 1));
        monsterName.text = nameforMonsters[nameIndex];

    }
	

	void Update () {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void HurtEnemy(float damage, float threat, string playerOrigin)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / health;


        if (playerOrigin == "_P1")
        {
            enemyController.player1Threat += threat;
        }
        else if (playerOrigin == "_P2")
        {
            enemyController.player2Threat += threat;
        }
        else if (playerOrigin == "_P3")
        {
            enemyController.player3Threat += threat;
        }
        else if (playerOrigin == "_P4")
        {
            enemyController.player4Threat += threat;
        }

        enemyController.updateTarget();
    }
}
