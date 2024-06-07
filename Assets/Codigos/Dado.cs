using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dado : MonoBehaviour
{
    [SerializeField] public int numero = 0;

    void Start(){
        lanzarDado();
    }
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
