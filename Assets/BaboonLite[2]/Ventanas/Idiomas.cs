using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using TMPro;

namespace BaboOnLite
{
    public class Idiomas : EditorWindow
    {
        //Variables
        [SerializeField] private string basura;
        [SerializeField] private List<string> lenguajes = new();
        [SerializeField] private DictionaryBG<TextMeshProUGUI> textos = new();

        private SerializedObject serializedObject;

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

            EditorGUILayout.PropertyField(serializedObject.FindProperty("basura"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("lenguajes"));

            //Imprimir todos los labels con un for

            Separador();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("textos"));

            serializedObject.ApplyModifiedProperties();
            #endregion
        }
        private void OnEnable()
        {
            serializedObject = new SerializedObject(this);

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

        private void Separador(int altura = 1)
        {
            Rect rect = EditorGUILayout.GetControlRect(false, altura);
            rect.height = altura;
            EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
        }

    }
}
