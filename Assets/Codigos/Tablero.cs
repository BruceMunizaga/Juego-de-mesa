using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    int siJugador = 0; //Cantidad de jugadores al iniciar el juego

    //arreglo que identifica a que jugador le toca lanzar el dado
    bool[] validadorTurnos = {true, false, false, false};

    //Instancia de la clase dado
    [SerializeField]Dado dado = new Dado();

    //arreglo que contiene a los jugadores
    [SerializeField]Jugador[] jugadores = new Jugador[4];

    //arreglo que ayudara con la cardinalidad de los turnos
    [SerializeField]int[] turnos = new int[4];

    //Contenedor de las posiciones en el tablero
    public Transform[] posiciones;

    //Instancia de la clase CasillaFinal
    [SerializeField]CasillaFinal casillaFinal = new CasillaFinal();

    //Contenedor de las casillas normales en el tablero
    int[] casillasNormales = {1,2,4,5,7,8,10,11,12,14,16,17,18,19};

    //Contenedor de las casillas verdes
    int[] casillasVerdes = {3,9};

    //Contenedor de las casillas negras
    int[] casillasNegras = {13,20};

    //Contenedor de las casillas amarillas
    int[] casillasAmarillas ={6,15};

    /*
    Metodo que se ejecuta al cargar el tablero
    */
    void Start(){

        //Se llama al metodo que cargara la cantidad de jugadores
        CargarDatos();

        //se inicializa el arreglo de posiciones
        this.posiciones = new Transform[transform.childCount];
        for(int i = 0 ; i < transform.childCount; i++){
            this.posiciones[i] = transform.GetChild(i);
        }
    }

    /*
    Metodo que cargara los datos de la escena anterior
    */
    public void CargarDatos(){

        //variable que aloja la cantidad de jugadores en la partida
        int cantidadJugadores = GuardarDato.jugadores;

        //condicionales que actuaran en base a la cantidad de jugadores en partida
        if(cantidadJugadores == 1){
            this.turnos[0] = 1;
            this.jugadores[1].gameObject.SetActive(false);
            this.jugadores[2].gameObject.SetActive(false);
            this.jugadores[3].gameObject.SetActive(false);

        }else if(cantidadJugadores == 2){
            this.turnos[0] = 1;
            this.turnos[1] = 2;
            this.jugadores[2].gameObject.SetActive(false);
            this.jugadores[3].gameObject.SetActive(false);
        }else if(cantidadJugadores == 3){
            this.turnos[0] = 1;
            this.turnos[1] = 2;
            this.turnos[2] = 3;
            this.jugadores[3].gameObject.SetActive(false);
        }else if(cantidadJugadores == 4){
            this.turnos[0] = 1;
            this.turnos[1] = 2;
            this.turnos[2] = 3;
            this.turnos[3] = 4;
        }

        //se busca cuantos jugadores hay
        for(int i = 0; i < 4; i++){
            if(this.turnos[i] > 0){
                this.siJugador++;
            }
        }
    }

    /*
    Metodo que hara que los jugadores lanzen el dado por turnos
    */
    public void JugarTurnos(){
        int nuevaPosicion = 0;
        //busca el turno de cada jugador
        for(int i = 0; i < siJugador; i++){

            if(this.validadorTurnos[i] == true){

                //se incrementan por unidad los turnos jugados del jugador
                this.jugadores[i].IncrementarTurnosJugados();
                int numeroDado = this.jugadores[i].GetPosicionActual() + dado.lanzarDado();
                nuevaPosicion = getPosicion(numeroDado);

                //se setea la nueva posicion del jugador
                this.jugadores[i].transform.position = this.posiciones[nuevaPosicion].position;
                this.jugadores[i].SetPosicionActual(nuevaPosicion);

                //si el jugador esta en la ultima casilla opera este condicional
                if(nuevaPosicion == 20){
                    casillaFinal.DesplegarfinalJuego(this.jugadores[i].GetNombre(), this.jugadores[i].GetTurnosJugados()); //Utilizamos el metodo de la clase para terminar el juego
                }
                break;
            }
        }

        //mientras que no este en casillas amarillas, se opera con normalidad
        if(nuevaPosicion != this.casillasAmarillas[0] || nuevaPosicion != this.casillasAmarillas[1]){

            //cambia el turno al siguiente jugador
            for (int i = 0; i < siJugador - 1; i++){

                //si el ultimo jugador fue el que jugó, cambia el turno al primer jugador
                if(this.validadorTurnos[siJugador-1] == true){
                    this.validadorTurnos[0] = true;
                    this.validadorTurnos[siJugador-1] = false;
                    break;
                }

                //si es no es el ultimo jugador, opera este condicional
                if (this.validadorTurnos[i] == true){

                    // Pasar el turno al siguiente jugador
                    this.validadorTurnos[i] = false;
                    this.validadorTurnos[i + 1] = true;
                    break;
                }
            }

            //si estamos en una casilla amarilla
        }else{ 
            Thread.Sleep(850); // Esperar 0.85 segundos (850 milisegundos)
            JugarTurnos();
        }
    }

    /*
    Funcion que retorna la posicion en la i-esima casilla del arreglo de las posiciones
    */
    public int getPosicion(int i){

        //bucle que verifica si el personaje esta en una casilla azul
        for(int j = 0 ; j < this.casillasNormales.Length; j++){
            if(this.casillasNormales[j] == i){ 
                break;
            }
        }

        //conficional para saber si el personaje esta en una casilla verde
        if(this.casillasVerdes[0] == i){
            return 10;

        }else if(this.casillasVerdes[1] == i){
            return 19;
        }

        //conficional para saber si el personaje esta en una casilla negra
        if(this.casillasNegras[0] == i){
            return 1;
        }else if(this.casillasNegras[1] == i){
            return 8;
        }

        //conficional para saber si el personaje esta en la ultima casilla
        if(i >= 21){
            i = 20;
        }

        return i; //retorna la i-esima posicion del contenedor posiciones
    } 
}
