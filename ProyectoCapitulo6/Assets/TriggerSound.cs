using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour {

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	//void Update () {
		
	//}
	public AudioSource audio;
	public AudioClip hitSound;
	void Start() {
		audio = GetComponent<AudioSource> ();
	}
	void OnTriggerEnter(Collider other) {
		audio.Play ();
	}
}
