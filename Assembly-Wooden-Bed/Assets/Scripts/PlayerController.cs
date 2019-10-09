using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float cameraRotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotateXSpeed = Input.GetAxis("Mouse X") * cameraRotateSpeed ;
        float rotateYSpeed = Input.GetAxis("Mouse Y") * cameraRotateSpeed ;
        if (Camera.main != null) Camera.main.transform.localRotation *= Quaternion.Euler(-rotateYSpeed, 0, 0);
        transform.localRotation*= Quaternion.Euler(0, rotateXSpeed, 0);
    }
}
