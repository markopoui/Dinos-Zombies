using UnityEngine;
using System.Collections;

public class MoveAndKill : MonoBehaviour {
	public float speed = 5F;
	public float gravity = 20F;
	private Vector3 moveDirection;
	private GameObject player;
	private Vector3 playerPos;
	private CharacterController controller;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Hero");
		playerPos = player.GetComponent<Transform>().position;
		controller = gameObject.GetComponent<CharacterController> ();

		if (gameObject.tag.Equals ("Dino")) {
			transform.LookAt (2 * transform.position - playerPos);
		}else if(gameObject.tag.Equals ("Zombie")) {
			transform.LookAt(player.GetComponent<Transform>());
		}
	}

	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, player.GetComponent<Transform>().position, Time.deltaTime * speed);
		controller.Move(Vector3.down * Time.deltaTime * gravity);

		if (Vector3.Distance (playerPos, transform.position) < 10) {
			Destroy(gameObject);
		}
	}
}
