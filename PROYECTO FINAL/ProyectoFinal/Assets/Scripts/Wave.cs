using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSegment{
	public List<int> spawns = new List<int> ();
	public int wait;
}
public class Wave : MonoBehaviour {
	[TextArea(3, 10)]
	public string pattern;
	public WaveSegment[] PatternToWaveSegments(){
		//Corta las líneas en el patrón.
		string[] lines = pattern.Split('\n');
        //Crea una lista que será devuelta al final.
        List<WaveSegment> segments = new List<WaveSegment>();
        //recorre cada línea del patrón
        foreach (string line in lines) {
            //crear un nuevo segmento de onda
            WaveSegment segment = new WaveSegment();
			//cortar la línea en engendros y tiempo
			string[] spawns = line.Split(' ');
			//Recorre los números generados, ignorando el tiempo de espera.
			for (int i = 0; i < spawns.Length - 1; i++) {
				segment.spawns.Add (int.Parse (spawns [i]));
			}
            //agregar el último número como el tiempo de espera
            segment.wait = int.Parse(spawns[spawns.Length-1]);
            //Ahora agrega el segmento a la ola.
            segments.Add(segment);
		}
        //Ya terminamos, devolvemos el segmento de la ola.
        return segments.ToArray();
	}
}
