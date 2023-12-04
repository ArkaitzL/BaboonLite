using UnityEditor;

namespace BaboOnLite {
    public class _Prefabs
    {
        //----------------------------------------------------------------//
        // En MenuItem añade: "GameObject/UI/BaboOnLite/" + "TuCarpeta"   //
        // En ElementoCanvas añade: "TuCarpeta/" + "TuPrefab.prefab"      //
        // Añlade true en caso de que sea un elemento del canvas          //
        //----------------------------------------------------------------//

        //CANVAS/

        //CANVAS
        [MenuItem("GameObject/UI/BaboOnLite/Canvas")]
        private static void InstanciarCanva(MenuCommand selecciondo)
        {
            Prefabs.Canvas();
        }
        //FPS
        [MenuItem("GameObject/UI/BaboOnLite/Fps (Android)")]
        private static void InstanciarFps(MenuCommand selecciondo)
        {
            Prefabs.Elemento("Fps/Fps.prefab", selecciondo, true);
        }

        //CANVAS/MENUS/

        //DEV
        [MenuItem("GameObject/UI/BaboOnLite/Menus/Dev")]
        private static void InstanciarDev(MenuCommand selecciondo)
        {
            Prefabs.Elemento("Menus/Dev.prefab", selecciondo, true);
        }
        //INICIO
        [MenuItem("GameObject/UI/BaboOnLite/Menus/Inicio")]
        private static void InstanciarInicio(MenuCommand selecciondo)
        {
            Prefabs.Elemento("Menus/Inicio.prefab", selecciondo, true);
        }

        //BABOONLITE/

        //TODOS
        [MenuItem("GameObject/BaboOnLite/BaboonLite")]
        private static void InstanciarBaboonLite(MenuCommand selecciondo)
        {
            Prefabs.Elemento("Componentes/_baboonlite.prefab", selecciondo);

        }

        //ADS
        [MenuItem("GameObject/BaboOnLite/Ads")]
        private static void InstanciarAds(MenuCommand selecciondo)
        {
            Prefabs.Elemento("Componentes/_ads.prefab", selecciondo);
        }
        //CONTROLADOR
        [MenuItem("GameObject/BaboOnLite/Controlador")]
        private static void InstanciarControlador(MenuCommand selecciondo)
        {
            Prefabs.Elemento("Componentes/_controlador.prefab", selecciondo);
        }
        //IDIOMAS
        [MenuItem("GameObject/BaboOnLite/Idiomas")]
        private static void InstanciarIdiomas(MenuCommand selecciondo)
        {
            Prefabs.Elemento("Componentes/_idiomas.prefab", selecciondo);
        }
        //SAVE
        [MenuItem("GameObject/BaboOnLite/Save")]
        private static void InstanciarSave(MenuCommand selecciondo)
        {
            Prefabs.Elemento("Componentes/_save.prefab", selecciondo);
        }
        //SONIDOS
        [MenuItem("GameObject/BaboOnLite/Sonidos")]
        private static void InstanciarSonidos(MenuCommand selecciondo)
        {
            Prefabs.Elemento("Componentes/_sonidos.prefab", selecciondo);
        }
        //SONIDOS
        [MenuItem("GameObject/BaboOnLite/Textos")]
        private static void InstanciarTextos(MenuCommand selecciondo)
        {
            Prefabs.Elemento("Componentes/_textos.prefab", selecciondo);
        }

    }
}
