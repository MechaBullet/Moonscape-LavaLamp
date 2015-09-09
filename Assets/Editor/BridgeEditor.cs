using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof (Bridge))]
public class BridgeEditor : Editor {
	private Bridge bridge;
	// Use this for initialization
	void OnEnable() {
		bridge = (Bridge)target;
	}
	
	void OnSceneGUI() {
		Vector3 origPos;
		if(bridge.origPos == Vector3.zero)
			origPos = bridge.transform.position;
		else
			origPos = bridge.origPos;
		float width = bridge.width;
		
		Handles.DrawLine(origPos, origPos + bridge.transform.forward * width);
	}
}
