using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof (Terminal))]
public class TerminalEditor : Editor {
	Terminal term;
	void OnEnable() {
		term = (Terminal)target;
	}
	
	void OnSceneGUI() {
		Handles.color = term.keyColor;
		Handles.DrawWireDisc(term.transform.position, Vector3.up, 1.0f);
	}
}
