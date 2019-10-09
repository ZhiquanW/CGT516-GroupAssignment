using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = 9.8f;

    private CharacterController controller;
    private CameraLook camlook = new CameraLook();
    private Camera cam;

    public Color touchColor;
    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        controller = gameObject.GetComponent<CharacterController>();
        camlook.Init(transform, cam.transform);

    }

    // Update is called once per frame
    void Update()
    {
        camlook.LookRotation(transform, cam.transform);
        //Move
        float theta = transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        Vector3 Dir = new Vector3(hor * Mathf.Cos(theta) + ver * Mathf.Sin(theta), -gravity * Time.fixedDeltaTime, -hor * Mathf.Sin(theta)
            + ver * Mathf.Cos(theta));
        controller.Move(Dir * speed * Time.fixedDeltaTime);
        camlook.UpdateCursorLock();
    }


}
