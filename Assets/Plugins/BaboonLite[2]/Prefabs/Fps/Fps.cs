using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

namespace BaboOnLite 
{
    [DefaultExecutionOrder(0)]
    [AddComponentMenu("BaboOnLite/Fps")]
    [DisallowMultipleComponent]
    //[HelpURL("")]

    public partial class Fps {
        [SerializeField] private TextMeshProUGUI fpsText;
        [SerializeField] private int fpsLimite = 90;
    }
    public partial class Fps : MonoBehaviour
    {
        void Start()
        {
            //Limite
            Application.targetFrameRate = fpsLimite;

            //Contador FPS
            List<int> media = new List<int>();
            Controlador.Rutina(.01f, () => {
                float fpsCont = 1f / Time.deltaTime;
                media.Add(Mathf.RoundToInt(fpsCont));
            }, true);

            Controlador.Rutina(1f, () => {
                fpsText.text = $"{(int)media.Average()} FPS";
            }, true);
        }
    }
}
