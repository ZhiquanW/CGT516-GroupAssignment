using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA3 {
    public class Controller : MonoBehaviour {

        public enum Mode
        {
            Move, ScaleX, ScaleY, ScaleZ, Color, Add, Remove, Substitute
        }
        public Mode mode;
        public GameObject furniture;

        public GameObject prefab;
	    // Use this for initialization
	    void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        protected virtual void Add(Vector3 pos)
        {
            GameObject targetobject, parentobject;

            targetobject = Instantiate(prefab, pos, Quaternion.Euler(prefab.transform.rotation.eulerAngles));
            parentobject = GameObject.Find("Furnitures");
            targetobject.tag = "furniture";
            targetobject.transform.parent = parentobject.transform;


        }

        protected virtual void Remove(GameObject targetobject)
        {
            Destroy(targetobject);
        }

        protected virtual void Substitute(GameObject targetobject)
        {
            Add(targetobject.transform.position);
            Remove(targetobject);

        }

        private void OnApplicationPause(bool pause)
        {
            
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
        //protected void GetMouse3Dposition()
        //{
        //    Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        //    Vector3 mousePosOnScreen = Input.mousePosition;
        //    mousePosOnScreen.z = screenPos.z;
        //    Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePosOnScreen);
        //}
        protected virtual Vector3 GetTargetPos()
        {
            return new Vector3();
        }

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        //    {
        //        targetpos = hit.point;

        //    }
}

}
