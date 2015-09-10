using UnityEngine;
using System.Collections;

public class Shard : MonoBehaviour {
	void OnTriggerEnter(Collider col) {
		if(col.tag == "Player") {
			col.GetComponent<PlayerCollection>().AddShard();
			Destroy(gameObject);
		}
	}
}
