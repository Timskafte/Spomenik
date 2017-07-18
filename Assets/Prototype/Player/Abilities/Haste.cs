using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haste : MonoBehaviour {

    public float duration = 2f;
    public float speedBoost = 3f;
    public PlayerController player;

    private float oldSpeed;
    private float timeElapsed;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	public void castHaste (PlayerController player) {
        oldSpeed = player.moveSpeed;
        player.moveSpeed = player.moveSpeed * speedBoost;
        timeElapsed -= Time.deltaTime;

        if (timeElapsed >= duration)
        {
            player.moveSpeed = oldSpeed;
        }

    }
}
