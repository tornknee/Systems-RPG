using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]


//Governs movement, jump, dash and Animator
public class PlayerMovement : MonoBehaviour
{
    CharacterController charCon;
    Animator animator;
    [SerializeField]
    CharacterStats playerStats;

    [SerializeField]
    float speed;

    [SerializeField]
    float gravity;

    [SerializeField]
    float jumpHeight;

    Vector3 movement = Vector3.zero;

    float dashTimer;
    bool dashing = false;
    float oldSpeed;
    [SerializeField]
    float dashSpeed;
    

    //Gets CharacterController and Animator
    //Sets up oldSpeed for dash mechanic
    void Awake()
    {
        charCon = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        oldSpeed = speed;
    }

    //Checks for input on x and z axis and moves accordingly
    //Checks for jump input and moves y axis
    //Checks for dash input and increases movement speed for brief time
    void Update()
    {
        if (!DialogueLoader.dialogueLoader.inConversation)
        {
            movement.x = 0;
            movement.z = 0;

            movement += transform.forward * Input.GetAxis("Vertical") * (speed + playerStats.prowess);
            movement += transform.right * Input.GetAxis("Horizontal") * (speed + playerStats.prowess);

            //Checks if grounded, then checks if jump button pressed, if so jumps to jumpHeight
            if (charCon.isGrounded)
            {
                movement.y = -1;

                if (Input.GetButtonDown("Jump"))
                {
                    movement.y += jumpHeight;
                }
            }
            //If not grounded fall with gravity
            else
            {
                movement.y -= gravity * Time.deltaTime;
            }

            //Checks if dashing, if not then sets speed to original speed and checks if LeftShift is pressed and mana >10
            //If satisfied sets dashing to true and dashtimer to 0
            if (!dashing)
            {
                speed = oldSpeed;
                if (Input.GetKeyDown(KeyCode.LeftShift) && playerStats.mana >= 10f)
                {
                    dashing = true;
                    playerStats.mana -= 10f;
                    dashTimer = 0;
                }

            }
            //If dashing - player speed is increased to dashspeed which is affected by affinity stat
            //starts dashTimer
            else
            {
                dashTimer += Time.deltaTime;
                speed = dashSpeed * playerStats.affinity;

            }
            //If dashTimer > 0.1 then dashing stops
            if (dashTimer >= 0.1)
            {
                dashing = false;
            }


            charCon.Move(movement * Time.deltaTime);

            //Governs animator
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                animator.SetBool("walking", true);
            }
            else
            {
                animator.SetBool("walking", false);
            }
        }
        
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("interact");
            RaycastHit hitObj;
            if (Physics.Raycast(transform.position, transform.forward,out hitObj, 2f))
            {
                hitObj.transform.gameObject.SendMessage("Interact");
            }
        }
    }
}
