using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour {

    private GameObject offset;

    private Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Offset")
        {
            other.gameObject.GetComponent<Outline>().enabled = true;
            offset = other.gameObject;
            Glue.stickEvent.AddListener(Stick);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Offset")
        {
            other.gameObject.GetComponent<Outline>().enabled = false;
            Glue.stickEvent.RemoveListener(Stick) ;
            offset = null;
        }
    }
    private void Stick()
    {
        if(offset != null)
        {
            FixedJoint joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = offset.GetComponentInParent<Rigidbody>();
            offset.GetComponent<Outline>().enabled = false;
            rigidbody.isKinematic = false;
        }
    }
}
