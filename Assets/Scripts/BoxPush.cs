using UnityEngine;
using System.Collections;

public class BoxPush : MonoBehaviour {
	Vector3 targetPos;
	public int speed = 1;

	void Start() {
		targetPos = transform.position;
	}

	void OnCollisionStay(Collision col) {
		if(col.transform.tag == "Player" && transform.position == targetPos) {
			Vector3 pushDir = transform.position - col.transform.position;
			if(Mathf.Abs(pushDir.y) >= Mathf.Max(Mathf.Abs(pushDir.x), Mathf.Abs(pushDir.z))) {
				//Do nothing
			}
			else if(col.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().Grounded) {
				pushDir.y = 0;
				if(Mathf.Abs(pushDir.x) > Mathf.Abs(pushDir.z)) {
					pushDir.z = 0;
				}
				else {
					pushDir.x = 0;
				}
				targetPos = transform.position + pushDir.normalized;
				AudioSource source = ClipManager.PlayClipAt(Resources.Load("SFX/Bass/Bass_" + RandomNote()) as AudioClip, transform.position);
				source.dopplerLevel = 0.2f;
				source.volume = 0.75f;
				source.spatialBlend = 1;
			}
		}
	}

	void Update() {
		transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
	}

	public string RandomNote() {
		string[] notes = new string[]{"c", "A", "B", "C", "D", "E", "F", "G"};
		return notes[Random.Range(0, notes.Length - 1)];
	}
}
