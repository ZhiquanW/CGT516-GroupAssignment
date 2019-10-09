using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Camera eyeCamera;
    public float cameraRotateSpeed;

    public float moveSpeed;
    private Rigidbody _rigidbody;

    public GameObject handObj;

    public Color touchColor;
    // Start is called before the first frame update
    void Start() {
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //Rotate Camera & Body
        float rotateXSpeed = Input.GetAxis("Mouse X") * cameraRotateSpeed ;
        float rotateYSpeed = Input.GetAxis("Mouse Y") * cameraRotateSpeed ;
        eyeCamera.transform.localRotation *= Quaternion.Euler(-rotateYSpeed, 0, 0);
        transform.localRotation*= Quaternion.Euler(0, rotateXSpeed, 0);
        //Control movement
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        _rigidbody.velocity = moveSpeed * (this.transform.forward*verticalInput + transform.right*horizontalInput);
        _rigidbody.angularVelocity = new Vector3();
        
        
    }
    
}
