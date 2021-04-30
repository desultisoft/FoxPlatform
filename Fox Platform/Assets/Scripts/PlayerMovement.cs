using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public Animator animator;
	public string HorizontalInput;
	public string CrouchInput;
	public string JumpInput;
	
	public CharacterController2D controller;
	public float runSpeed = 40f;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw(HorizontalInput) * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		
		if (Input.GetButtonDown(JumpInput))
		{
			animator.SetBool("IsJumping", true);
			jump = true;
		}

		if (Input.GetButtonDown(CrouchInput))
		{
			crouch = true;
		} else if (Input.GetButtonUp(CrouchInput))
		{
			crouch = false;
		}

	}

	public void OnLanding()
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
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
