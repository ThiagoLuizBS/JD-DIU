using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 30f;
    public Animator animator;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if(Input.GetButtonDown("Crouch")){
            crouch = true;
        } else if(Input.GetButtonUp("Crouch")){
            crouch = false;
        }

        if(Input.GetButtonDown("Run")){
            runSpeed = 60f;
        } else if(Input.GetButtonUp("Run")){
            runSpeed = 30f;
        }
    }

    public void OnLanding() 
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool IsCrouching) 
    {
        animator.SetBool("IsCrouching", IsCrouching);
    }

    void FixedUpdate() 
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
