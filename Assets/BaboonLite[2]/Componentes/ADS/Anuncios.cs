using UnityEngine.Advertisements;
using UnityEngine;

namespace BaboOnLite {

    [DefaultExecutionOrder(1)]
    [AddComponentMenu("BaboOnLite/_ADS/Anuncios")]
    [DisallowMultipleComponent]
    [HelpURL("https://docs.google.com/document/d/1zPv7QP-ZyisadG5zREiMmzV7UWsYTUPZIPT0f_YlhSE/edit?usp=sharing")]
    public class Anuncios : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        [SerializeField] private string androidAdID = "Interstitial_Android";
        [SerializeField] private string iosAdID = "Interstitial_iOS";
        private string adId;

        //Asigna el id correspondiente
        private void Awake()
        {
            //Asigna el id correspondiente
            adId = (Application.platform == RuntimePlatform.IPhonePlayer)
                ? iosAdID
                : androidAdID;
        }

        //Enseña el anuncio que quieres ver
        public void VerAd() {
            Advertisement.Load(adId, this);
        }

        //FUNCIONES DE UNITYADS

        //Avisa cuando esta todo cargado
        #region cargado
        public void OnUnityAdsAdLoaded(string adUnitId)
        {
            //Comprueba que este todo cargado
            if (!Advertisement.isInitialized)
            {
                Bug.LogLite("[BL][Anuncio: 1] No estan inicializados los anuncios");
                return;
            }

            if (adUnitId.Equals(adId))
            {
                Advertisement.Show(adId, this);
            }
        }
        #endregion

        //Errores al cargar o mostrar los anuncios
        #region errores
        public void OnUnityAdsFailedToLoad(string id, UnityAdsLoadError error, string mensaje)
        {
            Bug.LogLite($"[BL][Anuncio: 2] No se ha podido cargar el anuncio: \n {id} \n {error} \n {mensaje}");
        }
        public void OnUnityAdsShowFailure(string id, UnityAdsShowError error, string mensaje)
        {
            Bug.LogLite($"[BL][Anuncio: 3] No se ha podido mostrar el anuncio: \n {id} \n {error} \n {mensaje}");
        }
        #endregion

        //Otras opciones para los anuncios
        #region mas opciones
        // Se llama cuando comienza la reproducción del anuncio
        public void OnUnityAdsShowStart(string _adUnitId) { }
        // Se llama cuando el usuario hace clic en el anuncio
        public void OnUnityAdsShowClick(string _adUnitId) { }
        // Se llama cuando se completa la reproducción del anuncio
        public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState) { }
        #endregion
    }

}