using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Glue : MonoBehaviour {

    public static UnityEvent stickEvent;
	// Use this for initialization
	void Start () {
		if(stickEvent == null)
        {
            stickEvent = new UnityEvent();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
