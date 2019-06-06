using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePositionalTracking : MonoBehaviour {

	private Vector3 position;
	void Start () {
		position = Camera.main.transform.position;
	}
	void Update () {
		Camera.main.transform.position = position;
	}
}
