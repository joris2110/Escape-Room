using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//Public variables
	public float walkSpeed;

	//Private variables
	Rigidbody rb;
	Vector3 moveDirection;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

//Non-Physics steps
	void Update()
	{
		//Get directional input from the user
		float horizontalMovement = Input.GetAxisRaw("Horizontal");
		float verticalMovement = Input.GetAxisRaw("Vertical");

		moveDirection = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;
	}

//Physics steps
	void FixedUpdate()
	{
		Move();
	}

	void Move()
	{
		//Rigidbody.velocity is a method which takes a Vector 3
		//and controls the speed and direction of the GameObject
		Vector3 yVelFix = new Vector3(0, rb.velocity.y, 0);
		rb.velocity = moveDirection * walkSpeed * Time.deltaTime;
		rb.velocity += yVelFix;
	}
}
