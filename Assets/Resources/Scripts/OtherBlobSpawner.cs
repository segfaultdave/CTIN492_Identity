﻿using UnityEngine;
using System.Collections;

public class OtherBlobSpawner : MonoBehaviour {

	public bool inFrontOfPlayer;
	
	float xThreshold = 16f;
	GameObject player;
	Timer spawnTimer;

	// Use this for initialization
	void Awake () {
		player = GameObject.Find("Player");
		spawnTimer = new Timer(NewSpawnTime);
	}


	float NewSpawnTime { get { return UnityEngine.Random.Range(4f, 8f); } }


	void SpawnBlob () {
		GameObject g = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/OtherBlob"));
		g.transform.position = (Vector2)(transform.position) + (Vector2)(UnityEngine.Random.Range(-5f, 5f) * Vector2.up);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = player.transform.position.x;

		if (spawnTimer.IsOffCooldown && Mathf.Abs(x - transform.position.x) < xThreshold && x > 20f) {
			spawnTimer.Reset();
			SpawnBlob();
			spawnTimer.CooldownTime = NewSpawnTime;
		}
		
		if (inFrontOfPlayer) {
			 x += xThreshold;
		} else {
			x -= xThreshold;
		}
		transform.position = new Vector2(x, -6.5f);
	}
}
