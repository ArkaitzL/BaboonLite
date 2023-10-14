using UnityEngine;

namespace BaboOnLite
{
    [DefaultExecutionOrder(0)]
    [AddComponentMenu("BaboOnLite/Save")]
    [DisallowMultipleComponent]
    //[HelpURL("")]

    public class Save : MonoBehaviour
    {
        [SerializeField] bool mensajesConfirmacion = false;
        string color = "white";
        [SerializeField] SaveScript data = new SaveScript();
        public static Save get;

        public static SaveScript Data { get => get.data; }
        // Convierte el script en Singleton
        void Instance()
        {
            if (get != null)
            {
                Destroy(gameObject);
                return;
            }

            get = this;
            DontDestroyOnLoad(gameObject);
        }

        // Recoge los datos y los carga desde PlayerPrefs
        private void Awake()
        {
            Instance();
            string jsonString = PlayerPrefs.GetString("data");
            if (!string.IsNullOrEmpty(jsonString))
            {
                data = JsonUtility.FromJson<SaveScript>(jsonString);
                if (mensajesConfirmacion)
                {
                    Debug.LogFormat("<color={0}>Datos cargados correctamente.</color>", color);
                }
            }
            else
            {
                // No se ha encontrado ningún dato en PlayerPrefs
                Debug.LogWarning("baboOn: 2.3.-No se han encontrado datos guardados.");
            }
        }

        // Al salir de la aplicación, guarda los datos en PlayerPrefs
        private void OnApplicationPause(bool pause)
        {
            if(pause) SaveData();
        }
        private void OnApplicationQuit()
        {
            SaveData();
        }
        public void SaveData() {
            string jsonString = JsonUtility.ToJson(data);
            PlayerPrefs.SetString("data", jsonString);

            if (mensajesConfirmacion)
            {
                Debug.LogFormat("<color={0}>Datos guardados en PlayerPrefs.</color>", color);
            }
        }

        // Elimina los datos de PlayerPrefs
        public void Remove()
        {
            PlayerPrefs.DeleteKey("data");

            if (mensajesConfirmacion)
            {
                Debug.LogFormat("<color={0}>Datos eliminados correctamente de PlayerPrefs.</color>", color);
            }
        }
    }
}