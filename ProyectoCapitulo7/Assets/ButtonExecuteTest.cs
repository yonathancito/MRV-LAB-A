using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonExecuteTest : MonoBehaviour {

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	//void Update () {
		
	//}


	private GameObject startButton, stopButton;
	private bool on = false;
	private float timer = 5.0f;
	void Start () {
		startButton = GameObject.Find ("StartButton");
		stopButton = GameObject.Find ("StopButton");
	}
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0.0f) {
			on = !on;
			timer = 5.0f;
			PointerEventData data = new PointerEventData
				(EventSystem.current);
			if (on) {
				ExecuteEvents.Execute<IPointerClickHandler> (startButton,
					data, ExecuteEvents.pointerClickHandler);
			} else {
				ExecuteEvents.Execute<IPointerClickHandler> (stopButton,
					data, ExecuteEvents.pointerClickHandler);
			}
		}
	}

}
