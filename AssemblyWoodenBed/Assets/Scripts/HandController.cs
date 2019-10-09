using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {
	public Color emptyColor;

	public Color touchColor;

	public Color holdColor;

	public bool isTouched;

	public bool isHold;

	private MeshRenderer _renderer;

	private GameObject touchedObj;

	private Vector3 holdPositionOffset;
	// Use this for initialization
	void Start () {
		_renderer = this.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			if (isTouched) {
				isHold = true;
				_renderer.material.color = holdColor;
				touchedObj.transform.position = this.transform.position + holdPositionOffset;
				touchedObj.GetComponent<Rigidbody>().isKinematic = true;
				touchedObj.transform.SetParent(transform);
			}
			
		}
		else {
			if (isHold){
				touchedObj.GetComponent<Rigidbody>().isKinematic = false;
				touchedObj.transform.SetParent(null);
				isHold = false;
			}
			
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (!isHold) {
			_renderer.material.color = touchColor;
			isTouched = true;
			touchedObj = other.gameObject;
			holdPositionOffset = other.gameObject.transform.position - this.transform.position;
		}
	}

	private void OnTriggerExit(Collider other) {
		if (!isHold) {
			_renderer.material.color = emptyColor;
			isTouched = false;
		}
	}
}
