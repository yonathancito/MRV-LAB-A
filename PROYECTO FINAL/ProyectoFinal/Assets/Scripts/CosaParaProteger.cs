using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosaParaProteger : MonoBehaviour {

	public float health = 100f;
	float currentHealth;

	public GameObject healthBarPrefab;
	GameObject healthBar;

	void Awake(){

		currentHealth = health;			//instanciar
		healthBar = Instantiate (healthBarPrefab, transform.position + new Vector3 (0, 0.5f, 1f), Quaternion.identity, transform);
	}

	private void OnTriggerEnter(Collider other){

		GameObject obj = other.gameObject;

        //Comprueba si es un enemigo.

        if (obj.tag == "Enemy") {

			currentHealth -= obj.GetComponent<Enemy> ().damage;

            //Modifica la escala verde para reflejar el daño.
            Transform pivot = healthBar.transform.Find("HealthyPivot");
			Vector3 scale = pivot.localScale;
			scale.x = Mathf.Clamp (currentHealth / health, 0, 1);
			pivot.localScale = scale;

			Destroy (obj);

            //¿Ya estamos muertos?
            CheckHealth();
		}
	}
	void CheckHealth()
    {
        //¿Nos queda algo de salud ?
        if (currentHealth <= 0) {
			Destroy (gameObject);
		}
	}
		
}
