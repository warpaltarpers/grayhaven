using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public Transform[] backgrounds;  //array of back and foregrounds to be parallaxed
    private Transform camTransform; //reference to the camera's transform

    private float[] parallaxScales;  //the proportions of camera's movements to move the backgrounds by
    public float smoothing = 1f;  //the smothness of the parallax

    private Vector3 previousCamPosition;  //the position of the camera in the previous frame

    void Awake ()
    {
        //set up the camera reference
        camTransform = Camera.main.transform;
    }

	
	void Start () {
        //store the previous frame at the current frame's camera position
        previousCamPosition = camTransform.position;


        //assigning corresponding parallax scales

        parallaxScales = new float[backgrounds.Length];

        for(int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
        // for each background
        for(int i = 0; i < backgrounds.Length; i++)
        {
            //the parallax is the opposite of the camera movement because the previous frame multiple by the scale
            float parallax = (previousCamPosition.x - camTransform.position.x) * parallaxScales[i];

            //set a target x position which is the current position plus the parallax
            //taking the parallaxing and adding it to an actual position 
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            //create a target position which is the backgrounds current position with its target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //fade between current position and target position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        //set the previous cam pos to the cameras postion at the end of the frame 
        previousCamPosition = camTransform.position;

	}
}
