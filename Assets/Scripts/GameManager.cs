using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Elementos del puntaje")]

    public int Puntaje;
    public int mejorPuntaje;
    public Text TextoPuntaje;
    public Text TextoMejorPuntaje;
   

    [Header("Elementos Gamer Over")]
    public GameObject panelGamerOver;
    public Text TextoPuntajeFinal;
    public Text TextoMejorPuntajePanel;

    public void Awake()
    {
        panelGamerOver.SetActive(false);
        PonerMejorPuntaje();
       
    }

    private void PonerMejorPuntaje()
    {
        mejorPuntaje = PlayerPrefs.GetInt("MejorPuntaje");
        TextoMejorPuntaje.text = "Mejor: " + mejorPuntaje;
    }

    public void aumentarPuntaje()
    {
        Puntaje += 2;
        TextoPuntaje.text = Puntaje.ToString();

        if (Puntaje > mejorPuntaje)
        {
            PlayerPrefs.SetInt("MejorPuntaje ", Puntaje);
            TextoMejorPuntaje.text = "Mejor: " + Puntaje.ToString();
            mejorPuntaje = Puntaje; 
        }
    }

    public void AlTocarBomba()
    {
        panelGamerOver.SetActive(true);
        TextoPuntajeFinal.text = "Puntaje " + Puntaje.ToString();
        TextoMejorPuntajePanel.text = "Mejor puntaje: " + mejorPuntaje.ToString();
        Time.timeScale = 0;
    }

    public void Reiniciar()
    {
        Puntaje = 0;
        TextoPuntaje.text = Puntaje.ToString();
        Time.timeScale = 1;
        panelGamerOver.SetActive(false);

        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Interactivo"))
        {
            Destroy(g);
        }

    }
}
