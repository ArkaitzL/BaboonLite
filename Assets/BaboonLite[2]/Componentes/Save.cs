using UnityEngine;

namespace BaboOnLite
{
    [DefaultExecutionOrder(0)]
    [AddComponentMenu("BaboOnLite/Save")]
    [DisallowMultipleComponent]
    [HelpURL("https://docs.google.com/document/d/1zPv7QP-ZyisadG5zREiMmzV7UWsYTUPZIPT0f_YlhSE/edit?usp=sharing")]

    public class Save : MonoBehaviour
    {
        //VARIABELS
        [SerializeField] bool mensajesConfirmacion = false;
        [SerializeField] SaveScript data = new SaveScript();

        // Recoge los datos y los carga desde PlayerPrefs
        private void Awake()
        {
            // Convierte el script en Singleton
            Instanciar<Save>.Singletons(this, gameObject);
        }

        //Carga los datos si los hay
        #region cargar_datos
        public void Cargar() {
            string jsonString = PlayerPrefs.GetString("data");
            if (!string.IsNullOrEmpty(jsonString))
            {
                data = JsonUtility.FromJson<SaveScript>(jsonString);
                if (mensajesConfirmacion)
                {
                    Debug.Log("[BL]Datos cargados correctamente");
                }
            }
            else
            {
                // No se ha encontrado ningún dato en PlayerPrefs
                Bug.LogLite("[BL][Save: 1] No se han encontrado datos guardados");
            }
        }
        #endregion

        // Al salir de la aplicación, guarda los datos en PlayerPrefs
        #region guardar_datos
        private void OnApplicationPause(bool pause)
        {
            if (pause) Guardar();
        }
        private void OnApplicationQuit()
        {
            Guardar();
        }
        public void Guardar()
        {
            string jsonString = JsonUtility.ToJson(data);
            PlayerPrefs.SetString("data", jsonString);

            if (mensajesConfirmacion)
            {
                Debug.Log("[BL]Datos guardados en PlayerPrefs");
            }
        }
        #endregion

        // Elimina los datos de PlayerPrefs
        #region eliminar_datos
        public void Eliminar()
        {
            PlayerPrefs.DeleteKey("data");
            if (mensajesConfirmacion) Debug.Log("[BL]Datos eliminados correctamente de PlayerPrefs");
        }
        #endregion
    }
}