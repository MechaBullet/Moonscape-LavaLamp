using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof (Elevator))]
public class ElevatorEditor : Editor {
	private Elevator el;
	// Use this for initialization
	void OnEnable() {
		el = (Elevator)target;
	}

	void OnSceneGUI() {
		Vector3 origPos;
		if(el.origPos == Vector3.zero)
			origPos = el.transform.position;
		else
			origPos = el.origPos;
		float moveHeight = el.moveHeight;

		Handles.DrawLine(origPos, origPos + Vector3.up * moveHeight);
	}
}
