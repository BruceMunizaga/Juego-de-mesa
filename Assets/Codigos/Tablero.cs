using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    //Instancia de la clase dado
    Dado dado = new Dado();

    //Contenedor de las posiciones en el tablero
    Vector3[] posiciones = new Vector3[20];

    //Contenedor de las casillas normales en el tablero
    int[] casillasNormales = {1,2,4,5,7,8,10,12,14,15,17,18,19};

    void Start(){
        //TODO: llenar el vector posiciones con todas las posiciones de las casillas
    }

    public Vector3 getPosicion(int i){


        //condicional para saber si esta pisando una casilla verde
        if(i == 3){
            i = 10;
            return this.posiciones[i];
        }else if(i ==9){
            i = 19;
            return this.posiciones[i];
        }

        //condicional para saber si esta pisando una casilla amarilla
        if(i == 6){
            i =+ dado.lanzarDado();
            getPosicion(i);
        }else if(i == 16){
            i =+ dado.lanzarDado();
            getPosicion(i);      
        }

        //condicional para saber si esta pisando una casilla negra
        if(i == 13){
            i = 1;
            return this.posiciones[i];
        }else if(i == 20){
            i = 8;
            return this.posiciones[i];
        }


        //Condicional para saber si esta pisando una casilla azul
        for(int j = 0; j < 13; j++){
            if(this.casillasNormales[j] == i){
                break;
            }
        }

        if(i >= 21){
            return this.posiciones[20];
        }

        return this.posiciones[i]; //retorna la i-esima posicion del contenedor posiciones
    } 
}
