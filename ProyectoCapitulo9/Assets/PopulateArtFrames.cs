using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateArtFrames : MonoBehaviour {

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	//void Update () {
		
	//}

	public Texture[] images;
	void Start () {
		int imageIndex = 0;
		foreach (Transform artwork in transform) {
			GameObject art = artwork.FindChild("Image").gameObject;
			Renderer rend = art.GetComponent<Renderer>();
			Shader shader = Shader.Find("Standard");
			Material mat = new Material( shader );
			mat.mainTexture = images[imageIndex];
			rend.material = mat;
			imageIndex++;
			if (imageIndex == images.Length) imageIndex = 0;
		}
	}

}
