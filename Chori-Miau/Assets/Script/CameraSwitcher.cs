using UnityEngine;

public class CameraSwitcher : MonoBehaviour {
    public Transform[] cameraPositions;
    public float smoothSpeed = 5f;

    private int currentIndex = 0;
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    void Update() {
        // Movimiento suave
        transform.position = Vector3.Lerp(transform.position, cameraPositions[currentIndex].position, Time.deltaTime * smoothSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraPositions[currentIndex].rotation, Time.deltaTime * smoothSpeed);

        DetectarSwipe();
    }

    void DetectarSwipe() {
        if (Input.touchCount == 1) {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) {
                startTouchPos = touch.position;
            }

            if (touch.phase == TouchPhase.Ended) {
                endTouchPos = touch.position;
                float deltaX = endTouchPos.x - startTouchPos.x;

                if (Mathf.Abs(deltaX) > 100f) { // Sensibilidad
                    if (deltaX > 0) {
                        MoverIzquierda();
                    } else {
                        MoverDerecha();
                    }
                }
            }
        }
    }

    public void MoverIzquierda() {
        currentIndex = Mathf.Max(0, currentIndex - 1);
    }

    public void MoverDerecha() {
        currentIndex = Mathf.Min(cameraPositions.Length - 1, currentIndex + 1);
    }
}
