using UnityEngine;
using System.Collections;

public class XboxController : MonoBehaviour {

    public float speed = 18;

    public float turnSpeed = 60;

    private Rigidbody rig;

    // Initialization
    void start(){
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void update(){
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        float rStickX = Input.GetAxis("X360_RStickX");

        Vector3 movement = transform.TransformDirection(new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime);

        rig.MovePosition(transform.position + movement);

        Quaternion rotation = Quaternion.Euler(new Vector3(0, rStickX, 0) * turnSpeed * Time.deltaTime);

        transform.Rotate(new Vector3(0, rStickX, 0), turnSpeed * Time.deltaTime);
    }
}