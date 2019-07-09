using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public float range = 3f;
	public float fireRate = 1f;
	public GameObject bulletPrefab;
	public Transform barrelExit;

	Transform target;
	float fireCounter = 0;

	void Update(){
		
		FindNextTarget ();

		if (target != null) {

			AimAtTarget ();
			Shoot ();
		}
	}


	void FindNextTarget(){
        //Mira quién está en nuestro rango.
        int layerMask = 1 << 8;
		Collider[] enemies = Physics.OverlapSphere(transform.position, range, layerMask);
        //Compruebe si estamos en rango
        if (enemies.Length > 0) {
            //Supongamos que el primer enemigo es el más cercano
            target = enemies[0].gameObject.transform;

            //Recorre todos los enemigos.
            foreach (Collider enemy in enemies) {
                //Calcula la distancia del enemigo a la torre.
                float distance = Vector3.Distance (transform.position, enemy.transform.position);

                //Ver quien esta mas cerca

                if (distance < Vector3.Distance (transform.position, target.position)) {
					target = enemy.gameObject.transform;
				}
			}
		} 
		else {
			target = null;
		}
	}

	void AimAtTarget(){
  
        //Mira nuestro objetivo
        Vector3 lookPos = target.position-transform.position;
		lookPos.y = 0;

		Quaternion rotation = Quaternion.LookRotation(lookPos);
		transform.rotation = rotation;
	}

	void Shoot(){

        //A ver si podemos disparar ya?
        if (fireCounter <= 0) {
			GameObject newBullet = Instantiate (bulletPrefab, barrelExit.position, Quaternion.identity);
			newBullet.GetComponent<Bullet>().target = target;
			fireCounter = fireRate;
		}
		else {
			fireCounter -= Time.deltaTime;
		}
	}


}
