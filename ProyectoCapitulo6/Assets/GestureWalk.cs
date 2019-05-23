using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureWalk : MonoBehaviour {

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	//void Update () {
		
	//}


	private HeadLookWalk lookWalk;
	private HeadGesture gesture;
	void Start () {
		//retorna todo lo que hace HeadLookWalk
		lookWalk = GetComponent<HeadLookWalk> ();
		gesture = GameObject.Find ("GameController").
			GetComponent<HeadGesture> ();
	}
	void Update () {
		//si encuentra un gesto hacia abajo, el atributo de headLookWalk sera verdadero/falaso. 
		if (gesture.isMovingDown) {
			lookWalk.isWalking = !lookWalk.isWalking;
		}
	}

}
