using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaboOnLite 
{
    [DefaultExecutionOrder(0)]
    [AddComponentMenu("BaboOnLite/_Idiomas/Idiomas")]
    [DisallowMultipleComponent]
    [HelpURL("https://www.notion.so/BaboOnLite-c6252ac92bbc4f8ea231b1276008c13a?pvs=4")]
    public class Idiomas : MonoBehaviour
    {
        //VARIABLES 

        //PUBLICAS
        [SerializeField] public List<Lenguaje> _lenguajes = new();
        //ESTATICAS
        public static event Action cambiarTextos;
        private static List<Lenguaje> lenguajes = new();

        //PRIVADAS
        [HideInInspector] public List<List<string>> listas = new();

        private void OnValidate()
        {
            lenguajes = _lenguajes;
            Actualizar();
        }

        //PUBLICAS

        //Funciones para cambiar el idioma actual
        #region idioma actual
        public static void Alternar()
        {
            Save.Data.lenguaje = (Save.Data.lenguaje < (lenguajes.Count - 1))
               ? ++Save.Data.lenguaje
               : 0;

            cambiarTextos?.Invoke();
        }
        public static void Cambiar(int i)
        {
            //Valida la longitud de miLang
            int longitud = lenguajes.Count - 1;

            if (i >= longitud || i < 0)
            {
                //No hay elementos en esa posicion del array
                Bug.LogLite($"[BL][Idiomas: 2]No existe un elemento asignado, a la posicion {i} en tus lenguajes");
                return;
            }

            Save.Data.lenguaje = i;
            cambiarTextos?.Invoke();
        }
        #endregion

        //Coger los textos
        #region get
        public static string Get(int i)
        {
            if (lenguajes.Inside(i)) return lenguajes[Save.Data.lenguaje].dictionary[i];
            return null;
        }
        public static string Get(string clave)
        {
            foreach (Lenguaje lenguaje in lenguajes)
            {
                if (lenguaje != null && lenguaje.dictionary != null)
                {
                    int index = Array.FindIndex(lenguaje.dictionary, elemento => elemento.Equals(clave, StringComparison.OrdinalIgnoreCase));
                    if (index != -1)
                    {
                        return lenguajes[Save.Data.lenguaje].dictionary[index];
                    }
                }
            }

            return null;
        }
        #endregion

        //PRIVADAS

        //Actualiza la lista con todas las palabras en cada idioma
        #region actualizar lista
        public void Actualizar()
        {

            if (_lenguajes.Count == 0) listas.Clear();

            //Cuando modificas la lista comprueba que todo esta bien
            if (_lenguajes.Count == 0) return;

            listas.Clear();
            int? comparacion = null;
            foreach (Lenguaje lenguaje in _lenguajes)
            {
                if (lenguaje == null) return;

                if (comparacion == null) comparacion = lenguaje.dictionary.Length;
                if (comparacion != lenguaje.dictionary.Length)
                {
                    Bug.LogLite("[BL][Idiomas: 1] Los diccionarios tienen longitudes diferentes");
                    return;
                }
            }

            //Guarda los diccionarios ordenados
            for (int i = 0; i < comparacion; i++)
            {
                List<string> lista = new();
                lista.Add($"Palabra ->  {i}:");

                for (int j = 0; j < _lenguajes.Count; j++)
                {
                    lista.Add($"\t •  {_lenguajes[j].name}({j}): \t" + _lenguajes[j].dictionary[i]);
                }

                listas.Add(lista);
            }

            //Pasa al estatico
            lenguajes = _lenguajes;
        }
        #endregion
    }
}
