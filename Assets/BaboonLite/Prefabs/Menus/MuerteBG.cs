using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;
using TMPro;
using UnityEngine.SceneManagement;

public class MuerteBG : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI muerte_txt;
    [SerializeField] private string menu_scene = "Menu";
    private int total = 0;

    private void Awake()
    {
        Instanciar<MuerteBG>.Añadir(this);
    }
    
    public void Activar(params Puntuador[] puntuacion) 
    {
        string muerte_string = "";
       
        foreach (var elemento in puntuacion)
        {
            int obtenido = (int)(elemento.puntos * elemento.multiplicador);
            muerte_string += $"{elemento.nombre} x{elemento.puntos}\t\t{obtenido}$\n";
            total += obtenido;
        }

        transform.GetChild(0).gameObject.SetActive(true);
        muerte_txt.text = muerte_string +
                        $"\n___________________" +
                        $"\nTotal\t\t\t{total}$"; ;
    } 

    public void Terminar(int multiplicador) 
    {
        if (multiplicador >= 2)
        {
            Anuncios.verRewardedRecompensa(() =>
            {
                Pasar(multiplicador);
            });
        }
        else {
            Pasar(multiplicador);
        }
    }

    private void Pasar(int multiplicador)
    {
        Save.Data.dinero += total * multiplicador;
        SceneManager.LoadScene(menu_scene);
    }
}

public class Puntuador
{
    public Puntuador(string nombre, float puntos, float multiplicador)
    {
        this.nombre = nombre;
        this.puntos = puntos;
        this.multiplicador = multiplicador;
    }

    public string nombre;
    public float puntos;
    public float multiplicador;
}
