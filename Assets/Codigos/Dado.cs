using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dado : MonoBehaviour
{
    //Variable que alojara el numero que de el dado
    int numero = 0;

    /*
    Funcion que retorna un numero aleatorio entre el 1 y el 6 
    */
    public int lanzarDado(){
        // Crea una instancia de la clase Random
         System.Random random = new System.Random();

        // Genera un número aleatorio entre 1 y 6 (inclusive)
        int numeroAleatorio = random.Next(1, 7);

        // Devuelve el número aleatorio generado
        this.numero = numeroAleatorio;
        return numeroAleatorio;
    }
}
