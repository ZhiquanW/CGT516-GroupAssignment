using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA3 {
    [RequireComponent(typeof(Outline))]
    public class Furnitures : MonoBehaviour {
        private Outline outline;

        public bool[] lockScale = new bool[3];

        public bool lockColor = false;

        public List<Color> colors;

        public Color targetColor;

        // Use this for initialization
        void Start() {
            outline = GetComponent<Outline>();
            outline.enabled = false;
            //find children colors
            foreach (Transform child in gameObject.transform) {
                colors.Add(child.GetComponent<MeshRenderer>().material.color);
            }
            targetColor = Color.green;
        }

        // Update is called once per frame
        void Update() {
        }

        public void Scale(int dir, float s) {
            if (dir > 2) {
                return;
            }

            if (!lockScale[dir]) {
                lockScale[dir] = true;
                Vector3 tmpScale = transform.localScale;
                tmpScale[dir] *= s;
                transform.localScale = tmpScale;
            }
        }

        public void releaseScaleLock(int dir) {
            if (dir > 2) {
                return;
            }
            lockScale[dir] = false;
        }

        public void ChangeColor(float ratio) {
            if (lockColor) {
                return;
            }
            int counter = 0;
            foreach (Transform child in gameObject.transform) {
                child.GetComponent<MeshRenderer>().material.color = ratio * (targetColor - colors[counter]) + colors[counter++];
            }
        }

        public void colorLock() {
            lockColor = false;
        }

        public void ScaleY(float s) {
        }

        private void OnMouseDown() {
            if (MouseController.instance.furniture == null) {
                MouseController.instance.furniture = gameObject;
                //MouseController.instance.GetOffset();
            }
            else if (MouseController.instance.furniture == gameObject)
                MouseController.instance.furniture = null;
        }

        private void OnMouseEnter() {
            if (MouseController.instance.furniture == null)
                outline.enabled = true;
        }

        private void OnMouseExit() {
            if (MouseController.instance.furniture == null)
                outline.enabled = false;
        }
    }
}