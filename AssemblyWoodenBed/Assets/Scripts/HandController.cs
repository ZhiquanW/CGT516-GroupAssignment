using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HandController : MonoBehaviourPun , IPunObservable{
    /*public Color emptyColor;

	public Color touchColor;

	public Color holdColor;*/
    public Transform offset;

	public bool isTouched;

	public bool isHold;

	private MeshRenderer _renderer;

	public GameObject touchedObj;

	//private Vector3 holdPositionOffset;
	// Use this for initialization
	void Start () {
		//_renderer = this.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!photonView.IsMine)
            return;
		if (Input.GetMouseButtonDown(0)) {
            photonView.RPC("PickUpObject", RpcTarget.All);
        }
        if (isHold)
        {
            //touchedObj.transform.Rotate(Vector3.foward, Input.GetAxis("Mouse ScrollWheel") * 60f);
            photonView.RPC("RotateTouchedObject", RpcTarget.All, Input.GetAxis("Mouse ScrollWheel") * 60f);
        }
        if(Input.GetKeyDown(KeyCode.F) && isHold)
        {
            photonView.RPC("GetFunctionKeyDown", RpcTarget.All);
        }
		
	}
    [PunRPC]
    private void RotateTouchedObject(float angle, PhotonMessageInfo info)
    {
        touchedObj.transform.Rotate(Vector3.forward, angle);
    }
    [PunRPC]
    private void GetFunctionKeyDown(PhotonMessageInfo info)
    {
        switch (touchedObj.tag)
        {
            case "Glue":
                Glue.stickEvent.Invoke();
                break;
            case "Axe":
                //Chop the wood
                break;
            default:
                break;
        }
    }
    [PunRPC]
    private void PickUpObject(PhotonMessageInfo info)
    {
        if (!isHold && isTouched)
        {
            isHold = true;
            //_renderer.material.color = holdColor;
            //touchedObj.transform.position = this.transform.position + holdPositionOffset;
            touchedObj.GetComponent<Rigidbody>().isKinematic = true;
            touchedObj.GetComponent<PhotonRigidbodyView>().enabled = false;
            touchedObj.GetComponent<PhotonTransformView>().enabled = false;
            touchedObj.transform.SetParent(offset);
        }
        else if (isHold)
        {
            touchedObj.GetComponent<Rigidbody>().isKinematic = false;
            touchedObj.transform.SetParent(null);
            touchedObj.GetComponent<PhotonRigidbodyView>().enabled = true;
            touchedObj.GetComponent<PhotonTransformView>().enabled = true;
            isHold = false;
        }

    }

    private void OnTriggerEnter(Collider other) {
		if (!isHold && other.gameObject.layer == 9) {
			//_renderer.material.color = touchColor;
			isTouched = true;
			touchedObj = other.gameObject;
            touchedObj.GetComponent<Outline>().enabled = true;
			//holdPositionOffset = other.gameObject.transform.position - this.transform.position;
		}
	}

	private void OnTriggerExit(Collider other) {
		if (!isHold && other.gameObject.layer == 9) {
			//_renderer.material.color = emptyColor;
            touchedObj.GetComponent<Outline>().enabled = false;
            isTouched = false;
		}
        
	}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            
        }
        else
        {

        }
    }
}
