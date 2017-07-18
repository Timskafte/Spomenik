using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 1.0f;

    public WeaponController weaponScript;
    //public AbilityController abilityScript;

    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private bool menuInputMode = false;
    public GameObject menu;
    
    //control input
    public enum PlayerNumber {_P1, _P2, _P3, _P4}
    public PlayerNumber playerNumber;

    private string horizontal;
    private string vertical;
    private string RHorizontal;
    private string RVertical;
    private string bumper1;
    private string bumper2;
    private string button1;
    private string button2;
    private string button3;
    private string button4;
    private string start;

       void Start ()
    {
        myRigidbody = GetComponent<Rigidbody>();
        //abilityScript.gameObject.GetComponent<AbilityController>();


        horizontal = "Horizontal" + playerNumber;
        vertical = "Vertical" + playerNumber;
        RHorizontal = "RHorizontal" + playerNumber;
        RVertical = "RVertical" + playerNumber;
        bumper1 = "Bumper1" + playerNumber;
        //bumper2 = "Bumper2" + playerNumber;
        button1 = "Button1" + playerNumber;
        //button2 = "Button2" + playerNumber;
        //button3 = "Button3" + playerNumber;
        //button4 = "Button4" + playerNumber;
        start = "Start" + playerNumber;


    }

	void Update ()
    {
        if (Input.GetButtonDown(start))
        {
            Debug.Log("A pressed by " + playerNumber);
            menuInputMode = !menuInputMode;
            
            menu.SetActive(menuInputMode);
        }

        moveInput = new Vector3(Input.GetAxisRaw(horizontal), 0f, Input.GetAxisRaw(vertical));
        moveVelocity = moveInput * moveSpeed;

        //Controller input
        Vector3 playerDirection = Vector3.right * Input.GetAxisRaw(RHorizontal) + Vector3.forward * -Input.GetAxisRaw(RVertical);
        if (playerDirection.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
        }

        //firing check

        if (Input.GetButtonDown(bumper1))
        {
            weaponScript.isFiring = true;
        }

        if (Input.GetButtonUp(bumper1))
        {
            weaponScript.isFiring = false;
        }

        if (Input.GetButtonDown(button1))
        {
            
            Debug.Log("A pressed by " + playerNumber);
            
        }
   
    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
}
