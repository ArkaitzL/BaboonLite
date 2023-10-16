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
        #region inArray/inList
        //Convierte el textoo en array
        private static IEnumerable<T> _Array<T>(string texto)
        {
            string subtexto = texto.Substring(
                texto.IndexOf("[") + 1,
                texto.IndexOf("]") - texto.IndexOf("[") - 1
            );

            List<T> array = new List<T>();
            foreach (string s in subtexto.Split(','))
            {
                try
                {
                    T elemento = (T)Convert.ChangeType(s.Trim(), typeof(T));
                    array.Add(elemento);
                }
                catch (FormatException)
                {
                    Bug.LogLite("[BL][Funciones: 1] No se a podido convertir en Array/Lista");
                }
            }

            return array;
        }
        //Funciones de llamada
        public static T[] inArray<T>(this string texto) => _Array<T>(texto).ToArray();
        public static List<T> inList<T>(this string texto) => _Array<T>(texto).ToList();
        #endregion

        //INSTRING
        #region inString
        //Convierte de array a textoo
        public static string inString<T>(this IEnumerable<T> array)
        {
            string texto = "[";
            for (int i = 0; i < array.Count(); i++)
            {
                texto += (i != array.Count() - 1)
                    ? $"{array.Get(i)},"
                    : $"{array.Get(i)}";
            }
            return texto + "]";
        }
        #endregion

        //FOREACH
        #region foreach
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
        #region every
        //Devuelve true si todas las condiciones son correctas
        public static bool Every<T>(this IEnumerable<T> array, Func<T, bool> func)
        {
            foreach (T elemento in array)
            {
                if (!func(elemento)) return false;
            }
            return true;
        }
        #endregion

        //SOME
        #region some
        //Devuelve true si alguna condicion es correcta
        public static bool Some<T>(this IEnumerable<T> array, Func<T, bool> func)
        {
            foreach (T elemento in array)
            {
                if (func(elemento)) return true;
            }
            return false;
        }
        #endregion

        //FILTER
        #region filter
        //Devuelve los elementos que cumplan la condicion
        private static IEnumerable<T> _Filter<T>(IEnumerable<T> array, Func<T, bool> func)
        {
            List<T> resultado = new List<T>();
            for (int i = 0; i < array.Count(); i++)
            {
                if (func(array.Get(i))) resultado.Add(array.Get(i));
            }
            return resultado;
        }
        //Funciones de llamada
        public static T[] Filter<T>(this T[] array, Func<T, bool> func) => _Filter(array, func).ToArray();
        public static List<T> Filter<T>(this List<T> array, Func<T, bool> func) => _Filter(array, func).ToList();
        #endregion

        //MAP
        #region map
        //Devuelve el array modificado
        public static IEnumerable<T2> _Map<T1, T2>(IEnumerable<T1> array, Func<T1, T2> func)
        {
            List<T2> resultado = new List<T2>();
            for (int i = 0; i < array.Count(); i++)
            {
                resultado.Add(func(array.Get(i)));
            }
            return resultado;
        }
        //Funciones de llamada
        public static T2[] Map<T1, T2>(this T1[] array, Func<T1, T2> func) => _Map(array, func).ToArray();
        public static List<T2> Map<T1, T2>(this List<T1> array, Func<T1, T2> func) => _Map(array, func).ToList();
        #endregion

        //INSIDE
        #region inside
        //Te dice si el numero del elemeno existe
        public static bool Inside<T>(this IEnumerable<T> array, int valor)
        {
            if (valor >= 0 && valor < array.Count())
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
        #region log
        //Muestra un log del string y lo devuelve
        public static T Log<T>(this T texto)
        {
            string convertedtexto = Convert.ToString(texto);
            Debug.Log(convertedtexto);

            return texto;
        }
        #endregion

        //[BUG]LOG
        #region [bug]Log
        //Muestra un log con informacion basica
        public static void Log(Color color = default)
        {
            string mensaje = "<b>**-------**</b>";
            string colorHex = ColorUtility.ToHtmlStringRGBA((color == default) ? Color.white : color);

            Debug.LogFormat("<color=#{0}>{1}</color>", colorHex, mensaje);
        }
        #endregion

        //[BUG]LOGLITE - PARA USO DE LA LIBRERIA
        #region [bug]LogLite
        //Muestra un log del error de BaboonLite
        public static void LogLite(string texto)
        {
            string colorHex = ColorUtility.ToHtmlStringRGBA(Color.green);
            Debug.LogErrorFormat("<color=#{0}>{1}</color>", colorHex, texto);
        }
        #endregion

    }

    public static class Numeros {

        //EQUACIONLIMITADA
        #region equacionLimitada
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
        #region transform
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
        #region quaternion
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