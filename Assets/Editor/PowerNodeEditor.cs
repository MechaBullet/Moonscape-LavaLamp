using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof (PowerNode))]
public class PowerNodeEditor : Editor {
	PowerNode node;
	void OnEnable() {
		node = (PowerNode)target;
	}
	
	void OnSceneGUI() {
		Handles.color = node.matColor;
		Handles.DrawWireDisc(node.transform.position, Vector3.up, 1.0f);
	}
}
