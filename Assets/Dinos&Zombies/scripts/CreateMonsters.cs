using UnityEngine;
using System.Collections;

public class CreateMonsters : MonoBehaviour {
	public GameObject zombie; 
	public GameObject dino; 
	private GameObject player;
	private Vector3 newPosition;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Hero");
		InvokeRepeating ("addMonster", 2.0F, 2.0F);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void addMonster(){
		float angle = Random.Range(0F, 360F);
		//var q = Quaternion.AngleAxis(angle, Vector3.up);
		//newPosition = player.transform.position + q * Vector3.up * 100;
		//Instantiate (zombie, newPosition, Quaternion.identity);

		float radian = angle*Mathf.Deg2Rad;
		float x = Mathf.Cos(radian);
		float z = Mathf.Sin(radian);
		newPosition = new Vector3 (x,0,z)*50;
		newPosition = player.transform.position + newPosition;
		Instantiate ((Random.Range(0, 2) == 0) ? dino : zombie, newPosition, Quaternion.identity);

	}
}
