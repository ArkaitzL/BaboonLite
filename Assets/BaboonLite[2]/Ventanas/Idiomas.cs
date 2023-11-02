using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace BaboOnLite
{
    public class Idiomas : EditorWindow
    {
        //Variables
        [SerializeField] private List<Lenguaje> lenguajes = new();
        [SerializeField] private DictionaryBG<Lenguaje> textos = new();

        private bool play;
        
        [MenuItem("Window/BaboOnLite/Idiomas")]
        public static void IniciarVentana()
        {
            Idiomas ventana = GetWindow<Idiomas>("Idiomas");
            ventana.minSize = new Vector2(200, 200);
        }

        private void OnGUI()
        {
            //Crea la GUI basica de la ventana

            GUILayout.Label("Idiomas: Administra los idiomas de tu juego facilmente", EditorStyles.boldLabel);
            EditorGUILayout.Space(10);

            #region listas

            SerializedObject o = new SerializedObject(this);
            CargarList(o, "lenguajes");

            //Imprimir todos los labels con un for

            Separador();
            CargarList(o, "textos");
            #endregion
        }
        private void OnEnable()
        {
            if (play)
            {
              
            }


            //Detecta cuando entras en el playmode
            #region play
            EditorApplication.playModeStateChanged += (PlayModeStateChange state) => {
                if (state == PlayModeStateChange.ExitingEditMode) play = true;
            };
            #endregion
        }

        void Separador(int altura = 1)
        {
            Rect rect = EditorGUILayout.GetControlRect(false, altura);
            rect.height = altura;
            EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
        }

        void CargarList(SerializedObject objeto, string nombre)
        {
            SerializedProperty propiedad = objeto.FindProperty(nombre);
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(propiedad, true);
            if (EditorGUI.EndChangeCheck())
            {
                objeto.ApplyModifiedProperties();
            }
        }
    }
}
