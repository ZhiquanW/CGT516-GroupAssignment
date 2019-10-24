using System;
using System.Collections;
using System.Collections.Generic;
using GA3;
using UnityEngine;

public class KeyboardPlayerController : MonoBehaviour {
	public int PlayerID= 0;
	public float moveSpeed;
	public int modeID = 0;//0:Scale X 1:Scale Y 2:Scale Z 3:Color 4:Move
	public int modeNum = 5;

	public float manipulateStep = 0.1f;

	public GameObject targetFurniture;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MovePlayer();
		SwitchMode();
		ManipulateFurniture();
	}

	void MovePlayer() {
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
	void SwitchMode() {
		if (PlayerID == 0) {
			if (Input.GetKeyDown(KeyCode.F)) {
				modeID = (modeID+1) % modeNum;
				if (targetFurniture == null) {
					return;
				}
				targetFurniture.GetComponent<Furnitures>().ReleaseScaleLock(PlayerID);
			}
		}else if (PlayerID == 1) {
			if (Input.GetKeyDown(KeyCode.P)) {
				modeID = (modeID+1) % modeNum;
				if (targetFurniture == null) {
					return;
				}
				targetFurniture.GetComponent<Furnitures>().ReleaseScaleLock(PlayerID);
			}
		}
		
	}

	void ManipulateFurniture() {
		if (targetFurniture == null) {
			return;
		}

		if (PlayerID == 0) {
			if (Input.GetKey(KeyCode.Q)) {
				if (0 <= modeID && modeID <= 2) {
					targetFurniture.GetComponent<Furnitures>().Scale(PlayerID, modeID, manipulateStep);
				}else if (modeID == 3) {
					targetFurniture.GetComponent<Furnitures>().ChangeColor(PlayerID,manipulateStep);
				}
			}

			if (Input.GetKey(KeyCode.E)) {
				if (0 <= modeID && modeID <= 2) {
					targetFurniture.GetComponent<Furnitures>().Scale(PlayerID, modeID, -manipulateStep);
				}else if (modeID == 3) {
					targetFurniture.GetComponent<Furnitures>().ChangeColor(PlayerID,-manipulateStep);
				}
			}
		}
		else if (PlayerID == 1) {
			if (Input.GetKey(KeyCode.K)) {
				if (0 <= modeID && modeID <= 2) {
					targetFurniture.GetComponent<Furnitures>().Scale(PlayerID, modeID, manipulateStep);
				}
			}

			if (Input.GetKey(KeyCode.L)) {
				if (0 <= modeID && modeID <= 2) {
					targetFurniture.GetComponent<Furnitures>().Scale(PlayerID, modeID, -manipulateStep);
				}
			}
		}
	
		
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("furniture")) {
			targetFurniture = other.gameObject;
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("furniture")) {
			targetFurniture.GetComponent<Furnitures>().ReleaseScaleLock(PlayerID);
			targetFurniture = null;
		}
	}
}
