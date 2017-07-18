using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenter : MonoBehaviour {

    public Transform player1;
    public Transform player2;
    public Transform player3;
    public Transform player4;

    private Transform centerPoint;

    //public PlayerController enemyTarget;


    // Use this for initialization
    void Start ()
    {

        centerPoint = gameObject.transform;
        //Debug.Log(centerPoint.transform.position);

        //FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(centerPoint.transform.position);

    }

    private void LateUpdate()
    {
        centerPoint.transform.position = (player1.transform.position + player2.transform.position + player3.transform.position + player4.transform.position) / 4;
    }

}
