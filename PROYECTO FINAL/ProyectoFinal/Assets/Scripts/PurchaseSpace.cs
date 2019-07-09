using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseSpace : MonoBehaviour {

	public Text moneyText;

	public GameObject basicTowerPrefab;
	GameObject boughtTower;

	void Update () {
		moneyText.text = "Money $" + Money.Amount;

        //Asegúrate de tener una torre para moverte.
        if (boughtTower != null) {
			
			MovePurchasedTower ();
			CheckForWall ();
		}

	}

	void MovePurchasedTower(){

        //mueve la torre enfrente de la cámara
        boughtTower.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 5;
	}


	void CheckForWall(){

        //crea nuestro raycast
        Ray raycast = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hit;

        //TODO: quitar la siguiente línea
        Debug.DrawRay(raycast.origin, raycast.direction * 100);

        //Compruebe si el raycast golpea algo
        if (Physics.Raycast(raycast, out hit))
        {

			//¿Golpeamos una pared ?

            if (hit.collider.gameObject.tag == "Pared") {

                //Pon la torre encima de la pared.
                boughtTower.transform.position = hit.collider.gameObject.transform.position + new Vector3(0, 0.75f, 0);

                //Compruebe el clic en el botón de cartón

                if (Input.GetMouseButtonDown (0)) {

                    //Quitar la etiqueta de la pared
                    hit.collider.gameObject.tag = "Untagged";

                    //Hacer la torre NO transparente
                    Color coluor = boughtTower.GetComponent<Renderer>().material.color;
					coluor.a = 1f;
					boughtTower.GetComponent<Renderer> ().material.color = coluor;

                    //Habilitar el script
                    boughtTower.GetComponent<Tower>().enabled = true;

                    //Desconecta de la torre para comprar otra.
                    boughtTower = null;
				}

		
			}
		}
	}


	public void BuyBasicTower(){
		
		//Do yu have enough money, have you already bought a tower?
		if (Money.Amount < 40 || boughtTower != null)
			return;
		//Spawn a new tower
		boughtTower = Instantiate (basicTowerPrefab, transform.position, Quaternion.identity);

		//Make the tower transparent
		Color coluor = boughtTower.GetComponent<Renderer>().material.color;
		coluor.a = 0.5f;
		boughtTower.GetComponent<Renderer> ().material.color = coluor;

		//Take away their money
		Money.Amount -= 40;
	}
}
