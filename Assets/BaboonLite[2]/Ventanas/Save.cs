using System;
using UnityEditor;
using UnityEngine;

namespace BaboOnLite {

    public class Save : EditorWindow
    {
        [SerializeField] private bool mensajes;
        private bool play;

        [SerializeField] public SaveScript data = new();
        public static Save ventana;
        //[SerializeField] public SaveScript data
        //{
        //    get { return Data.data; } 
        //}

        [MenuItem("Window/BaboOnLite/Save")]
        public static void IniciarVentana()
        {
            ventana = GetWindow<Save>("Save");
            ventana.minSize = new Vector2(200, 200);
        }

        private void OnGUI()
        {
            //Crea la GUI basica de la ventana
            #region gui

            GUILayout.Label("Save: Guarda tus datos de manera facil y comoda", EditorStyles.boldLabel);

            EditorGUILayout.Space(10);

            mensajes = EditorGUILayout.Toggle("Mostrar mensajes: ", mensajes);

            EditorGUILayout.Space(10);

            if (GUILayout.Button("Eliminar data"))
            {
                PlayerPrefs.DeleteKey("data");
                if(mensajes) Debug.Log("[BL]Datos eliminados correctamente de PlayerPrefs");
            }

            #endregion

            //Imprime el contenido de data
            #region data

            SerializedObject objeto = new SerializedObject(this);
            SerializedProperty contenido = objeto.FindProperty("data");
            EditorGUILayout.PropertyField(contenido, true);

            #endregion
        }
        private void OnEnable()
        {
            if (play)
            {
                ventana = this;
                //Cargar los datos al iniciar el play mode
                string jsonString = PlayerPrefs.GetString("data");
                if (!string.IsNullOrEmpty(jsonString))
                {
                    data = JsonUtility.FromJson<SaveScript>(jsonString);
                    if (mensajes) Debug.Log("[BL]Datos cargados correctamente");
                }
                else
                {
                    // No se ha encontrado ningún dato en PlayerPrefs
                    Bug.LogLite("[BL][Save: 1] No se han encontrado datos guardados");
                }
            }

            EditorApplication.playModeStateChanged += (PlayModeStateChange state) => {
                //Guarda los datos al salir del play mode
                #region guardar
                if (state == PlayModeStateChange.ExitingPlayMode)
                {
                    string jsonString = JsonUtility.ToJson(data);
                    PlayerPrefs.SetString("data", jsonString);

                    if (mensajes) Debug.Log("[BL]Datos guardados en PlayerPrefs");
                    play = false;

                }
                if (state == PlayModeStateChange.ExitingEditMode)
                {
                    play = true;
                }
                #endregion
            };
        }
    }
}
