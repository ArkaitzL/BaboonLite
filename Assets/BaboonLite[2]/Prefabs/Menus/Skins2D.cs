using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BaboOnLite {

    [DefaultExecutionOrder(1)]
    [AddComponentMenu("BaboOnLite/_Menus/Skins2D")]
    [DisallowMultipleComponent]
    [HelpURL("https://docs.google.com/document/d/1zPv7QP-ZyisadG5zREiMmzV7UWsYTUPZIPT0f_YlhSE/edit?usp=sharing")]
    public class Skins2D : MonoBehaviour
    {
        [SerializeField] private RectTransform contenedor, precio;
        [SerializeField] private GameObject skinPref;
        [SerializeField] private Sprite icono;
        [SerializeField] private Skin[] skins;

        private float tamaño = 450f;

        private void Start()
        {
            //Crea el menu con todas las skins
            #region crear
            //Dinero actual
            precio.GetChild(0).GetComponent<TextMeshProUGUI>().text = Save.Data.dinero.ToString();
            precio.GetChild(1).GetComponent<Image>().sprite = icono;

            //Skins
            bool inicial = false;
            foreach (var skin in skins)
            {
                /*
                 * 1.- Imagen
                 * 2.- Precio
                 * 3.- Bloqueo
                 * 4.- Boton
                 */

                //Crea las tarjetas
                Transform skinOBJ = Instantiate(skinPref, contenedor).transform;
                //Aumenta el tamaño del contenedor
                if (!inicial)
                {
                    inicial = true;
                }
                else
                {
                    contenedor.sizeDelta += new Vector2(tamaño, 0);
                }

                //Añade el contenido

                //1.-Imagen
                skinOBJ.GetChild(0).GetChild(0).GetComponent<Image>().sprite = skin.imagen;

                //2.-Precio
                if (skin.desbloqueado)
                {
                    skinOBJ.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    Transform precio = skinOBJ.GetChild(1);
                    TextMeshProUGUI textoPrecio = precio.GetChild(0).GetComponent<TextMeshProUGUI>();
                    textoPrecio.text = skin.precio.ToString();
                    precio.GetChild(1).GetComponent<Image>().sprite = icono;
                    if (skin.precio > Save.Data.dinero)
                    {
                        textoPrecio.color = Color.red;
                    }
                }
                //3.-Bloqueo
                skinOBJ.GetChild(2).gameObject.SetActive(!skin.desbloqueado);

                //4.-Boton
                skinOBJ.GetChild(3).GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (skin.desbloqueado)
                    {
                        Seleccionar(skin, skin.id);
                    }
                    else
                    {
                        Comprar(skin);
                    }
                });
            }
            #endregion
        }

        private void Comprar(Skin skin)
        {
            if (Save.Data.dinero > skin.precio)
            {
                Save.Data.dinero -= skin.precio;
                skin.desbloqueado = true;
            }
        }

        private void Seleccionar(Skin skin, int i)
        {
            if (skin.desbloqueado)
            {
                Save.Data.miSkin = i;
            }
        }
    }
}
