using UnityEngine;
using System.Collections;

public class DomeGravity : MonoBehaviour {

	float origJump;

	void Awake() {
		origJump = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.JumpForce;
	}

	void OnTriggerEnter(Collider col) {
		if(col.tag == "Player") {
			col.transform.Find("MainCamera/Visor").GetComponent<Animator>().SetBool("Wearing", false);
			col.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.JumpForce = origJump;
			col.GetComponent<PlayerControl>().inGrav = true;
		}
	}

	void OnTriggerExit(Collider col) {
		if(col.tag == "Player") {
			col.transform.Find("MainCamera/Visor").GetComponent<Animator>().SetBool("Wearing", true);
			col.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.JumpForce = origJump * 2;
			col.GetComponent<PlayerControl>().inGrav = false;
		}
	}
}
