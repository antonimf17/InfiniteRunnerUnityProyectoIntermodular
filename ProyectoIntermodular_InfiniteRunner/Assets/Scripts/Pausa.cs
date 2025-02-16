using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pausa : MonoBehaviour
{
    private bool juegoPausado = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  // Solo activar opciones con Escape
        {
            Pausas();
        }
        
    }

    public void Pausas()
    {
        if (GameManager.inst == null || GameManager.inst.panelPausa == null)
        {
            Debug.LogWarning("GameManager o panelPausa no están asignados.");
            return;
        }

        juegoPausado = !juegoPausado;

        // Activa o desactiva el panel de pausa
        GameManager.inst.panelPausa.SetActive(juegoPausado);

        // Cambia la escala del tiempo
        Time.timeScale = juegoPausado ? 0 : 1;

        // Evita que la UI seleccione automáticamente un botón
        EventSystem.current.SetSelectedGameObject(null);
    }

}
