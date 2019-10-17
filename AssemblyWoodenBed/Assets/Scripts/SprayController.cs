using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SprayController : MonoBehaviour {

    // Use this for initialization
    public bool isSprayHold;
    public int colorMode;

	void Start () {
        isSprayHold = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            colorMode = 0;
            Debug.Log(colorMode);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            colorMode = 1;
            Debug.Log(colorMode);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            colorMode = 2;
            Debug.Log(colorMode);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isSprayHold = true;       
    }

    private void OnTriggerExit(Collider other)
    {
        isSprayHold = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (((isSprayHold && collision.gameObject.layer == 9) || (isSprayHold && collision.gameObject.layer == 10)) && (colorMode == 0))
        {
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;           
        }
        if (((isSprayHold && collision.gameObject.layer == 9) || (isSprayHold && collision.gameObject.layer == 10)) && (colorMode == 1))
        {
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        if (((isSprayHold && collision.gameObject.layer == 9) || (isSprayHold && collision.gameObject.layer == 10)) && (colorMode == 2))
        {
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
}
