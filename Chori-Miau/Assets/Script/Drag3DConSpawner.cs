using UnityEngine;

public class Drag3DConSpawner : MonoBehaviour {
    private Camera cam;
    private bool dragging = false;

    public float dragDistance = 2f;
    public SpawnerConLimite spawner;
    private bool yaSpawneo = false;

    void Start() {
        cam = Camera.main;
    }

    void Update() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Ray ray = cam.ScreenPointToRay(touch.position);

            if (touch.phase == TouchPhase.Began) {
                if (Physics.Raycast(ray, out RaycastHit hit)) {
                    if (hit.transform == transform) {
                        dragging = true;

                        // Spawnea nuevo solo una vez
                        if (!yaSpawneo && spawner != null) {
                            spawner.SpawnearNuevo();
                            yaSpawneo = true;
                        }
                    }
                }
            }

            if (touch.phase == TouchPhase.Moved && dragging) {
                Vector3 pos = ray.GetPoint(dragDistance);
                transform.position = new Vector3(pos.x, transform.position.y, pos.z);
            }

            if (touch.phase == TouchPhase.Ended) {
                dragging = false;
            }
        }
    }

    void OnDestroy() {
        if (spawner != null) {
            spawner.EliminarObjeto(gameObject);
        }
    }
}
