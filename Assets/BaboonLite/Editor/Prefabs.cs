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

        public static GameObject Elemento(string nombre, MenuCommand seleccionado, bool tipo_canvas = false) 
        {
            //Instancia el elemento del prefab
            #region elemento
            GameObject elemento = null;
            if (nombre != "" && nombre != null)
            {
                //Busca la ruta
                string ruta = AssetDatabase.GUIDToAssetPath(
                    AssetDatabase.FindAssets("BaboonLite")[0]
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

            //Añade un padre al elemento creado
            #region padre
            if (elemento != null)
            {
                GameObject padre = seleccionado.context as GameObject;

                if (tipo_canvas && padre == null)
                {
                    Canvas canvas = Object.FindObjectOfType<Canvas>();
                    padre = (canvas == null)
                        ? Canvas().gameObject
                        : canvas.gameObject;
                }

                if (padre != null)
                {
                    //Lo añade dentro del gameobject seleccionado
                    elemento.transform.SetParent(padre.transform, false);
                }
            }
            #endregion

            return elemento;
        }

        public static Canvas Canvas()
        {
            //VARIABLES
            Dictionary<string, string> nombres = new Dictionary<string, string>
            {
                { "canvas", "Canvas-" },
                { "eventsystem", "Es-" },
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
                canvasGO.AddComponent<MenuUI>();

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

            return canvas;
        }
    }

}