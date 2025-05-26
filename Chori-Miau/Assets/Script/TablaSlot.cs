using UnityEngine;

public class TablaSlot : MonoBehaviour {
    public Transform slotPan;  // Posición donde se coloca el pan
    private GameObject panActual;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Pan") && panActual == null) {
            // Coloca el pan en el slot
            panActual = other.gameObject;
            panActual.transform.position = slotPan.position;
            panActual.transform.rotation = slotPan.rotation;
            panActual.transform.SetParent(slotPan);
        }
    }

    public bool HayPan() {
        return panActual != null;
    }

    public GameObject ObtenerPan() {
        return panActual;
    }

    public void RemoverPan() {
        panActual = null;
    }
}
