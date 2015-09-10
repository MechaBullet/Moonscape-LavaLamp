using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCollection : MonoBehaviour {
	public int shards = 0;
	public int cores = 0;
	private Text shardCount;
	private Text coreCount;

	void Start() {
		shardCount = GameObject.Find("Canvas/ShardCount").GetComponent<Text>();
		coreCount = GameObject.Find("Canvas/CoreCount").GetComponent<Text>();

		UpdateCounts();
	}

	public void AddShard() {
		AudioSource source = PlayClipAt(Resources.Load("SFX/Sine/Sine_" + RandomNote()) as AudioClip, transform.position);
		source.dopplerLevel = 0;

		shards++;
		UpdateCounts();
	}

	public void AddCore() {
		AudioSource source = PlayClipAt(Resources.Load("SFX/Saw/Saw " + RandomNote()) as AudioClip, transform.position);
		source.dopplerLevel = 0;

		cores++;
		UpdateCounts();
	}

	public void UpdateCounts() {
		shardCount.text = "Shards: " + shards;
		coreCount.text = "Cores: " + cores;
	}

	public string RandomNote() {
		string[] notes = new string[8]{"c", "A", "B", "C", "D", "E", "F", "G"};
		return notes[Random.Range(0, notes.Length - 1)];
	}

	AudioSource PlayClipAt(AudioClip clip, Vector3 pos) {
		GameObject tempGO = new GameObject("TempAudio");//GameObject("TempAudio"); // create the temp object
		tempGO.transform.position = pos; // set its position
		AudioSource aSource = tempGO.AddComponent<AudioSource>(); // add an audio source
		aSource.clip = clip; // define the clip
		// set other aSource properties here, if desired
		aSource.Play(); // start the sound
		Destroy(tempGO, clip.length); // destroy object after clip duration
		return aSource; // return the AudioSource reference
	}
}
