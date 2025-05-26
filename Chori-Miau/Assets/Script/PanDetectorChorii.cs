using UnityEngine;

public class PanDetectorChorii : MonoBehaviour {
    public GameObject choripanPrefab; // Prefab combinado
    private bool yaCombinado = false;

    void OnTriggerEnter(Collider other) {
        if (yaCombinado) return;

        if (other.CompareTag("Chori")) {
            Transform parentTabla = transform.parent; // el slot
            if (parentTabla == null) return;

            TablaSlot tabla = parentTabla.parent?.GetComponent<TablaSlot>();
            if (tabla != null && tabla.HayPan()) {
                GameObject nuevo = Instantiate(choripanPrefab, parentTabla.position, Quaternion.identity);
                Destroy(other.gameObject); // Destruir chori
                Destroy(this.gameObject); // Destruir pan

                tabla.RemoverPan(); // Limpiar slot
                yaCombinado = true;
            }
        }
    }
}
