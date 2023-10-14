using UnityEngine;


namespace BaboOnLite
{
    [DefaultExecutionOrder(0)]
    [AddComponentMenu("BaboOnLite/Limites (2D)")]
    [DisallowMultipleComponent]
    //[HelpURL("")]

    public class Limites : MonoBehaviour
    {

        [System.Serializable]
        public class Manual
        {
            [SerializeField] internal Transform izquierdo, derecho;
        }
        [Space]
        [SerializeField] Manual manual;
        [Space]
        [SerializeField] bool alturaAutomatica;
        [SerializeField] bool instanciaDefecto;

        static Limites get;

        //Valida el uso de height junto a instance
        private void OnValidate()
        {
            if (instanciaDefecto)
            {
                alturaAutomatica = true;
            }
        }
        //Instancia una referencia al script
        void Instance()
        {
            if (get == null)
            {
                get = this;
                return;
            }

            //No se puede poner dos scripts de este tipo en la misma escena
            Debug.LogError($"baboOn: 1.1.-Existen varias instancias de languages, se ha destruido la instancia de \"{gameObject.name}\"");
            Destroy(this);
        }
        //Posiciona los elementos a los bordes de la camara
        private void Awake()
        {
            Instance();
            Validate();

            float camWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;

            if (instanciaDefecto)
            {
                if (manual.derecho != null || manual.izquierdo != null)
                {
                    //Se han cambiado los limites manuales por los limites automaticos
                    Debug.LogWarning("baboOn: 1.3.-Se han cambiado los limites establecidos manualmente");
                }
                manual.izquierdo = Instance("left");
                manual.derecho = Instance("right");
            }

            if (alturaAutomatica)
            {
                Height(manual.izquierdo);
                Height(manual.derecho);
            }

            manual.izquierdo.position = new Vector3(
                Camera.main.transform.position.x - (camWidth / 2) - (manual.izquierdo.localScale.z / 2),
            0, 0);
            manual.derecho.position = new Vector3(
                Camera.main.transform.position.x + (camWidth / 2) + (manual.derecho.localScale.z / 2),
            0, 0);
        }
        //Valida que no tenga errores
        void Validate()
        {
            if (!instanciaDefecto)
            {
                if (manual.derecho == null || manual.izquierdo == null)
                {
                    //No estan ni los limites automatico, ni los manuales
                    Debug.LogError("baboOn: 1.2.-No tienes asignado ningun limite");
                }
            }
        }
        //Instancia dos BoxCollider2D
        Transform Instance(string name)
        {
            GameObject ob = new GameObject(name);
            ob.AddComponent<BoxCollider2D>();
            ob.transform.SetParent(transform);

            return ob.transform;
        }
        //Adapta el tamaño a la altura de la camara
        void Height(Transform go)
        {
            float camHeight = Camera.main.orthographicSize * 2;

            Vector3 scale = go.localScale;
            scale.y = camHeight;
            go.localScale = scale;
        }

    }
}
