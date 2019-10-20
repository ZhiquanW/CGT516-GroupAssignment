using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA3 {
    public class Controller : MonoBehaviour {

        protected enum Mode
        {
            Move, Rotate, Resize
        }
        protected Mode mode;
        public GameObject furniture;
	    // Use this for initialization
	    void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        protected virtual void Move(Vector3 pos)
        {
            furniture.transform.position = pos;
        }
        protected virtual void Move()
        {

        }
        protected void Resize(float s)
        {

        }
    }

}
