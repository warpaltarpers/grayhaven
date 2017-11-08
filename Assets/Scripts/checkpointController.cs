using UnityEngine;
using System.Collections;

public class checkpointController : MonoBehaviour {

	public Sprite redFlag;//picturename
	public Sprite greenFlag;
	private SpriteRenderer checkpointSpriteRender;
	public bool checkpointReached;
    public GameObject playerObj;
    public GameObject CreatePlayer()
    {
        GameObject go;
        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f,0);
        go = GameObject.Instantiate(playerObj, pos, Quaternion.identity) as GameObject;
        return go;
    }
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
