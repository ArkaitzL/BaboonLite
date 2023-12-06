using TMPro;
using UnityEngine;
using BaboOnLite;

public class InicioBG : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mejor_puntuacion;
    void Start()
    {
        mejor_puntuacion.text = Save.Data.mejor_puntuacion.ToString("000");
    }
}
