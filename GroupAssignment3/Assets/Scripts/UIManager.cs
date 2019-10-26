using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GA3
{
    public class UIManager : MonoBehaviour {

        public Text Mouse;
        public Text Key1;
        public Text Key2;
	    // Use this for initialization
	    void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {
            Mouse.text = "MouseMode: \n" + MouseController.instance.mode.ToString();
	    }
    }
}

