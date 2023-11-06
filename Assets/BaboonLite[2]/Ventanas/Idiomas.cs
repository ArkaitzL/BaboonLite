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
        //VARIABLES 

        //Publicas
        [SerializeField] private List<Lenguaje> lenguajes = new();
        [SerializeField] private DictionaryBG<TextMeshProUGUI> textos = new();
        [SerializeField] private int actual;

        //Privadas
        private SerializedObject serializedObject;
        private Vector2 scroll1 = Vector2.zero;
        private Vector2 scroll2 = Vector2.zero;
        private List<string> listas = new();
        private bool play;

        [MenuItem("Window/BaboOnLite/Idiomas")]
        public static void IniciarVentana()
        {
            Idiomas ventana = GetWindow<Idiomas>("Idiomas");
            ventana.minSize = new Vector2(200, 200);

            //Dependencia
            Save dependecia = GetWindow<Save>("Save");
            dependecia.minSize = new Vector2(200, 200);
        }

        private void OnGUI()
        {

            //Crea la GUI basica de la ventana

            //Inicio del GUI
            GUILayout.Label("Idiomas: Administra los idiomas de tu juego facilmente", EditorStyles.boldLabel);
            EditorGUILayout.Space(10);
            scroll1 = EditorGUILayout.BeginScrollView(scroll1);

            //Idioma actual
            #region idioma actual

            EditorGUILayout.PropertyField(serializedObject.FindProperty("actual"));
            EditorGUILayout.Space(10);

            #endregion

            Separador();

            //Los diccionarios de los lenguajes
            #region diccionarios

            //Boton de actualizar
            if (GUILayout.Button("Actualizar diccionarios"))
            {
                Actualizar();
            }

            //Imprime la lista de diccionarios
            EditorGUILayout.PropertyField(serializedObject.FindProperty("lenguajes"));

            if (serializedObject.ApplyModifiedProperties()) {
                Actualizar();
            }

            //Imprimir los datos en labels
            GUILayout.Label("Mis diccionarios:", EditorStyles.boldLabel);
            EditorGUILayout.Space(5);

            scroll2 = EditorGUILayout.BeginScrollView(scroll2);

            foreach (var texto in listas)
            {
                EditorGUILayout.LabelField(texto);
            }

            EditorGUILayout.EndScrollView();

            #endregion

            Separador();

            //Los textos estaticos
            #region textMesh
            //Imprime la lista
            EditorGUILayout.PropertyField(serializedObject.FindProperty("textos"));
            serializedObject.ApplyModifiedProperties();

            EditorGUILayout.EndScrollView();
            EditorGUILayout.Space(10);
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

        //PUBLICAS
        public void Alternar() { 
        }
        public void Cambiar()
        {
        }
        public void Coger()
        {
        }

        //PRIVADAS

        private void Separador(int altura = 1)
        {
            Rect rect = EditorGUILayout.GetControlRect(false, altura);
            rect.height = altura;
            EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
        }

        private void Actualizar() {
            //Cuando modificas la listya comprueba que todo esta bien
            if (lenguajes.Count == 0) return;

            listas.Clear();
            int? comparacion = null;
            foreach (Lenguaje lenguaje in lenguajes)
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
                listas.Add($"Palabra ->  {i}:");

                for (int j = 0; j < lenguajes.Count; j++)
                {
                    listas.Add($"\t •  {lenguajes[j].name}: " + lenguajes[j].dictionary[i]);
                }
                //listas.Add("\n");
            }
        }
    }
}
