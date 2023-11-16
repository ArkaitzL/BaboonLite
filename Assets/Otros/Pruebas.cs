using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;
using UnityEngine.SceneManagement;

public class Pruebas : MonoBehaviour
{
    [SerializeField] DictionaryBG<bool> prueba;
    [SerializeField] Transform padreTra;
    [SerializeField] GameObject padreGa;

    private void Start()
    {
        padreTra.GetChilds(0, 0, 0).name.Log();
        padreGa.GetChilds(0, 0, 0).name.Log();
    }
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

    public void AnuncioRecompensado() {
        Anuncios.verRewarded(() => {
            Debug.Log("Toma tu piruleta");
        });
    }
}
