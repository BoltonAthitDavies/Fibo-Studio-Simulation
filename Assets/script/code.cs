using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    private float rotationSpeed = 500.0f;
    private float speed = 1200f;
    public float x;
    public float z;
    public float scroll;
    public float verticalInput;
    public float horizontalInput;
    public Vector3 keyboard;
    public Vector3 move; 
    public Vector3 fcam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //frontcam();
        //if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Mouse2))
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //CamOrbit();
            //transform.position = startPoint.position;
            //right is the red Axis, foward is the blue axis
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
            keyboard = transform.right * x + transform.forward * z;
            controller.Move(keyboard * 100 * Time.deltaTime);
            CamOrbit();
        }
        scroll = Input.GetAxis("Mouse ScrollWheel");
        move = transform.forward * scroll;
        controller.Move(move * speed * Time.deltaTime);
    }
    private void CamOrbit()
    {
        if (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0)
        {
            verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.left, verticalInput);
            transform.Rotate(Vector3.up, horizontalInput, Space.World);
        }
    }

    private void frontcam()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            fcam = new Vector3(-10.5f, 7.5f, -2.5f);
            transform.position = fcam;
            //transform.Rotate(Vector3.up, 90.0f);
        }
    }
}
