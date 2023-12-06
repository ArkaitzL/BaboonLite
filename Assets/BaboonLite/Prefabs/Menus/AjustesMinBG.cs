using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BaboOnLite;

public class AjustesMinBG : MonoBehaviour
{
    [Header("Ajustes")]
    [SerializeField] private AnimationCurve animacion;
    [SerializeField] private int[] posiciones;
    [SerializeField] private float duracion;
    [Header("Otros")]
    [SerializeField] private string url;
    [SerializeField] private Sprite[] idiomas;
    [SerializeField] private Sprite sonido_true, sonido_false;
    [SerializeField] private Sprite musica_true, musica_false;

    private bool activo;

    private Transform otros_trans, sonidos_trans, idiomas_trans, musica_trans;
    private Dictionary<bool, Sprite> sonidos;
    private Dictionary<bool, Sprite> musica;

    private void Start()
    {
        otros_trans = transform.GetChild(0);
        idiomas_trans = transform.GetChild(1);
        sonidos_trans = transform.GetChild(2);
        musica_trans = transform.GetChild(3);

        sonidos = new Dictionary<bool, Sprite>()
        {
            { true, sonido_true },
            { false, sonido_false }
        };
        musica = new Dictionary<bool, Sprite>()
        {
            { true, musica_true },
            { false, musica_false }
        };

        idiomas_trans.GetChild(0).GetComponent<Image>().sprite = idiomas[Save.Data.lenguaje];
        sonidos_trans.GetChild(0).GetComponent<Image>().sprite = sonidos[Save.Data.sonido[TipoSonido.sonidos.ToString()].estado];
        musica_trans.GetChild(0).GetComponent<Image>().sprite = musica[Save.Data.sonido[TipoSonido.musica.ToString()].estado];

    }
    public void Ajustes() {

        for (int i = 0; i < posiciones.Length; i++)
        {
            ControladorBG.MoverCanva(
                transform.GetChild(i).GetComponent<RectTransform>(),
                new(duracion, 
                    new Vector2((activo) ? transform.GetChild(transform.childCount-1).GetComponent<RectTransform>().anchoredPosition.x : posiciones[i], 0),
                    animacion
                )
            );
        }
        activo = !activo;
    }

    public void Otro()
    {
        MenuUI.AbrirURL(url);
    }
    public void Idioma()
    {
        Idiomas.Alternar();
        idiomas_trans.GetChild(0).GetComponent<Image>().sprite = idiomas[Save.Data.lenguaje];
    }
    public void Sonido() 
    {
        Alternar(sonidos_trans, TipoSonido.sonidos, sonidos);
    }
    public void Musica()
    {
        Alternar(musica_trans, TipoSonido.musica, musica);
    }
    private void Alternar(Transform trans, TipoSonido tipo, Dictionary<bool, Sprite> diccionario)
    {
        Sonidos.AlternarEstado(tipo);
        trans.GetChild(0).GetComponent<Image>().sprite = diccionario[Save.Data.sonido[tipo.ToString()].estado];
    }
}
