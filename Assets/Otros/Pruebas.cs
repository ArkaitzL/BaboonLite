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
            Sonidos.GetMusica("musica2", false, true);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Sonidos.GetSonido("sonido1");
        }
    }
}
