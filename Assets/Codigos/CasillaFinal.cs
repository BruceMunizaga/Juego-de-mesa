using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasillaFinal : MonoBehaviour
{
    Vector3 posicion = new Vector3();
    public void DesplegarfinalJuego(string nombreJugador, int turnosJugados){
        //TODO: agregar funcionalidad que despliegue por pantalla el nombre del jugador ganador y los turnos que tomó
    }

    public Vector3 getPosicion(){
        return this.posicion;
    }
}