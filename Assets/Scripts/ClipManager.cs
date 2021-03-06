﻿using UnityEngine;
using System.Collections;

public class ClipManager : MonoBehaviour {
	public static AudioSource PlayClipAt(AudioClip clip, Vector3 pos) {
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
