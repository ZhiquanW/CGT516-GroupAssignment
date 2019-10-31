using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GA3 {
    [RequireComponent(typeof(Outline))]
    public class Furnitures : MonoBehaviour {
        private Outline outline;

        public int[] lockScale = new int[3]{-1,-1,-1};
        public Vector2 scaleRange = new Vector2(0.2f,2);
        public int lockColor = -1;

        public List<Color> colors;
        public float colorRatio = 0;
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
            //reset locker
            lockColor = -1;
            for (int i = 0; i < 3; ++i) {
                lockScale[i] = -1;
            }
        }

        // Update is called once per frame
        void Update() {
        }

        public void Scale(int playerID,int dir, float s) {
            if (dir > 2) {
                return;
            }
            print("A");
            if (lockScale[dir] == -1 || lockScale[dir] == playerID) {
                lockScale[dir] = playerID;
                Vector3 tmpScale = transform.localScale;
                tmpScale[dir] += s;
                transform.localScale = tmpScale;
            }
        }

        public void ReleaseScaleLock(int playerId) {
            // release scale locker
            for (int i = 0; i < lockScale.Length;++i) {
                if (lockScale[i] == playerId) {
                    lockScale[i] = -1;
                }
            }
            
            //release color color locker
            if (lockColor == playerId) {
                lockColor = -1;
            }
        }

        public void ChangeColor(int playerID,float ratio) {
            if (lockColor == -1 || lockColor == playerID) {
                lockColor = playerID;
                int counter = 0;
                colorRatio += ratio;
                foreach (Transform child in gameObject.transform) {
                    child.GetComponent<MeshRenderer>().material.color =
                        colorRatio * (targetColor - colors[counter]) + colors[counter++];
                }
            }
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