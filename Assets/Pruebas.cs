using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;
using UnityEngine.SceneManagement;

public class Pruebas : MonoBehaviour
{
    void Awake()
    {
        Instanciar<Pruebas>.Añadir(this);
    }

    public void Probar() {
        Debug.Log("Funciona!!");
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
