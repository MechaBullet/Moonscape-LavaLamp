using UnityEngine;
using System.Collections;

public class PowerCore : MonoBehaviour {
	void OnTriggerEnter(Collider col) {
		if(col.tag == "Player") {
			col.GetComponent<PlayerCollection>().AddCore();
			Destroy(gameObject);
		}
	}
}
