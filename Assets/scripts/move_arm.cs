using UnityEngine;
using System.Collections;

public class move_arm : MonoBehaviour {

	private Vector3 moveDirection = Vector3.zero;
	private float speed;
	private float yaw = 0.0f;
	private float pitch = 0.0f;
	public float speedH = 2.0f;
	public float speedV = 2.0f;

	// Use this for initialization
	void Start () {
		speed = 10;
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		//moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		//transform.TransformDirection(moveDirection);
		//controller.Move(moveDirection * Time.deltaTime * speed);

		if (Input.GetAxis ("Vertical") > 0) {
			transform.position += transform.forward * Time.deltaTime * speed;
		}
		else if (Input.GetAxis ("Vertical") < 0){
			transform.position += transform.forward * Time.deltaTime * -speed;
		}

		if (Input.GetAxis ("Horizontal") > 0) {
			transform.position += transform.right * Time.deltaTime * speed;
		}
		else if (Input.GetAxis ("Horizontal") < 0){
			transform.position += transform.right * Time.deltaTime * -speed;
		}

		yaw += speedH * Input.GetAxis("Mouse X");
		pitch -= speedV * Input.GetAxis("Mouse Y");

		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
	}
}
