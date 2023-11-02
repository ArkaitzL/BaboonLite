using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;
using UnityEngine.SceneManagement;

public class Pruebas : MonoBehaviour
{
    [SerializeField] private DictionaryBG<Lenguaje> textos = new();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Save.Data.language += 10;
            Debug.Log(Save.Data.language);
        }
    }
}
