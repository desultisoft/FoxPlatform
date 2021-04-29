using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

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

		if (Input.GetButtonDown(JumpInput))
		{
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

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
