using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField]CasillaFinal casillaFinal = new CasillaFinal();
    [SerializeField]Dado dado = new Dado();
    [SerializeField]Tablero tablero = new Tablero();
    [SerializeField]string nombreJugador;
    [SerializeField]Vector3 posicionActual;
    [SerializeField]int turnosJugados;

    public Jugador(string nuevoNombre, Vector3 nuevaPosicion){
        this.nombreJugador = nuevoNombre;
        this.posicionActual = nuevaPosicion;
        this.turnosJugados = 0;
    }

    public void Jugar(){
        IncrementarTurnosJugados();
        int nuevaPosicion = dado.lanzarDado();
        SetPosicionActual(tablero.getPosicion(nuevaPosicion));

        if(this.posicionActual == casillaFinal.getPosicion()){
            TerminarJuego();
        }
    }

    public void IncrementarTurnosJugados(){
        this.turnosJugados++;
    }

    public void SetPosicionActual(Vector3 nuevaPosicion){
        this.posicionActual = nuevaPosicion;
    }

    public void TerminarJuego(){
        casillaFinal.DesplegarfinalJuego(this.nombreJugador, this.turnosJugados);
    }
}
