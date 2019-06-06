using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhibitionRide : MonoBehaviour {

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	//void Update () {
		
	//}

	public GameObject artworks;		//variable de las ilustraciones de GameObject se debe inicializar en el elemento principal (Artworks)
	public float startDelay = 3f;	//número de segundos antes de que comience la carrera
	public float transitionTime = 5f;	//tiempo que se tarda en viajar desde una posición de foto a otra

	private AnimationCurve xCurve, zCurve, rCurve;	//para las posiciones X y Z y la rotación del eje y en cada posición de visualización
	void Start () {
		int count = artworks.transform.childCount + 1;
		Keyframe[] xKeys = new Keyframe[count];
		Keyframe[] zKeys = new Keyframe[count];
		Keyframe[] rKeys = new Keyframe[count];
		int i = 0;
		float time = startDelay;
		xKeys [0] = new Keyframe (time, transform.position.x);
		zKeys [0] = new Keyframe (time, transform.position.z);
		rKeys [0] = new Keyframe (time, transform.rotation.y);
		foreach (Transform artwork in artworks.transform) {
			i++;
			time += transitionTime;
			Vector3 pos = artwork.position - artwork.forward;
			xKeys[i] = new Keyframe( time, pos.x );
			zKeys[i] = new Keyframe( time, pos.z );
			rKeys[i] = new Keyframe( time, artwork.rotation.y );
		}

		xCurve = new AnimationCurve (xKeys);
		zCurve = new AnimationCurve (zKeys);
		rCurve = new AnimationCurve (rKeys);
	}
	void Update () {
		transform.position = new Vector3 (xCurve.Evaluate
			(Time.time), transform.position.y, zCurve.Evaluate
			(Time.time));
		Quaternion rot = transform.rotation;
		rot.y = rCurve.Evaluate (Time.time);
		transform.rotation = rot;
	}

}
