using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Escenas : EditorWindow
{
    private string[] escenas;
    private int indice;

    [MenuItem("Window/BaboonLite/Escenas")]
    public static void IniciarVentana()
    {
        Escenas ventana = GetWindow<Escenas>("Escenas");
        ventana.Cargar();
    }

    private void OnEnable()
    {
        Cargar();
    }

    private void Update()
    {
        if (escenas.Length != EditorBuildSettings.scenes.Length) Cargar();
    }

    private void Cargar()
    {
        escenas = new string[EditorBuildSettings.scenes.Length];
        for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
        {
            escenas[i] = System.IO.Path.GetFileNameWithoutExtension(EditorBuildSettings.scenes[i].path);
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("Escenas: Cambia entre escenas facilmente", EditorStyles.boldLabel);

        int anterior = indice;
        indice = EditorGUILayout.Popup("Escena: ", indice, escenas);

        if (anterior != indice)
        {
            EditorSceneManager.OpenScene(EditorBuildSettings.scenes[indice].path, OpenSceneMode.Single);
        }
    }

    private void OnDestroy()
    {
        EditorBuildSettings.sceneListChanged -= Cargar;
    }
}
