using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {
    /*public Color emptyColor;

	public Color touchColor;

	public Color holdColor;*/
    public Transform offset;

	public bool isTouched;

	public bool isHold;

	private MeshRenderer _renderer;

	private GameObject touchedObj;

	//private Vector3 holdPositionOffset;
	// Use this for initialization
	void Start () {
		//_renderer = this.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if (!isHold && isTouched) {
				isHold = true;
				//_renderer.material.color = holdColor;
				//touchedObj.transform.position = this.transform.position + holdPositionOffset;
				touchedObj.GetComponent<Rigidbody>().isKinematic = true;
				touchedObj.transform.SetParent(offset);
			}
            else if (isHold)
            {
                touchedObj.GetComponent<Rigidbody>().isKinematic = false;
                touchedObj.transform.SetParent(null);
                isHold = false;
            }		
		}
        if (isHold)
        {
            touchedObj.transform.Rotate(Vector3.forward, Input.GetAxis("Mouse ScrollWheel") * 60f);        }
        if(Input.GetKeyDown(KeyCode.F) && isHold)
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
}
