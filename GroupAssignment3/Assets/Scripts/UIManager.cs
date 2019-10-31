using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GA3
{
    public class UIManager : MonoBehaviour {

        public Text Mouse;
        public Text Key0;
        public Text Key1;
        public KeyboardPlayerController KeyboardPlayer0;
        public KeyboardPlayerController KeyboardPlayer1;
        // Use this for initialization
        void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {
            Mouse.text = "MouseMode: \n" + MouseController.instance.mode.ToString();
            Key0.text = "KeyboardPlayer0Mode: \n" + KeyboardPlayer0.modetype;
            Key1.text = "KeyboardPlayer1Mode: \n" + KeyboardPlayer1.modetype;

        }
    }
}

