using UnityEngine;

namespace BaboOnLite 
{
    [DefaultExecutionOrder(0)]
    [AddComponentMenu("BaboOnLite/Singleton")]
    [DisallowMultipleComponent]
    [HelpURL("https://www.notion.so/BaboOnLite-c6252ac92bbc4f8ea231b1276008c13a?pvs=4")]

    public class Singleton : MonoBehaviour
    {
        void Awake()
        {
            Instanciar<Singleton>.Singletons(this, gameObject);
        }
    }
}
