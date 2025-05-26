using System.Collections.Generic;
using UnityEngine;

public class SpawnerConLimite : MonoBehaviour {
    public GameObject prefab;
    public Transform puntoSpawn;
    public int maxObjetos = 5;

    private List<GameObject> objetosEnEscena = new List<GameObject>();

    void Start() {
    SpawnearNuevo(); // Spawnea el primer objeto al inicio
    }


    public void SpawnearNuevo() {
        // Si ya hay 5, elimina el primero
        if (objetosEnEscena.Count >= maxObjetos) {
            Destroy(objetosEnEscena[0]);
            objetosEnEscena.RemoveAt(0);
        }

        // Crear nuevo
        GameObject nuevo = Instantiate(prefab, puntoSpawn.position, Quaternion.identity);
        objetosEnEscena.Add(nuevo);

        // Referencia al spawner en el drag script
        Drag3DConSpawner drag = nuevo.GetComponent<Drag3DConSpawner>();
        if (drag != null) {
            drag.spawner = this;
        }
    }

    public void EliminarObjeto(GameObject obj) {
        if (objetosEnEscena.Contains(obj)) {
            objetosEnEscena.Remove(obj);
        }
    }
}
