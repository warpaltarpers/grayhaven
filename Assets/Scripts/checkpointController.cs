using UnityEngine;
using System.Collections;

public class checkpointController : MonoBehaviour {

	public Sprite redFlag;//picturename
	public Sprite greenFlag;
	private SpriteRenderer checkpointSpriteRender;
	public bool checkpointReached;

    // Use this for initialization
    void Start () {
		checkpointSpriteRender = GetComponent<SpriteRenderer> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player"){
			checkpointSpriteRender.sprite = greenFlag;
		checkpointReached = true;
	}
		
		}
}
