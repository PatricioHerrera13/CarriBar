using System.Collections.Generic; // Necesario para List<>
using UnityEngine;

[System.Serializable]
public class Pedido {
    public string tipoPan;
    public string tipoChori;
    public List<string> salsas;

    // Constructor útil si querés crear pedidos por código
    public Pedido(string pan, string chori, List<string> salsasElegidas) {
        tipoPan = pan;
        tipoChori = chori;
        salsas = new List<string>(salsasElegidas);
    }

    // Comparar si otro pedido es igual (para evaluar si el jugador acertó)
    public bool EsIgual(Pedido otro) {
        if (tipoPan != otro.tipoPan || tipoChori != otro.tipoChori)
            return false;

        if (salsas.Count != otro.salsas.Count)
            return false;

        foreach (string salsa in salsas) {
            if (!otro.salsas.Contains(salsa))
                return false;
        }

        return true;
    }
}
