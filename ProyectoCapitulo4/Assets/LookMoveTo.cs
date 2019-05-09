﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMoveTo : MonoBehaviour {

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	//void Update () {
		
	//}

	public GameObject ground;
	void Update () {
		Transform camera = Camera.main.transform;
		Ray ray;
		RaycastHit[] hits;
		GameObject hitObject;
		Debug.DrawRay (camera.position, camera.rotation *
			Vector3.forward * 300.0f);
		ray = new Ray (camera.position, camera.rotation *
			Vector3.forward);
		hits = Physics.RaycastAll (ray);
		for (int i = 0; i < hits.Length; i++) {
			RaycastHit hit = hits [i];
			hitObject = hit.collider.gameObject;
			if (hitObject == ground) {
				Debug.Log ("Hit (x,y,z): " +
					hit.point.ToString("F2"));
				transform.position = hit.point;
			}
		}
	}
}
