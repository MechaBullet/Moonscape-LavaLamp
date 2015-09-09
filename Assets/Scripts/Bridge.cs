using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour {
	public float width = 10;
	public float speed = 2;
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
			//Move the platform out
			transform.position = Vector3.Lerp(transform.position, origPos + transform.forward * (width/2), Time.deltaTime * speed);
			//Increase the area of the platform
			Vector3 scale = transform.localScale;
			scale.z = Mathf.Lerp(scale.z, width, Time.deltaTime * speed);
			transform.localScale = scale;
		}
		else {
			transform.position = Vector3.Lerp(transform.position, origPos, Time.deltaTime * speed);

			Vector3 scale = transform.localScale;
			scale.z = Mathf.Lerp(scale.z, 0, Time.deltaTime * speed);
			transform.localScale = scale;
		}
	}
	

	public IEnumerator Toggle() {
		yield return new WaitForSeconds(1.0f);
		powered = !powered;
	}
}
