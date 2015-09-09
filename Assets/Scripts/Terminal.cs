using UnityEngine;
using System.Collections;

public class Terminal : MonoBehaviour {
	public Color keyColor;
	public Transform[] target;
	public Transform node;
	private Transform screen;

	void Start() {
		screen = transform.Find("Base/Screen");
		screen.GetComponent<Renderer>().material.SetColor("_EmissionColor", keyColor);
	}

	void Update() {
		if(node) {
			node.position = transform.position + transform.up * 1.25f;
		}
	}

	public void SetOn(Transform _node) {
		if(_node.GetComponent<PowerNode>().matColor.ToHexStringRGB() == keyColor.ToHexStringRGB()) {
			node = _node;
			node.position = transform.position + transform.up * 1.25f;
			//node.parent = transform;
			node.GetComponent<Rigidbody>().isKinematic = true;
			node.GetComponent<Rigidbody>().velocity = Vector3.zero;

			for(int i = 0; i < target.Length; i++) {
				if(target[i].GetComponent<Animator>())
					target[i].GetComponent<Animator>().SetBool("Powered", true);
				if(target[i].GetComponent<Elevator>())
					target[i].GetComponent<Elevator>().StartCoroutine("Toggle");// = true;
				if(target[i].GetComponent<Bridge>())
					target[i].GetComponent<Bridge>().StartCoroutine("Toggle");
			}

			GetComponent<Animator>().SetBool("Powered", true);
		}
	}

	public void SetOff() {
		node.GetComponent<Rigidbody>().isKinematic = false;
		//node.parent = null;

		for(int i = 0; i < target.Length; i++) {
			if(target[i].GetComponent<Animator>())
				target[i].GetComponent<Animator>().SetBool("Powered", false);
			if(target[i].GetComponent<Elevator>())
				target[i].GetComponent<Elevator>().StartCoroutine("Toggle");
			if(target[i].GetComponent<Bridge>())
				target[i].GetComponent<Bridge>().StartCoroutine("Toggle");
		}

		GetComponent<Animator>().SetBool("Powered", false);
		node = null;
	}
}
