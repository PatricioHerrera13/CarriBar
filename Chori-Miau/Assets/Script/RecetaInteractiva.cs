using UnityEngine;

public class RecetaInteractiva : MonoBehaviour {
    private bool estaCerca = false;
    private Vector3 posicionOriginal;
    public Transform posicionLectura;   // Empty cerca de la cámara
    public Transform posicionReposo;    // Empty donde la receta vuelve

    private Camera cam;

    void Start() {
        cam = Camera.main;
        posicionOriginal = transform.position;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit)) {
                if (hit.transform == transform) {
                    if (!estaCerca) {
                        MoverALectura();
                    } else {
                        VolverAReposo();
                    }
                }
            }
        }
    }

    void MoverALectura() {
        estaCerca = true;
        transform.position = posicionLectura.position;
        transform.rotation = posicionLectura.rotation;
    }

    void VolverAReposo() {
        estaCerca = false;
        transform.position = posicionReposo.position;
        transform.rotation = posicionReposo.rotation;
    }
}

