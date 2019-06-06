﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGesture : MonoBehaviour {

	public bool isJump = false;
	public float jumpForce = 1000.0f;

	private float jumpRate = 1.0f;
	private float previousHeight;
	private HeadLookWalkBounce walkBounce;

	void Start () {
		previousHeight = Camera.main.transform.position.y;
		walkBounce = GetComponent<HeadLookWalkBounce> ();
	}

	void Update () {
		if (DetectJump ()) {
			walkBounce.bounceForce = jumpForce;
		}
	}
	private bool DetectJump() {
		float height = Camera.main.transform.localPosition.y;
		float deltaHeight = height - previousHeight;
		float rate = deltaHeight / Time.deltaTime;
		previousHeight = height;
		return (rate >= jumpRate);
	}
}
