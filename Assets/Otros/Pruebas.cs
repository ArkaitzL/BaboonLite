using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;
using UnityEngine.SceneManagement;

public class Pruebas : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Idiomas.Alternar();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Idiomas.Cambiar(0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(Idiomas.Get(0));
        }
    }
}
