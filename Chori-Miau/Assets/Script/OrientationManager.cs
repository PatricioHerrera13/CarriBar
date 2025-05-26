using UnityEngine;

public class OrientationManager : MonoBehaviour {
    void Start() {
        // Forzar landscape
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        // Bloquear auto-rotación si es necesario
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.orientation = ScreenOrientation.AutoRotation; // Si querés permitir landscape izquierda/derecha
    }
}
