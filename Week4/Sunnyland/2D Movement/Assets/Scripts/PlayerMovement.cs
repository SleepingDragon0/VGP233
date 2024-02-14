using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 20f;

	float horizontalMove = 0f;
	bool jumping = false;
	bool crouching = false;

	[SerializeField] KeyCode left;
	[SerializeField] KeyCode right;
	[SerializeField] KeyCode jump;
    [SerializeField] KeyCode crouch;


    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(left) || Input.GetKeyDown(right))
		{
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        }
		


        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetKeyDown(jump))
		{
			jumping = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetKeyDown(crouch))
		{
            crouching = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
            crouching = false;
		}

	}

    public void OnLoading()
    {
		animator.SetBool("IsJumping", false);
    }
	public void OnCrouching(bool isCrouching)
	{
        animator.SetBool("IsCrouching", isCrouching);

    }
    void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouching, jumping);
		jumping = false;
	}
}
