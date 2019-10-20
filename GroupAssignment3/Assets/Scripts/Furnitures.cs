using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA3
{
    [RequireComponent(typeof(Outline))]
    public class Furnitures : MonoBehaviour {
        private Outline outline;
	    // Use this for initialization
	    void Start () {
            outline = GetComponent<Outline>();
            outline.enabled = false;
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }
        private void OnMouseDown()
        {
            if (MouseController.instance.furniture == null)
            {
                MouseController.instance.furniture = gameObject;
                //MouseController.instance.GetOffset();
            }            
            else if (MouseController.instance.furniture == gameObject)
                MouseController.instance.furniture = null;
        }
        private void OnMouseEnter()
        {
            if(MouseController.instance.furniture == null)
                outline.enabled = true;
        }
        private void OnMouseExit()
        {
            if(MouseController.instance.furniture == null)
                outline.enabled = false;
        }
    }
}

