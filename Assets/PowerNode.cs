using UnityEngine;
using System.Collections;

public class PowerNode : MonoBehaviour {
	public Color matColor = new Color(204, 251, 254);

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.SetColor("_EmissionColor", matColor);
		GetComponent<Light>().color = matColor;
	}
}
