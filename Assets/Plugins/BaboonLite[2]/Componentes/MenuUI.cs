using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace BaboOnLite
{
    [DefaultExecutionOrder(0)]
    [AddComponentMenu("BaboOnLite/MenuUI")]
    [DisallowMultipleComponent]
    //[HelpURL("")]

    public class MenuUI : MonoBehaviour
    {
        [SerializeField] bool activarTiempo = true;
        [Header("Botones")]
        [SerializeField] bool usarBotones = true;
        [SerializeField] KeyCode[] reiniciar = { KeyCode.R }, pausar = { KeyCode.P };
        private void Start() {
            if(activarTiempo) Time.timeScale = 1;
        }

        //Teclas
        private void Update()
        {
            if (usarBotones)
            {
                Botones(reiniciar, ReiniciarEscena);
                Botones(pausar, AlternarTiempo);
            }
        }

        private void Botones(KeyCode[] teclas, Action func) {
            teclas.ForEach((tecla) => {
                if (Input.GetKeyDown(tecla)) {
                    func.Invoke();
                }
            });
        }

        //Cambia la escena
        public static void CambioEscena(int escena) {
            Time.timeScale = 1;
            SceneManager.LoadScene(escena);
        }
        public static void CambioEscena(string escena) {
            Time.timeScale = 1;
            SceneManager.LoadScene(escena);
        }

        //Reinicia la escena
        public static void ReiniciarEscena() {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().name
            );
        }

        //Activa y desactiva un GameObject dependiendo su anterior estado
        public static void AlterarEstado(GameObject componente) {
            componente.SetActive(
                !componente.activeSelf    
            );
        }

        //Activa o desactiva un GameObject dependiendo lo que quieras
        public static void Activar(GameObject componente) {
            componente.SetActive(
                true
            );
        }
        public static void Desactivar(GameObject componente)
        {
            componente.SetActive(
                false
            );
        }

        //Pausa o quita el pausa del juego
        public static void PausarTiempo(bool pausa = true) {
            Time.timeScale = (pausa) ? 0 : 1;
        }
        public static void AlternarTiempo()
        {
            Time.timeScale = (Time.timeScale == 1) ? 0 : 1;
        }

        public void AbrirURL(string url)
        {
            Application.OpenURL(url);
        }
    }
}
