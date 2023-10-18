using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;

public class Ayudante : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Probando:");
        Instanciar<Pruebas>.Coger().Probar();
    }
}
