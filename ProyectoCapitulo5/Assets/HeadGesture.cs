using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadGesture : MonoBehaviour {

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	//void Update () {
		
	//}


	public bool isFacingDown = false;
	void Update () {
		isFacingDown = DetectFacingDown ();
	}
	private bool DetectFacingDown () {
		return (CameraAngleFromGround () < 200.0f);
	}
	private float CameraAngleFromGround () {
		return Vector3.Angle (Vector3.down, Camera.main.transform.rotation
			* Vector3.forward);
	}

}
