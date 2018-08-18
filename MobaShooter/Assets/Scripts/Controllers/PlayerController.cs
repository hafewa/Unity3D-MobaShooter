﻿using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {

    //Setting a reference to the PlayerMotor
    private PlayerMotor motor;

    [SerializeField]
    public static float health = 250f;

    [SerializeField][Range(1f, 10f)]
    private float moveSpeed = 5f;

    [SerializeField][Range(1f, 10f)]
    private float jumpHeight = 5f;

    [SerializeField][Range(0.01f, 15f)]
    public static float mouseSensitivity = 5f;


 // Ability One
    private float nextTimeAbilityOne = 0f;
    [SerializeField]
    private float abilityOneCooldown = 2f;

 // Ability Two
    private float nextTimeAbilityTwo = 0f;
    [SerializeField]
    private float abilityTwoCooldown = 2f;

 // Ultimate
    public float ultimatePoints = 0f;
    [SerializeField]
    private float pointsNeededForUlt = 3000f;

    private void Start() {

        //Get the playermotor component
        motor = GetComponent<PlayerMotor>();

    }

    private void Update() {

    //Calculate movement velocity as Vector3

        //Gets a vetcor based on the input(Keyboard and Controller)
        // W-UP    ( 1, 0, 0)
        // S-DOWN  (-1, 0, 0)
        // A-LEFT  ( 0, 0, 1)
        // D-RIGHT ( 0, 0,-1)
        float _xMovement = Input.GetAxisRaw("Horizontal");
        float _zMovement = Input.GetAxisRaw("Vertical");
        //Gets a vector based on the X-Axis input of the mouse
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        //Gets a vector based on the Y-Axis input of the mouse
        float _yRotation = Input.GetAxisRaw("Mouse X");

        //transform.right/forward takes the current rotation into consideration
        Vector3 _moveHorizontal = transform.right * _xMovement;
        Vector3 _moveVertical = transform.forward * _zMovement;

        //Calcualte Vector for jumping (pointing up) multiplied by the jumpVelocity
        Vector3 _jumpVelocity = Vector3.up * jumpHeight;

        //Adding both movement axis together and normalizing them so they only serve for direction
        //Multiplying the direction by the speed to control the movespeed
        Vector3 _moveVelocity = (_moveHorizontal + _moveVertical).normalized * moveSpeed;

        //Let the Motor move with the calculated velocity
        motor.Move(_moveVelocity);

        //Calculate Horizontal rotation as a Vector3 for turning around
        //Mulitply the vector by the mouseSensitivity variable to make the turnspeed adjustable
        Vector3 _rotation = new Vector3(0f, _yRotation, 0f) * mouseSensitivity;

        //Let the motor rotate the player by the calculated rotation
        motor.RotatePlayer(_rotation);

        //Calculate vertical rotation as a Vector3 for turning the camera up and down
        //Mulitply the vector by the mouseSensitivity variable to make the turnspeed adjustable
        Vector3 _cameraRotation = new Vector3(_xRotation, 0f, 0f) * mouseSensitivity;

        //Let the motor rotate the camera by the calculated rotation
        motor.RotateCamera(_cameraRotation);

        if (Input.GetKeyDown(GameManager.GM.jumpKey)) {

            //Let the playermotor jump when the space key is pressed
            motor.Jump(_jumpVelocity);

        }

        if (Input.GetKeyDown(GameManager.GM.abilityOneKey)) {

            if(Time.time >= nextTimeAbilityOne) {

                CastAbilityOne();
                nextTimeAbilityOne = Time.time + abilityOneCooldown;

            }

        }

        if (Input.GetKeyDown(GameManager.GM.abilityTwoKey)) {

            if (Time.time >= nextTimeAbilityTwo) {

                CastAbilityTwo();
                nextTimeAbilityTwo = Time.time + abilityTwoCooldown;

            }

        }

        if (Input.GetKeyDown(GameManager.GM.ultimateKey)) {

            if (ultimatePoints >= pointsNeededForUlt) {

                CastUltimate();
                ultimatePoints = 0f;

            }



        }

    }

    void CastAbilityOne() {

        Debug.Log("Casting Ability 1");

    }

    void CastAbilityTwo() {

        Debug.Log("Casting Ability 2");

    }

    void CastUltimate() {

        Debug.Log("Casting Ultimate");

    }

}
