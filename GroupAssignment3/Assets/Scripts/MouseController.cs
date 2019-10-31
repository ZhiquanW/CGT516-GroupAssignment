using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GA3
{
    public class MouseController : Controller {

        public static MouseController instance = null;
        public int scrollSpeed = 10;
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
                if (mode == Mode.Substitute)
                    mode = 0;
                else
                    mode++;
                Debug.Log("MouseMode:" + mode);
                furniture.GetComponent<Furnitures>().ReleaseScaleLock(2);
            }
            switch (mode)
            {
                case Mode.Move:
                    Move();
                    break;
                case Mode.ScaleX:
                    furniture.GetComponent<Furnitures>().Scale(2, 0, Input.GetAxis("Mouse ScrollWheel") * scrollSpeed);
                    break;
                case Mode.ScaleY:
                    furniture.GetComponent<Furnitures>().Scale(2, 1, Input.GetAxis("Mouse ScrollWheel") * scrollSpeed);
                    break;
                case Mode.ScaleZ:
                    furniture.GetComponent<Furnitures>().Scale(2, 2, Input.GetAxis("Mouse ScrollWheel") * scrollSpeed);
                    break;
                case Mode.Color:
                    furniture.GetComponent<Furnitures>().ChangeColor(2, Input.GetAxis("Mouse ScrollWheel") * scrollSpeed);
                    break;


                case Mode.Add:
                    Vector3 selectedpoint = GetTargetPos();
                    Add(selectedpoint);
                    break;

                case Mode.Remove:
                    Remove(furniture);
                    break;

                case Mode.Substitute:
                    Substitute(furniture);
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
                furniture.GetComponent<Furnitures>().MoveObject(2,hit.point);
                
            }
        }

        protected override void Add(Vector3 pos)
        {

            if (Input.GetMouseButtonDown(2))
            {
                base.Add(pos);
            }

        }
        protected override void Remove(GameObject targetobject)
        {
            if (Input.GetMouseButtonDown(2))
            {
                base.Remove(targetobject);
            }

        }
        protected override void Substitute(GameObject targetobject)
        {
            if (Input.GetMouseButtonDown(2))
            {
                base.Add(targetobject.transform.position);
                base.Remove(targetobject);
            }

        }
        protected override Vector3 GetTargetPos()
        {
            Vector3 targetpos = new Vector3();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                targetpos = hit.point;
            }
            return targetpos;
        }
    }
}

