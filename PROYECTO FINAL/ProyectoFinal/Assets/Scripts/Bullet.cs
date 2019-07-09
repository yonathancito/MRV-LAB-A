using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Transform target;

	public float speed = 10f;
	public float damage = 5f; //daño


    //La actualización se llama una vez por trama
    void Update () {

		//Compruebe si el objetivo existe
		if (target != null) {
            //Mover a la posición del objetivo.  
            transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		} 
		else {
			Destroy (gameObject);
		}
				
	}

	public void OnTriggerEnter(Collider other){
		GameObject obj = other.gameObject;

        //Comprueba si es el enemigo
        if (obj.tag == "Enemy") {
			
			obj.SendMessage ("Hurt", damage); //le hace daño
			Destroy (gameObject);
		}
		else if(obj.tag == "Ground"){
			Destroy (gameObject);
		}
	}
}
