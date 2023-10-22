using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Prefabs
{
    //Ruta de los prefabs

    //OBJETO 1
    [MenuItem("GameObject/UI/BaboOnLite/Consola (PC)")]
    private static void InstantiatePC(MenuCommand menuCommand)
    {
        Instantiate("Consola/Consola (PC).prefab");
    }
    //OBJETO 2
    [MenuItem("GameObject/UI/BaboOnLite/Consola (Android)")]
    private static void InstantiateAndroid(MenuCommand menuCommand)
    {
        Instantiate("Consola/Consola (Android).prefab");
    }
    //OBJETO 3
    [MenuItem("GameObject/UI/BaboOnLite/Fps (Android)")]
    private static void InstantiateFps(MenuCommand menuCommand)
    {
        Instantiate("Fps/Fps.prefab");
    }

    private static void Instantiate(string name) {

        //Busca la ruta
        string path = AssetDatabase.GUIDToAssetPath(
            AssetDatabase.FindAssets("BaboOnLite")[0]
        ) + "/Prefabs/";

        //Busca el canvas y si no existe lo crea
        Canvas canvas = Object.FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            GameObject canvasGO = new GameObject("Canvas");
            canvas = canvasGO.AddComponent<Canvas>();
            canvasGO.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasGO.AddComponent<GraphicRaycaster>();

            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        }

        //EventSystem
        EventSystem eventSystem = Object.FindObjectOfType<EventSystem>();
        if (eventSystem == null)
        {
            GameObject eventSystemGO = new GameObject("EventSystem");
            eventSystem = eventSystemGO.AddComponent<EventSystem>();
            eventSystemGO.AddComponent<StandaloneInputModule>();

            //Lo añade dentro del Canvas
            eventSystemGO.transform.parent = canvas.transform;
        }

        //Instancia el prefab
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path + name);
        GameObject instance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
        instance.name = prefab.name;

        //Lo añade dentro del Canvas
        instance.transform.SetParent(canvas.transform, false);

        //Otros
        Undo.RegisterCreatedObjectUndo(instance, "Instantiate Custom Prefab");
        Selection.activeGameObject = instance;
    }
}
