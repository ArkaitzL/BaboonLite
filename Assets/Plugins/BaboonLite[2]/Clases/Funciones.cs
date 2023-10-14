using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace BaboOnLite 
{
    internal static class Otros {
        internal static T Get<T>(this IEnumerable<T> array, int i) => array.ToArray()[i];
    }

    public static class Array1D
    {
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
        public static T[] inArray<T>(this string text) => _Array<T>(text).ToArray();
        public static List<T> inList<T>(this string text) => _Array<T>(text).ToList();
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
        //Devuelve true si todas las condiciones son correctas
        public static bool Every<T>(this IEnumerable<T> array, Func<T, bool> func)
        {
            foreach (T item in array)
            {
                if (!func(item)) return false;
            }
            return true;
        }
        //Devuelve true si alguna condicion es correcta
        public static bool Some<T>(this IEnumerable<T> array, Func<T, bool> func)
        {
            foreach (T item in array)
            {
                if (func(item)) return true;
            }
            return false;
        }
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
        public static T[] Filter<T>(this T[] array, Func<T, bool> func) => _Filter(array, func).ToArray();
        public static List<T> Filter<T>(this List<T> array, Func<T, bool> func) => _Filter(array, func).ToList();
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
        public static T2[] Map<T1, T2>(this T1[] array, Func<T1, T2> func) => _Map(array, func).ToArray();
        public static List<T2> Map<T1, T2>(this List<T1> array, Func<T1, T2> func) => _Map(array, func).ToList();
        //Devuelve el array ordenado
        public static IEnumerable<T> _Sort<T>(this IEnumerable<T> array)
        {
            T[] result = array.ToArray();
            Array.Sort(result);
            return result;
        }
        public static T[] Order<T>(this T[] array) => _Sort(array).ToArray();
        public static List<T> Order<T>(this List<T> array) => _Sort(array).ToList();
        //Devuelve el array ordenado segun la condicion
        public static IEnumerable<T> _Sort<T>(this IEnumerable<T> array, Comparison<T> func)
        {
            T[] result = array.ToArray();
            Array.Sort(result, func);
            return result;
        }
        public static T[] Order<T>(this T[] array, Comparison<T> func) => _Sort(array, func).ToArray();
        public static List<T> Order<T>(this List<T> array, Comparison<T> func) => _Sort(array, func).ToList();
        public static bool Inside<T>(this IEnumerable<T> array, int value)
        {
            if (value >= 0 && value < array.Count())
            {
                return true;
            }
            return false;
        }


    }

    public static class Bug
    {
        //Muestra un log del string y lo devuelve
        public static T Log<T>(this T text)
        {
            string convertedText = Convert.ToString(text);
            Debug.Log(convertedText);

            return text;
        }
        //Muestra un log con informacion basica
        public static void Log(Color color = default)
        {
            string message = "<b>**-------**</b>";
            string colorHex = ColorUtility.ToHtmlStringRGBA((color == default) ? Color.white : color);

            Debug.LogFormat("<color=#{0}>{1}</color>", colorHex, message);
        }
    }

    public static class Numeros {
        public static float EquacionLimitada(this float variable, float equacion, float limite) {
            variable += equacion;
            if (variable > limite) {
                variable -= limite+1;
            }
            if (variable < 0) {
                variable += limite+1;
            }

            return variable;
        }
    }

    public static class Transformar {

        //Transform
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

        //Quaternion
        public static Quaternion Y(this Quaternion trans, float num)
        {
            // Asegurarse de que num esté en el rango 0-360
            num = trans.eulerAngles.y.EquacionLimitada(num, 360);

            // Crear un nuevo Quaternion con los componentes modificados
            return Quaternion.Euler(trans.eulerAngles.x, num, trans.eulerAngles.z);
        }
        public static Quaternion X(this Quaternion trans, float num)
        {
            // Asegurarse de que num esté en el rango 0-360
            num = trans.eulerAngles.x.EquacionLimitada(num, 360);


            // Crear un nuevo Quaternion con los componentes modificados
            return Quaternion.Euler(num, trans.eulerAngles.y, trans.eulerAngles.z);
        }
        public static Quaternion Z(this Quaternion trans, float num)
        {
            // Asegurarse de que num esté en el rango 0-360
            num = trans.eulerAngles.z.EquacionLimitada(num, 360);

            // Crear un nuevo Quaternion con los componentes modificados
            return Quaternion.Euler(trans.eulerAngles.x, trans.eulerAngles.y, num);
        }
    }

}