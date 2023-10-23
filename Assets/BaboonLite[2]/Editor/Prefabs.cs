using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace BaboOnLite {
    public class Prefabs
    {
        //Ruta de la carpeta prefab dentro de BaboonLite
        private static string ruta_carpeta = "/Prefabs/";


        //CANVA 1
        [MenuItem("GameObject/UI/BaboOnLite/Canvas")]
        private static void InstanciarCanva(MenuCommand menuCommand)
        {
            ElementoCanvas(null);
        }
        //CANVA 2
        [MenuItem("GameObject/UI/BaboOnLite/Fps (Android)")]
        private static void InstanciarFps(MenuCommand menuCommand)
        {
            ElementoCanvas("Fps/Fps.prefab");
        }

        private static GameObject Elemento(string nombre) 
        {
            //Instancia el elemento del prefab
            #region elemento
            GameObject elemento = null;
            if (nombre != "" && nombre != null)
            {
                //Busca la ruta
                string ruta = AssetDatabase.GUIDToAssetPath(
                    AssetDatabase.FindAssets("Editor")[0]
                ) + ruta_carpeta;

                //Lo crea
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(ruta + nombre);
                if (prefab == null)
                {
                    Bug.LogLite("[BL][Prefabs: 1] No existe el prefab seleccionado");
                }

                elemento = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
                elemento.name = prefab.name;

                //Otros
                Undo.RegisterCreatedObjectUndo(elemento, "Instantiate Custom Prefab");
                Selection.activeGameObject = elemento;
            }
            #endregion

            return elemento;
        }

        private static void ElementoCanvas(string nombre)
        {
            //VARIABLES
            Dictionary<string, string> nombres = new Dictionary<string, string>
            {
                { "canvas", "canvas-" },
                { "eventsystem", "es-" },
            };

            //Busca el canvas y si no existe lo crea
            #region canvas
            Canvas canvas = Object.FindObjectOfType<Canvas>();
            if (canvas == null)
            {
                GameObject canvasGO = new GameObject(nombres["canvas"]);
                canvas = canvasGO.AddComponent<Canvas>();
                canvasGO.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                canvasGO.AddComponent<GraphicRaycaster>();

                canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            }
            #endregion

            //Busca el EventSystem y si no existe lo crea
            #region eventsystem
            EventSystem eventSystem = Object.FindObjectOfType<EventSystem>();
            if (eventSystem == null)
            {
                GameObject eventSystemGO = new GameObject(nombres["eventsystem"]);
                eventSystemGO.AddComponent<StandaloneInputModule>();
                eventSystem = eventSystemGO.AddComponent<EventSystem>();

                //Lo añade dentro del Canvas
                eventSystemGO.transform.parent = canvas.transform;
            }
            #endregion

            //Instancia el elemento del prefab
            GameObject elemento = Elemento(nombre);
            if (elemento != null)
            {
                //Lo añade dentro del Canvas
                elemento.transform.SetParent(canvas.transform, false);
            }
        }
    }

}