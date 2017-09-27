using UnityEngine;
using System.Collections;

public class RedPowerUp : MonoBehaviour {
	public bool invuln = false;
	public Material Mat_player;
	public Material Mat_invuln;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		rend.material = Mat_player;

	
	}
	
	// Update is called once per frame
	void Update () {
		


		if (Input.GetButtonDown ("Fire3")) {
			if (invuln == false) {
				invuln = true;
				rend.material = Mat_invuln;
                //yield return new WaitForSeconds (3);
			} else {
				invuln = false;
				rend.material = Mat_player;
			}


		
		}

	}
}
