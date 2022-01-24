using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = System.Random;

namespace Ikatyros.LuckyNight
{
    public static class Extensions
    {
        public static bool IsNumKey()
        {
            return GetNumKey() != -1;
        }

        public static int GetNumKey()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad0)) return 0;
            else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad1)) return 1;
            else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad2)) return 2;
            else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad3)) return 3;
            else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad4)) return 4;
            else if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad5)) return 5;
            else if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad6)) return 6;
            else if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad7)) return 7;
            else if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad8)) return 8;
            else if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad9)) return 9;
            return -1;
        }

        public static bool IsNullOrEmpty<T>(this T item)
        {
            if (item == null) return true;
            return false;
        }

        public static bool IsNullOrEmpty<T>(this T[] array)
        {
            if (array == null) return true;
            if (array.Length == 0) return true;
            return false;
        }

        public static T Random<T>(this T[] array)
        {
            var randomizedArray = default(T);
            if (array.Length > 0)
            {
                randomizedArray = array[UnityEngine.Random.Range(0, array.Length)];
            }
            return randomizedArray;
        }

        public static T Random<T>(this List<T> list)
        {
            return list.ToArray().Random();
        }


        public static T[] Shuffle<T>(this T[] array)
        {
            var shuffledArray = default(T[]);
            if (array.Length > 0)
            {
                var rnd = new Random();
                shuffledArray = array.OrderBy(c => rnd.Next()).ToArray();
            }
            return shuffledArray;
        }

        public static List<T> Shuffle<T>(this List<T> list)
        {
            var randomizedList = new List<T>();
            var rnd = new Random();
            while (list.Count > 0)
            {
                // pick a random item from the master list
                var index = rnd.Next(0, list.Count);
                // place it at the end of the randomized list
                randomizedList.Add(list[index]);
                list.RemoveAt(index);
            }
            return randomizedList;
        }

        public static object EnumToArray(this Enum type, Array array)
        {
            object result = null;
            foreach (var item in array)
            {
                var v = item.GetType().GetField("type");
                if (type == v.GetValue(v))
                {
                    result = item;
                    break;
                }
            }
            return result;
        }

        public static Transform[] Children(this Transform t) => (from Transform v in t select v).ToArray();
    }
}