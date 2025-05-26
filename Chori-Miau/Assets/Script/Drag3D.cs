using UnityEngine;

public class Drag3D : MonoBehaviour {
    private Camera cam;
    private bool dragging = false;

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
                    }
                }
            }

            if (touch.phase == TouchPhase.Moved && dragging) {
                Vector3 touchPosition = ray.GetPoint(2f); // Ajustá la distancia si querés
                transform.position = new Vector3(touchPosition.x, transform.position.y, touchPosition.z);
            }

            if (touch.phase == TouchPhase.Ended) {
                dragging = false;
            }
        }
    }
}
