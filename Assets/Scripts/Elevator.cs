using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {
	public float moveHeight = 10;
	public float speed = 1;
	private bool powered;
	public Vector3 origPos;
	// Use this for initialization
	void Start () {
		powered = false;
		origPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(powered) {
			transform.position = Vector3.Slerp(transform.position, origPos + Vector3.up * moveHeight, Time.deltaTime * speed);	                                   
		}
		else if(transform.position != origPos) {
			transform.position = Vector3.Slerp(transform.position, origPos, Time.deltaTime * speed);
		}
	}

	void OnCollisionEnter(Collision col) {
		col.transform.root.SetParent(transform);
	}

	void OnCollisionExit(Collision col) {
		col.transform.SetParent(null);
	}

	IEnumerator Toggle() {
		yield return new WaitForSeconds(1.0f);
		powered = !powered;
	}
}
