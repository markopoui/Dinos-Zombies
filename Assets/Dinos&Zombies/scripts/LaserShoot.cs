using UnityEngine;
using System.Collections;

public class LaserShoot : MonoBehaviour {
	public GameObject explosion; 
	private LineRenderer laser;

	// Use this for initialization
	void Start () {
		laser = gameObject.GetComponent<LineRenderer> ();
		laser.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			StopCoroutine("FireLaser");
			StartCoroutine("FireLaser");
		}
	}

	IEnumerator FireLaser()
	{
		laser.enabled = true;

		while (Input.GetButton ("Fire1")) {
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;
		
			laser.SetPosition (0, ray.origin);

			if (Physics.Raycast (ray, out hit, 100)) {
				laser.SetPosition (1, hit.point);
				if(hit.transform.gameObject.tag.Equals("Zombie") || hit.transform.gameObject.tag.Equals("Dino")) {
					GameObject expl = Instantiate(explosion, hit.transform.position, Quaternion.identity) as GameObject;
					Destroy(hit.transform.gameObject);
					Destroy(expl, 3);
				}

			} else {
				laser.SetPosition (1, ray.GetPoint(100));
			}

			yield return null;
		}

		laser.enabled = false;
	}
}
