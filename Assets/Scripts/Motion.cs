using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 0.1f;
    private float angularSpeed = 1f;
    private float rx=0f,ry;
    public GameObject playerCamera; // public allows to init this object FROM UNITY!!!
    private AudioSource footStep;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        footStep = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx, dz;
        // simple motion
        // transform.Translate(new Vector3(0, 0, 0.1f));

        // mouse input
        rx -= Input.GetAxis("Mouse Y") * angularSpeed; // vertical rotation
        playerCamera.transform.localEulerAngles = new Vector3(rx, 0, 0);// runs on playerCamera
        // ry is horizontal rotation
        ry = transform.localEulerAngles.y+ Input.GetAxis("Mouse X") * angularSpeed;
        
        transform.localEulerAngles = new Vector3(0, ry, 0); // runs on this (Player)
        // keyboard input
        dx = Input.GetAxis("Horizontal")*speed;
        dz = Input.GetAxis("Vertical")*speed;
        Vector3 motion = new Vector3(dx, 0, dz);
        motion = transform.TransformDirection(motion); // now in Global coordinates
        controller.Move(motion);
        // foot step sound
        if(!footStep.isPlaying && controller.velocity.magnitude>0.1)
            footStep.Play();
    }
}
