using UnityEngine;
using System.Collections;

public class PlayerAcrobatics : MonoBehaviour {
	public float jumpForce = 10;
	public float checkDistance = 1;
	UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController controller;

	void Start() {
		controller = GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
	}

	void Update() {
		if(Input.GetButtonDown("Jump") && !controller.Grounded) {
			RaycastHit hit;
			//Check right
			if(Physics.CapsuleCast(transform.position + Vector3.up, transform.position - Vector3.up, 0.5f, transform.right, out hit, checkDistance, ~(1 << LayerMask.NameToLayer("Observable")))) {
				Debug.Log("Walljump - Right");
				WallJump(-1);
			}
			//Check left
			else if (Physics.CapsuleCast(transform.position + Vector3.up, transform.position - Vector3.up, 0.5f, -transform.right, out hit, checkDistance, ~(1 << LayerMask.NameToLayer("Observable")))) {
				Debug.Log("Walljump - Left");
				WallJump(1);
			}
		}
	}

	void WallJump(int side) {
		Rigidbody body = GetComponent<Rigidbody>();
		Vector3 vel = body.velocity;
		vel.y = 0;
		body.velocity = vel;
		body.AddRelativeForce(new Vector3(jumpForce * side, jumpForce, 0), ForceMode.Impulse);
	}
}
