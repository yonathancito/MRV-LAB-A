﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsFromHeaven : MonoBehaviour {

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	//void Update () {
		
	//}

	public GameObject ball;
	public float startHeight = 10f;
	public float fireInterval = 0.5f;

	private float nextBallTime = 0.0f;

	void Update () {
		if (Time.time > nextBallTime) {
			nextBallTime = Time.time + fireInterval;
			Vector3 position = new Vector3( Random.Range (-4.0f, 4.0f),
				startHeight, Random.Range (-4.0f, 4.0f) );
			Instantiate( ball, position, Quaternion.identity );
		}
	}
}
