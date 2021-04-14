using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    //Rope Variables
    public bool isSwinging = false;
    public Vector2 ropeHook;
    public float swingForce = 4f;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // If space or W is pressed, JUMP
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        // If down arrow or S is pressed, CROUCH
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")) {
            crouch = false;
        }
        
    }

    private void FixedUpdate()
    {
        if (!isSwinging)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }
        else
        {
            var playerToHookDirection = (ropeHook - (Vector2)transform.position).normalized;

            // 2 - Inverse the direction to get a perpendicular direction
            Vector2 perpendicularDirection;
            if (horizontalMove < 0)
            {
                perpendicularDirection = new Vector2(-playerToHookDirection.y, playerToHookDirection.x);
                var leftPerpPos = (Vector2)transform.position - perpendicularDirection * -2f;
                Debug.DrawLine(transform.position, leftPerpPos, Color.green, 0f);
            }
            else
            {
                perpendicularDirection = new Vector2(playerToHookDirection.y, -playerToHookDirection.x);
                var rightPerpPos = (Vector2)transform.position + perpendicularDirection * 2f;
                Debug.DrawLine(transform.position, rightPerpPos, Color.green, 0f);
            }

            var force = perpendicularDirection * swingForce;

            controller.addForce(force, ForceMode2D.Force);
        }


    }
}
