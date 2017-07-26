using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour {

    public int health;
    public int currentHealth;

    public float flashLength;
    private float flashCounter;

    public Renderer rend;
    private Color storedColor;


    [System.Serializable]
    public class statBlock
    {
        [Header ("Defensive stats")]
        public float armor = 10;
        public float magicResist = 1f;
        public float chaosResist = 1f;
        public float healingReceived = 1f;

        [Header("Offensive stats")]
        public float physicalDamage = 1f;
        public float magicDamage = 1f;
        public float chaosDamage = 1f;
        public float critChance = .05f;
        public float critDamage = 1.5f;

        [Header("Misc stats")]
        public int moveSpeed = 300;
        public int manaPool = 100;
        public float cooldownReduction = 1f;
        public float healingBonus = 1f;
        public int statPoints = 5;
    }

    public statBlock stats;


    void Start () {
        currentHealth = health;
        rend = gameObject.GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
        
	}
	

	void Update () {
		if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
            rend.material.SetColor("_Color", storedColor);
            }
        }
	}

    public void HurtPlayer (int damageAmount)
    {
        currentHealth -= damageAmount;
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.red);
    }
}
