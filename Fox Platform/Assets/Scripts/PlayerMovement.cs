using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Player _player;
	public Animator animator;
	public string HorizontalInput;
	public string CrouchInput;
	public string JumpInput;
	public string InteractInput;
	
	public CharacterController2D controller;
	public float runSpeed = 40f;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	private void Start()
	{
		_player = GetComponent<Player>();
	}

	// Update is called once per frame
	void Update () 
	{
		horizontalMove = Input.GetAxisRaw(HorizontalInput) * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		
		animator.SetFloat("VerticalSpeed", controller.verticalspeed);

		if (Input.GetButtonDown(InteractInput))
		{
			_player.Action();
		}
		
		//We are never grounded if the jump button is pressed.
		if (Input.GetButton(JumpInput))
		{
			animator.SetBool("IsGrounded", false);
		}
		
		if (Input.GetButtonDown(JumpInput))
		{
			jump = true;
		}
		else if (Input.GetButtonUp(JumpInput))
		{
			
			jump = false;
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
		animator.SetBool("IsGrounded", true);
	}

	public void OnCrouching(bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}
	
	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
	}
}