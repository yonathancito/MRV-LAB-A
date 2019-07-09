using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float health = 20f;	//salud
	float currentHealth;	//salud actual

	public GameObject healthBarPrefab;   //barra de salud
	GameObject healthBar;  //barra de salud

	public float worth = 4f;	//valor

	public Transform currentWaypoint;	//punto de ruta actual
	public float moveSpeed = 1f;

	public float damage = 5f;

	void Awake(){ //despierta
		currentHealth = health;			//instanciar
		healthBar = Instantiate (healthBarPrefab, transform.position + new Vector3 (0, 0, 0.25f), Quaternion.identity, transform);
	}


	void Update(){

		//Mueve a nuestro enemigo
		transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);

		//Hemos llegado
		if (transform.position.Equals (currentWaypoint.position)) {

			//¿Tenemos el siguiente punto de ruta?
			if (currentWaypoint.GetComponent<Waypoint> ().nextWaypoint != null) {
				currentWaypoint = currentWaypoint.GetComponent<Waypoint> ().nextWaypoint;
			}
		}
	}


	public void Hurt(float damage){ //herir

		currentHealth -= damage;

		if(currentHealth<=0){
			Money.Amount += worth;
			Destroy (gameObject);
		}

        //Modifica la escala verde para reflejar el daño.
        Transform pivot = healthBar.transform.Find("HealthyPivot");
		Vector3 scale = pivot.localScale;
		scale.x = Mathf.Clamp (currentHealth / health, 0, 1);
		pivot.localScale = scale;
	}
}
