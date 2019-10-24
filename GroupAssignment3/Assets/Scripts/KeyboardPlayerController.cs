using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPlayerController : MonoBehaviour {
	public int PlayerID= 0;
	public float moveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool verticalUpInput = false;
		bool verticalDownInput = false;
		bool horizontalLeftInput =false;
		bool horizontalRightInput = false;
		if (PlayerID==0) {
			verticalUpInput = Input.GetKey(KeyCode.W);
			verticalDownInput = Input.GetKey(KeyCode.S);
			horizontalLeftInput = Input.GetKey(KeyCode.A);
			horizontalRightInput = Input.GetKey(KeyCode.D);
		}else if (PlayerID == 1) {
			verticalUpInput = Input.GetKey(KeyCode.UpArrow);
			verticalDownInput = Input.GetKey(KeyCode.DownArrow);
			horizontalLeftInput = Input.GetKey(KeyCode.LeftArrow);
			horizontalRightInput = Input.GetKey(KeyCode.RightArrow);
		}
		
		if (verticalUpInput) {
			this.transform.position += new Vector3(0,0,moveSpeed*Time.deltaTime);
		}

		if (verticalDownInput) {
			this.transform.position -= new Vector3(0,0,moveSpeed*Time.deltaTime);
		}
		if (horizontalLeftInput) {
			this.transform.position -= new Vector3(moveSpeed*Time.deltaTime,0,0);
		}
		if (horizontalRightInput) {
			this.transform.position += new Vector3(moveSpeed*Time.deltaTime,0,0);
		}
	}
}
