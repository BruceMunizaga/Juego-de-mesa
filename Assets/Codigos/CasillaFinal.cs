using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasillaFinal : MonoBehaviour
{

    //Instancia de la clase dado
    public Dado dado = new Dado();

    //variable texto para mostrar en pantalla
    public string texto;

    //Instancia del texto
    public Text textElement;

    /*
    Metodo que dara por terminado el juego desplegando los datos del jugador ganador
    */
    public void DesplegarfinalJuego(string nombreJugador, int turnosJugados){
        string turnosString = turnosJugados.ToString();
        dado.gameObject.SetActive(false);
        textElement.text = nombreJugador + " ganó con " + turnosString +" turnos jugados.";
    }
}