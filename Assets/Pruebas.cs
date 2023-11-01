using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;
using UnityEngine.SceneManagement;

public class Pruebas : MonoBehaviour
{
    void Start()
    {

        Debug.Log(Save.ventana.data.language);
        Save.ventana.data.language += 1;
    }
}
