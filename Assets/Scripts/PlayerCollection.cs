﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCollection : MonoBehaviour {
	public int shards = 0;
	public int cores = 0;
	private Text shardCount;
	private Text coreCount;
	private int allShards = 0;
	private int allCores = 0;

	void Start() {
		shardCount = GameObject.Find("Canvas/ShardCount").GetComponent<Text>();
		coreCount = GameObject.Find("Canvas/CoreCount").GetComponent<Text>();
		allShards = GameObject.FindGameObjectsWithTag("Shard").Length;
		allCores = GameObject.FindGameObjectsWithTag("Core").Length;

		UpdateCounts();
	}

	public void AddShard() {
		AudioSource source = ClipManager.PlayClipAt(Resources.Load("SFX/Sine/Sine_" + RandomNote()) as AudioClip, transform.position);
		source.dopplerLevel = 0;

		shards++;
		UpdateCounts();
	}

	public void AddCore() {
		AudioSource source = ClipManager.PlayClipAt(Resources.Load("SFX/Saw/Saw " + RandomNote()) as AudioClip, transform.position);
		source.dopplerLevel = 0;

		cores++;
		UpdateCounts();
	}

	public void UpdateCounts() {
		shardCount.text = "Shards: " + shards + "/" + allShards;
		coreCount.text = "Cores: " + cores + "/" + allCores;
	}

	public string RandomNote() {
		string[] notes = new string[8]{"c", "A", "B", "C", "D", "E", "F", "G"};
		return notes[Random.Range(0, notes.Length - 1)];
	}
}
