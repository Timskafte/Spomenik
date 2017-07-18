using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{

    private Rigidbody myRigidbody;
    public float moveSpeed;

    public PlayerController target;

    public PlayerController[] players;

    public PlayerController player1;
    public PlayerController player2;
    public PlayerController player3;
    public PlayerController player4;

    public float player1Threat;
    public float player2Threat;
    public float player3Threat;
    public float player4Threat;



    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

        players = FindObjectsOfType(typeof(PlayerController)) as PlayerController[];
        
        player1 = players[0];
        player2 = players[1];
        player3 = players[2];
        player4 = players[3];

    }


    void Update()
    {

        if (target == null)
        {

        }
        else
        {
            transform.LookAt(target.transform.position);
        }


    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            myRigidbody.velocity = transform.forward * moveSpeed;
        }
    }

    public void updateTarget()
    {
        //Debug.Log(Mathf.Max(player1Threat, player2Threat, player3Threat, player4Threat));
        

        float highestThreat = Mathf.Max(player1Threat, player2Threat, player3Threat, player4Threat);

        if (player1Threat == highestThreat)
        {
            target = player1;
            //Debug.Log("P1 is target");
        }

        else if (player2Threat == highestThreat)
        {
            target = player2;
            //Debug.Log("P2 is target");
        }

        else if (player3Threat == highestThreat)
        {
            target = player3;
            //Debug.Log("P3 is target");
        }

        else if (player4Threat == highestThreat)
        {
            target = player4;
            //Debug.Log("P4 is target");
        }

    }

}
