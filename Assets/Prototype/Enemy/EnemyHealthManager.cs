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
    public GameObject CBTprefab;


    void Start () {
        currentHealth = health;
        enemyController = gameObject.GetComponent<EnemyController>();
        healthBar = transform.Find("EnemyCanvas").Find("HealthBG").Find("Health").GetComponent<Image>();
        monsterName = transform.Find("EnemyCanvas").Find("MonsterName").GetComponent<Text>();

        int nameIndex = Random.Range(0, (nameforMonsters.Length - 1));
        monsterName.text = nameforMonsters[nameIndex];

    }
	

	void Update () {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void HurtEnemy(float damage, float threat, string playerOrigin, bool isCrit)
    {
        if (health < damage)
        {
            damage = health;
        }
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / health;

        if (!isCrit)
        {
            InitCBT(damage.ToString()).GetComponent<Animator>().SetTrigger("Hit");
        }
        else
        {
            InitCBT(damage.ToString()).GetComponent<Animator>().SetTrigger("Crit");
        }


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

    GameObject InitCBT(string text)
    {
        GameObject temp = Instantiate(CBTprefab) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(transform.Find("EnemyCanvas"));
        tempRect.transform.localPosition = CBTprefab.transform.localPosition;
        tempRect.transform.localScale = CBTprefab.transform.localScale;
        tempRect.transform.localRotation = CBTprefab.transform.localRotation;

        temp.GetComponent<Text>().text = text;
        Destroy(temp.gameObject, 2);

        return temp;
    }
}
