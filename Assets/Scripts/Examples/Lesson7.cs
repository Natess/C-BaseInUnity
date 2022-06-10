using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Lesson7
{
    internal static class Lesson7
    {

        //2. Реализовать метод расширения для поиска количество символов в строке.
        public static int CountSymbolWithLINQ(this string str, char symbol)
        {
            //Реализация с linq
            return str.Count(x => x == symbol);
        }

        public static int CountSymbol(this string str, char symbol)
        {
            var res = 0;
            foreach (var s in str)
            {
                if(s == symbol)
                    res++;
            }
            return res;
        }

        //3. Дана коллекция List<T>.Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
        //а.для целых чисел;
        public static Dictionary<int, int> CountEachIntElement(List<int> list)
        {
            Dictionary<int, int> dict = new Dictionary<int,int>();
            foreach (var item in list)
            {
                if(dict.ContainsKey(item))
                    dict[item]++;
                else
                    dict[item] = 1;
            }
            return dict;
        }

        //b. * для обобщенной коллекции;
        public static Dictionary<T, int> CountEachTElement<T>(List<T> list)
        {
            Dictionary<T, int> dict = new Dictionary<T, int>();
            foreach (var item in list)
            {
                
                if(dict.ContainsKey(item))
                    dict[item]++;
                else
                    dict[item] = 1;
            }
            return dict;
        }

        // с. ** используя Linq.
        public static Dictionary<T, int> CountEachTElementWithLinq<T>(List<T> list)
        {
            return list.GroupBy(g => g)
                .Select(s => new KeyValuePair<T, int>(s.Key, s.Count()))
                .ToDictionary(x => x.Key, x => x.Value);
        }

        //4. * В методичке дан фрагмент программы, необходимо:
        //а.Свернуть обращение к OrderBy с использованием лямбда-выражения =>.
        public static void Task4 ()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four", 4 },
                {"two", 2},
                {"one", 1},
                {"three", 3 }
            };
            var d = dict.OrderBy(x => x.Value);
            foreach (var pair in d)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
        }

        //b. * Развернуть обращение к OrderBy с использованием делегата
        static Func<KeyValuePair<string, int>, int> compare = (keyValuePair) => { return keyValuePair.Value; };
        public static void Task4WithDelegate()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four", 4 },
                {"two", 2},
                {"one", 1},
                {"three", 3 }
            };

            var d = dict.OrderBy(compare);
            foreach (var pair in d)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
        }
    }
}
