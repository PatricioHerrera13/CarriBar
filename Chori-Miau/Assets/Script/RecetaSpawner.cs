using UnityEngine;

public class RecetaSpawner : MonoBehaviour {
    public GameObject recetaPrefab;      // Prefab 3D de la receta
    public int cantidad = 3;
    public Transform puntoInicial;       // Punto desde donde empieza el stack
    public float separacionY = 1.2f;     // Distancia entre recetas en Y

    void Start() {
        for (int i = 0; i < cantidad; i++) {
            Vector3 posicion = puntoInicial.position + new Vector3(0, -i * separacionY, 0);
            Instantiate(recetaPrefab, posicion, Quaternion.identity);
        }
    }
}
