using Photon.Pun;
using UnityEngine;

public class Board0Controller : MonoBehaviour {
	public GameObject[] boards;

	public int index = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DropBoard() {
		if (index < boards.Length - 2) {
			boards[index].transform.parent = null;
			boards[index].AddComponent<Rigidbody>();
			boards[index].AddComponent<PhotonRigidbodyView>();
			boards[index++].AddComponent<BoxCollider>();
		}
		else {
			boards[index].transform.parent = null;
			boards[index].AddComponent<Rigidbody>();
			boards[index].AddComponent<PhotonRigidbodyView>();
			boards[index++].AddComponent<BoxCollider>();
			boards[index].transform.parent = null;
			boards[index].AddComponent<Rigidbody>();
			boards[index].AddComponent<PhotonRigidbodyView>();
			boards[index++].AddComponent<BoxCollider>();
			Destroy(this.gameObject);
		}
	}

	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.name == "Axe"&&index < 3) {
			DropBoard();
		}
			
	}
}
