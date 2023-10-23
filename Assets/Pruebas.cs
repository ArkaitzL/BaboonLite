using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;
using UnityEngine.SceneManagement;

public class Pruebas : MonoBehaviour
{
    private int cont;
    public DictionaryBG<bool> bg = new();

    void Awake()
    {
        //Instanciar<Pruebas>.Añadir(this);
        Instanciar<Pruebas>.Singletons(this, gameObject);
    }

    public void Probar() {
        Debug.Log("Funciona->" + ++cont);
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
