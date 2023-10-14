using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;
using UnityEngine.SceneManagement;

public class Instanciar<T> : MonoBehaviour {

    private static Dictionary<string, T> instancias = new Dictionary<string, T>();

    public static void Añadir(string nombre, T instancia, GameObject objeto)
    {

        if (instancias.Count == 0)
        {
            SceneManager.sceneUnloaded += (Scene escena) => {
                instancias.Clear();
            };
        }

        if (instancias.Some((i) => EqualityComparer<T>.Default.Equals(instancia, i.Value)))
        {
            Debug.LogWarning("Ya tienes un objeto igual guardado");
        }


        if (instancias.Every((element) => nombre != element.Key))
        {
            //if (global)
            //{
            //    DontDestroyOnLoad(objeto);
            //}
            instancias.Add(nombre, instancia);
        }
        else
        {
            Debug.LogWarning("Ya tienes un objeto con ese nombre");
            //Destroy(objeto);
        }
    }

    public static T Coger(string nombre)
    {
        return instancias[nombre];
    }
}
