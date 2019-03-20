using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	//public variables
	public float minimumX = -60f;
	public float maximumX = 60f;
	public float minimumY = -360f;
	public float maximumY = 360f;
	public float sensitivityX = 15f;
	public float sensitivityY = 15f;
	public Camera cam;
	public GameObject player;

	//private variables
	private float rotationY = 0f;
	private float rotationX = 0f;
	private Vector3 offset;


	void Update() {
		rotationY += Input.GetAxis("Mouse X") * sensitivityY;
		rotationX += Input.GetAxis("Mouse Y") * sensitivityX;

		rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

		transform.localEulerAngles = new Vector3(0, rotationY, 0);
		cam.transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);
		cam.transform.position = player.transform.position + offset;
	}

	void Start(){
		Cursor.lockState = CursorLockMode.Locked;

		if (Input.GetKey(KeyCode.Escape))
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		
		offset = cam.transform.position - player.transform.position;
		//GITTEST
	}


}
