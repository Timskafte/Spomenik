using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 6.0f;
    private float moveSpeedFactor = 50f; //this turns 300 movespeed to a decent starting speed aka "6f" speed via physics.

    public WeaponController weaponScript;
    //public AbilityController abilityScript;

    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private bool menuInputMode = false;
    public GameObject menu;
    private int menuCurrent;
    
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
    private string back;

       void Start ()
    {
        myRigidbody = GetComponent<Rigidbody>();
        //abilityScript.gameObject.GetComponent<AbilityController>();
        calculateMoveSpeed(GetComponent<PlayerStatManager>().stats.moveSpeed);
        menu = GameObject.Find("Canvas/Anchor/" + playerNumber);

        horizontal = "Horizontal" + playerNumber;
        vertical = "Vertical" + playerNumber;
        RHorizontal = "RHorizontal" + playerNumber;
        RVertical = "RVertical" + playerNumber;
        bumper1 = "Bumper1" + playerNumber;
        bumper2 = "Bumper2" + playerNumber;
        button1 = "Button1" + playerNumber;
        //button2 = "Button2" + playerNumber;
        //button3 = "Button3" + playerNumber;
        //button4 = "Button4" + playerNumber;
        start = "Start" + playerNumber;
        //back = "Back" + playerNumber;


    }

	void Update ()
    {
        if (Input.GetButtonDown(start))
        {
            Debug.Log("Start pressed by " + playerNumber + " ... " + menuInputMode);
            menuInputMode = !menuInputMode;
            menuCurrent = 1;
            updateMenuType();
            moveVelocity = new Vector3(0f, 0f, 0f);
        }


        if (menuInputMode == false)
        {

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
         else if (menuInputMode == true)
        {
            if (Input.GetButtonDown(bumper1))
            {
                menuCurrent ++;
                if (menuCurrent >= 3)
                {
                    menuCurrent = 1;
                }
                updateMenuType();
            }

            if (Input.GetButtonDown(bumper2))
            {
                menuCurrent--;

                if (menuCurrent <= 0)
                {
                    menuCurrent = 2;
                }
                updateMenuType();
            }
        }
   
    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }

    public void calculateMoveSpeed(float moveSpeedInput)
    {
        moveSpeed = moveSpeedInput / moveSpeedFactor;
    }


    public void updateMenuType()
    {
        if (menuInputMode == true)
        {

            if (menuCurrent == 1)
            {
                //menu.SetActive(true);
                menu.transform.FindChild("SpellMenu").gameObject.SetActive(true);
                menu.transform.FindChild("StatMenu").gameObject.SetActive(false);
            }
            if (menuCurrent == 2)
            {
                //menu.SetActive(true);
                menu.transform.FindChild("StatMenu").gameObject.SetActive(true);
                menu.transform.FindChild("SpellMenu").gameObject.SetActive(false);
                menu.GetComponent<MenuController>().updateMenuStats();
            }
        } else
        {
            menu.transform.FindChild("StatMenu").gameObject.SetActive(false);
            menu.transform.FindChild("SpellMenu").gameObject.SetActive(false);
        }
    }
}
