using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{
    public float speed = 6.0f;
    public float gravity = 9.8f;


    private HandController hand;
    private CharacterController controller;
    private CameraLook camlook = new CameraLook();
    private Camera cam;

    private void Awake()
    {
        if (!photonView.IsMine)
        {
            
            Destroy(GetComponentInChildren<Camera>());
            //Destroy(GetComponentInChildren<HandController>());
        }
    }
    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        controller = gameObject.GetComponent<CharacterController>();
        camlook.Init(transform, cam.transform);
        hand = GetComponentInChildren<HandController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
            return;
        camlook.LookRotation(transform, cam.transform);
        //Move
        float theta = transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        /*if (Input.GetKey(KeyCode.E))
            gravity = -1.0f;
        else if (Input.GetKey(KeyCode.Q))
            gravity = 1.0f;
        else
            gravity = 0f;*/
        if (Input.GetKeyDown(KeyCode.LeftControl))
            cam.transform.localPosition = new Vector3(0f,0f,0f);
        if (Input.GetKeyUp(KeyCode.LeftControl))
            cam.transform.localPosition = new Vector3(0f, 1f, 0f);

        Vector3 Dir = new Vector3(hor * Mathf.Cos(theta) + ver * Mathf.Sin(theta), -gravity * Time.fixedDeltaTime , -hor * Mathf.Sin(theta)
            + ver * Mathf.Cos(theta));
        controller.Move(Dir * speed * Time.fixedDeltaTime);
        camlook.UpdateCursorLock();
    }

    public static void RefreshInstance(ref PlayerController player, PlayerController prefab)
    {
        var position = Vector3.zero;
        var rotation = Quaternion.identity;
        if(player != null)
        {
            position = player.transform.position;
            rotation = player.transform.rotation;
            PhotonNetwork.Destroy(player.gameObject);
        }
        player = PhotonNetwork.Instantiate(prefab.gameObject.name, position, rotation).GetComponent<PlayerController>();
    }

    
}
