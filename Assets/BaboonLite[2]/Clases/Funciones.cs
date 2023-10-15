using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace BaboOnLite 
{
    public static class ArrayFun
    {
        //Funcion para coger un elemento de un IEnumerable
        internal static T Get<T>(this IEnumerable<T> array, int i) => array.ToArray()[i];

        //INARRAY/INLIST
        #region
        //Convierte el texto en array
        private static IEnumerable<T> _Array<T>(string text)
        {
            int start = text.IndexOf("[");
            int end = text.IndexOf("]");
            string subText = text.Substring(start + 1, end - start - 1);

            List<T> array = new List<T>();
            foreach (string s in subText.Split(','))
            {
                try
                {
                    T item = (T)Convert.ChangeType(s.Trim(), typeof(T));
                    array.Add(item);
                }
                catch (FormatException)
                {
                    Debug.LogWarning($"'{s.Trim()}' no es del tipo {typeof(T).Name}");
                }
            }

            return array;
        }
        //Funciones de llamada
        public static T[] inArray<T>(this string text) => _Array<T>(text).ToArray();
        public static List<T> inList<T>(this string text) => _Array<T>(text).ToList();
        #endregion

        //INSTRING
        #region
        //Convierte de array a texto
        public static string inString<T>(this IEnumerable<T> array)
        {
            string text = "[";
            for (int i = 0; i < array.Count(); i++)
            {
                text += (i != array.Count() - 1)
                    ? $"{array.Get(i)},"
                    : $"{array.Get(i)}";
            }
            return text + "]";
        }
        #endregion

        //FOREACH
        #region
        //Bucle de array
        public static void ForEach<T>(this IEnumerable<T> array, Action<T> func)
        {
            for (int i = 0; i < array.Count(); i++)
            {
                func(array.Get(i));
            }
        }
        public static void ForEach<T>(this IEnumerable<T> array, Action<T, int> func)
        {
            for (int i = 0; i < array.Count(); i++)
            {
                func(array.Get(i), i);
            }
        }
        #endregion

        //EVERY
        #region
        //Devuelve true si todas las condiciones son correctas
        public static bool Every<T>(this IEnumerable<T> array, Func<T, bool> func)
        {
            foreach (T item in array)
            {
                if (!func(item)) return false;
            }
            return true;
        }
        #endregion

        //SOME
        #region
        //Devuelve true si alguna condicion es correcta
        public static bool Some<T>(this IEnumerable<T> array, Func<T, bool> func)
        {
            foreach (T item in array)
            {
                if (func(item)) return true;
            }
            return false;
        }
        #endregion

        //FILTER
        #region
        //Devuelve los elementos que cumplan la condicion
        private static IEnumerable<T> _Filter<T>(IEnumerable<T> array, Func<T, bool> func)
        {
            List<T> result = new List<T>();
            for (int i = 0; i < array.Count(); i++)
            {
                if (func(array.Get(i))) result.Add(array.Get(i));
            }
            return result;
        }
        //Funciones de llamada
        public static T[] Filter<T>(this T[] array, Func<T, bool> func) => _Filter(array, func).ToArray();
        public static List<T> Filter<T>(this List<T> array, Func<T, bool> func) => _Filter(array, func).ToList();
        #endregion

        //MAP
        #region
        //Devuelve el array modificado
        public static IEnumerable<T2> _Map<T1, T2>(IEnumerable<T1> array, Func<T1, T2> func)
        {
            List<T2> result = new List<T2>();
            for (int i = 0; i < array.Count(); i++)
            {
                result.Add(func(array.Get(i)));
            }
            return result;
        }
        //Funciones de llamada
        public static T2[] Map<T1, T2>(this T1[] array, Func<T1, T2> func) => _Map(array, func).ToArray();
        public static List<T2> Map<T1, T2>(this List<T1> array, Func<T1, T2> func) => _Map(array, func).ToList();
        #endregion

        //SORT
        #region
        //Devuelve el array ordenado
        public static IEnumerable<T> _Sort<T>(this IEnumerable<T> array)
        {
            T[] result = array.ToArray();
            Array.Sort(result);
            return result;
        }
        //Funciones de llamada
        public static T[] Order<T>(this T[] array) => _Sort(array).ToArray();
        public static List<T> Order<T>(this List<T> array) => _Sort(array).ToList();
        #endregion

        //ORDER
        #region
        //Devuelve el array ordenado segun la condicion
        public static IEnumerable<T> _Sort<T>(this IEnumerable<T> array, Comparison<T> func)
        {
            T[] result = array.ToArray();
            Array.Sort(result, func);
            return result;
        }
        //Funciones de llamada
        public static T[] Order<T>(this T[] array, Comparison<T> func) => _Sort(array, func).ToArray();
        public static List<T> Order<T>(this List<T> array, Comparison<T> func) => _Sort(array, func).ToList();
        #endregion

        //INSIDE
        #region
        public static bool Inside<T>(this IEnumerable<T> array, int value)
        {
            if (value >= 0 && value < array.Count())
            {
                return true;
            }
            return false;
        }
        #endregion

    }

    public static class Bug
    {
        //LOG
        #region
        //Muestra un log del string y lo devuelve
        public static T Log<T>(this T text)
        {
            string convertedText = Convert.ToString(text);
            Debug.Log(convertedText);

            return text;
        }
        #endregion

        //[BUG]LOG
        #region
        //Muestra un log con informacion basica
        public static void Log(Color color = default)
        {
            string message = "<b>**-------**</b>";
            string colorHex = ColorUtility.ToHtmlStringRGBA((color == default) ? Color.white : color);

            Debug.LogFormat("<color=#{0}>{1}</color>", colorHex, message);
        }
        #endregion

        //[NUG]LOGLITE
        #region
        //Muestra un log del error de BaboonLite
        public static void LogLite(string texto)
        {
            string colorHex = ColorUtility.ToHtmlStringRGBA(Color.green);
            Debug.LogErrorFormat("<color=#{0}>{1}</color>", colorHex, texto);
        }
        #endregion

    }

    public static class Numeros {

        #region
        //Te suma o resta un valor a tu variable poniendole un limite
        public static float EquacionLimitada(this float variable, float valor, float limite)
        {
            variable += valor;
            if (variable > limite)
            {
                variable -= limite + 1;
            }
            if (variable < 0)
            {
                variable += limite + 1;
            }

            return variable;
        }
        #endregion
    }

    public static class Transformar {

        //TRANSFORM
        #region
        //Te permite modificar unicamente el valor X, Y o Z de un Vector3
        public static Vector3 Y(this Vector3 trans, float num) 
        {
            return new Vector3(trans.x, trans.y + num, trans.z);
        }
        public static Vector3 X(this Vector3 trans, float num)
        {
            return new Vector3(trans.x + num, trans.y, trans.z);
        }
        public static Vector3 Z(this Vector3 trans, float num)
        {
            return new Vector3(trans.x, trans.y, trans.z + num);
        }
        #endregion

        //QUATERNION
        #region
        public static Quaternion Y(this Quaternion trans, float num)
        {
            num = trans.eulerAngles.y.EquacionLimitada(num, 360);
            return Quaternion.Euler(trans.eulerAngles.x, num, trans.eulerAngles.z);
        }
        public static Quaternion X(this Quaternion trans, float num)
        {
            num = trans.eulerAngles.x.EquacionLimitada(num, 360);
            return Quaternion.Euler(num, trans.eulerAngles.y, trans.eulerAngles.z);
        }
        public static Quaternion Z(this Quaternion trans, float num)
        {
            num = trans.eulerAngles.z.EquacionLimitada(num, 360);
            return Quaternion.Euler(trans.eulerAngles.x, trans.eulerAngles.y, num);
        }
        #endregion
    }

}