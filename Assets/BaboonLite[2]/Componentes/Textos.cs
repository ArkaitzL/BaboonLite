using TMPro;
using UnityEngine;

namespace BaboOnLite {

    [DefaultExecutionOrder(1)]
    [AddComponentMenu("BaboOnLite/_Idiomas/Textos", 0)]
    [DisallowMultipleComponent]
    [HelpURL("https://docs.google.com/document/d/1zPv7QP-ZyisadG5zREiMmzV7UWsYTUPZIPT0f_YlhSE/edit?usp=sharing")]
    public class Textos : MonoBehaviour
    {
        [SerializeField] private DictionaryBG<TextMeshProUGUI> textos = new();

        private void OnValidate()
        {
            Cambiar();
        }

        void Start()
        {
            Cambiar();
            Idiomas.cambiarTextos += () => {
                Cambiar();
            };
        }

        private void Cambiar() {
            #region aplicar textos
            textos.ForEach((index, textMesh) => {
                if (textMesh != null && index != null)
                {
                    if (int.TryParse(index, out int i))
                    {
                        //Int
                        textMesh.text = Idiomas.Get(i);
                    }
                    else
                    {
                        //String
                    }
                }
            });
            #endregion
        }
    }
}

