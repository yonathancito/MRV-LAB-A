using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

	public float initialWaitTime = 5f;
	public float waveWaitTime = 5f;

	public GameObject[] enemyPrefabs;
	public Transform firstWaypoint;

	public Text waveText;

	public string nextLevel = "level #";

	List<Wave> waves = new List<Wave> ();
	int currentWave = -1;
	void Awake(){

		GetWaves ();
		StartCoroutine (WaveLoop ());
	}
	void GetWaves(){
		int child = 0;
        //Recorre cada objeto hijo en el desovador
        while (child < transform.childCount) {
            //Obtén el script de wave y muévete al siguiente hijo
            waves.Add(transform.GetChild(child).GetComponent<Wave>() );
			child++;
		}
	}
	IEnumerator WaveLoop(){
        //hacer una pausa antes de empezar, para la configuración
        yield return new WaitForSeconds(initialWaitTime);
        //recorrer cada onda
        while (currentWave < waves.Count) {
			//aumentar el contador de ondas 
			currentWave++;
			waveText.text = "Wave " + (currentWave + 1) + "/" + waves.Count;

            //Arranca la ola, pero espera hasta que termine.
            yield return StartCoroutine(StartNextWave());
		}

		while (GameObject.FindGameObjectsWithTag ("Enemy").Length > 0) {
			yield return new WaitForSeconds (1f);
		}

        //Todos los enemigos están muertos y el nivel ha terminado.
        SceneManager.LoadScene(nextLevel);
	}

	IEnumerator StartNextWave(){

        //Empezar a engendrar nuestros segmentos de olas.
        foreach (WaveSegment segment in waves[currentWave].PatternToWaveSegments()) {

            //engendrar nuestros enemigos
            yield return StartCoroutine(SpawnEnemies(segment.spawns));

			//esperar al final del segmento
			yield return new WaitForSeconds(segment.wait);
		}

        //hemos terminado la ola, espera entre olas
        yield return new WaitForSeconds(waveWaitTime);
	}

	IEnumerator SpawnEnemies(List<int> enemies){

		//recorrer los enemigos para engendrar
		foreach (int enemy in enemies) {

            //Crea al enemigo y asigna su primer punto de ruta.
            GameObject newEnemy = Instantiate(enemyPrefabs[enemy], transform.position, Quaternion.identity);
			newEnemy.GetComponent<Enemy> ().currentWaypoint = firstWaypoint;

			//Espera al próximo enemigo, para no juntarte.
			yield return new WaitForSeconds(0.5f);	

		}

	}
}
