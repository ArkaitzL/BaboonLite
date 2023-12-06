using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;
using UnityEngine.SceneManagement;

public class Pruebas : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instanciar<MuerteBG>.Coger().Activar(new("Puntos", 100f, 0.1f), new("Dinero", 10f, 3f));
        }
    }
}
