﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceHealthBar : MonoBehaviour {

    public PlayerHealthManager playerHealthManager;
    private float max;
    private float current;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        max = playerHealthManager.health;
        current = playerHealthManager.currentHealth;

        float percentage = current / max;
        transform.localScale = new Vector3(percentage, 1f, 1f);
        
    }
}
