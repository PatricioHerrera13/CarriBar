using UnityEngine;

public class ParrillaSlotManager : MonoBehaviour {
    public Transform[] slots; // Asignar en inspector
    public float rangoDeColocacion = 1f;

    public void IntentarColocar(GameObject objeto) {
        foreach (Transform slot in slots) {
            if (slot.childCount == 0 && Vector3.Distance(objeto.transform.position, slot.position) < rangoDeColocacion) {
                objeto.transform.position = slot.position;
                objeto.transform.rotation = slot.rotation;
                objeto.transform.SetParent(slot); // Opcional
                return;
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Chori") || other.CompareTag("Pan")) {
            IntentarColocar(other.gameObject);
        }
    }
}
