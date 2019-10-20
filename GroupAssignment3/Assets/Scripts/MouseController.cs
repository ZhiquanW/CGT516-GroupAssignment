using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GA3
{
    public class MouseController : Controller {

        public static MouseController instance = null;
        // Use this for initialization
        private Vector3 screenPoint;
        private Vector3 offset;
        private int groundLayer = 1 << 9;
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this);
        }
        void Start () {
	    }
	
	    // Update is called once per frame
	    void Update () {
            if (furniture == null)
                return;
            if (Input.GetMouseButtonDown(1))
            {
                if (mode == Mode.Resize)
                    mode = 0;
                else
                    mode++;
                Debug.Log("MouseMode:" + mode);
            }
            switch (mode)
            {
                case Mode.Move:
                    Move();
                    break;
                case Mode.Resize:
                    break;
                case Mode.Rotate:
                    break;
                default:
                    break;
            }
	    }

        /*public void GetOffset()
        {
            screenPoint = Camera.main.WorldToScreenPoint(furniture.transform.position);

            offset = furniture.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }*/
        protected override void Move()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity,groundLayer))
            { 
                furniture.transform.position = hit.point ;
                
            }
        }
    }
}

