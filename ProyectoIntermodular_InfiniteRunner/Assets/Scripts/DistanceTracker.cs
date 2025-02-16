using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Necesitas importar esto si usas TextMeshPro

public class DistanceTracker : MonoBehaviour
{
    // Variables para el c�lculo de la distancia
    private float initialZ;  // La posici�n Z inicial
    private float distanceTraveled;  // Distancia recorrida acumulada
    public TextMeshProUGUI distanceText;  // Asigna el TextMeshPro en el inspector para mostrar la distancia

    void Start()
    {
        // Registrar la posici�n Z inicial cuando el juego comienza
        initialZ = transform.position.z;
    }

    void Update()
    {
        // Calcular la distancia recorrida acumulada en el eje Z
        distanceTraveled = transform.position.z - initialZ;

        // Mostrar la distancia en la UI
        distanceText.text = "Distancia: " + distanceTraveled.ToString("F2") + " metros";
    }
}