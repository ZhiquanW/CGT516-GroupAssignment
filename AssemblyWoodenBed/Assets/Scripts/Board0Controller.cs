using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;

public class Board0Controller : MonoBehaviour {
	public GameObject[] boards;

	public int index = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DropBoard() {
		boards[index++].AddComponent<Rigidbody>();
	}

	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.name == "Axe") {
			DropBoard();
		}
			
	}
}
