using System;
using System.Collections;
using System.Collections.Generic;
using GA3;
using UnityEngine;

public class KeyboardPlayerController : Controller {
    //public static KeyboardPlayerController instance = null;
    public int PlayerID= 0;
	public float moveSpeed;
	public int modeID = 0;//0:Scale X 1:Scale Y 2:Scale Z 3:Color 4:Move 5:Add 6:Remove 7:Substitute
    public string modetype;
    public string[] Mode_KEYBOARD = { "ScaleX", "ScaleY", "ScaleZ", "Color", "Move", "Add", "Remove", "Substitute" };
   


    public int modeNum = 8;

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
                modetype = Mode_KEYBOARD[modeID];

                if (targetFurniture == null) {
					return;
				}
				targetFurniture.GetComponent<Furnitures>().ReleaseScaleLock(PlayerID);
			}
		}else if (PlayerID == 1) {
			if (Input.GetKeyDown(KeyCode.P)) {
				modeID = (modeID+1) % modeNum;
                modetype = Mode_KEYBOARD[modeID];
                if (targetFurniture == null) {
					return;
				}
				targetFurniture.GetComponent<Furnitures>().ReleaseScaleLock(PlayerID);
			}
		}
		
	}

    void ManipulateFurniture()
    {

        if (PlayerID == 0) {
			if (Input.GetKeyDown(KeyCode.Q)) {
				if (0 <= modeID && modeID <= 2) {
                    if (targetFurniture == null)
                    {
                        return;
                    }

                    targetFurniture.GetComponent<Furnitures>().Scale(PlayerID, modeID, manipulateStep);
				}else if (modeID == 3) {
                    if (targetFurniture == null)
                    {
                        return;
                    }

                    targetFurniture.GetComponent<Furnitures>().ChangeColor(PlayerID,manipulateStep);
				}
                else if (modeID == 4)
                {

                }
                else if (modeID == 5)
                {
                    Vector3 selectedpoint = this.transform.position;
                    Add(selectedpoint);
                }
                else if (modeID == 6)
                {
                    if (targetFurniture == null)
                    {
                        return;
                    }

                    Remove(targetFurniture);
                }
                else if (modeID == 7)
                {
                    if (targetFurniture == null)
                    {
                        return;
                    }

                    Substitute(targetFurniture);
                }
            }

			if (Input.GetKeyDown(KeyCode.E)) {
				if (0 <= modeID && modeID <= 2) {
					targetFurniture.GetComponent<Furnitures>().Scale(PlayerID, modeID, -manipulateStep);
				}else if (modeID == 3) {
					targetFurniture.GetComponent<Furnitures>().ChangeColor(PlayerID,-manipulateStep);
				}
                else if (modeID == 4)
                {

                }
                //else if (modeID == 5)
                //{
                //    Add(targetFurniture.transform.position);
                //}
                //else if (modeID == 6)
                //{
                //    Remove(targetFurniture);
                //}
                //else if (modeID == 7)
                //{
                //    Substitute(targetFurniture);
                //}
            }
		}
		else if (PlayerID == 1) {
			if (Input.GetKeyDown(KeyCode.K)) {
				if (0 <= modeID && modeID <= 2) {
					targetFurniture.GetComponent<Furnitures>().Scale(PlayerID, modeID, manipulateStep);
				}else if (modeID == 3) {
					targetFurniture.GetComponent<Furnitures>().ChangeColor(PlayerID, manipulateStep);
				}
                else if (modeID == 4)
                {

                }
                else if (modeID == 5)
                {
                    Vector3 selectedpoint = this.transform.position;
                    Add(selectedpoint);
                }
                else if (modeID == 6)
                {
                    Remove(targetFurniture);
                }
                else if (modeID == 7)
                {
                    Substitute(targetFurniture);
                }
            }

			if (Input.GetKeyDown(KeyCode.L)) {
				if (0 <= modeID && modeID <= 2) {
					targetFurniture.GetComponent<Furnitures>().Scale(PlayerID, modeID, -manipulateStep);
				}else if (modeID == 3) {
					targetFurniture.GetComponent<Furnitures>().ChangeColor(PlayerID, -manipulateStep);
				}
                else if (modeID == 4)
                {

                }
                //else if (modeID == 5)
                //{
                //    Add(targetFurniture.transform.position);
                //}
                //else if (modeID == 6)
                //{
                //    Remove(targetFurniture);
                //}
                //else if (modeID == 7)
                //{
                //    Substitute(targetFurniture);
                //}
            }
		}
	
		
	}

	private void OnTriggerStay(Collider other) {
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

    protected override Vector3 GetTargetPos()
    {
        Vector3 targetpos = new Vector3();
        targetpos = targetFurniture.transform.position;
        return targetpos;
    }
    //public string GetEnumByIndex()
    //{
    //    Array values = Enum.GetValues(typeof(Mode_KEYBOARD));
    //    String modetype = (string)values.GetValue(modeID);
    //    return modetype;
    //}

    //protected override void Add(Vector3 pos)
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        base.Add(pos);
    //    }

    //}
    //protected override void Remove(GameObject targetobject)
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        base.Remove(targetobject);
    //    }

    //}
    //protected override void Substitute(GameObject targetobject)
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        base.Substitute(targetobject);
    //    }

    //}
}
