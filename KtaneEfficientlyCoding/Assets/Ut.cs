﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rnd = UnityEngine.Random;

namespace DOYOUCOMEFROMALANDDOWNUNDERYEAYEA
{
    static class Ut
    {
        public static T Shuffle<T>(this T list) where T : IList
        {
            if (list == null)
                throw new ArgumentNullException("list");
            for (int j = list.Count; j >= 1; j--)
            {
                int item = Rnd.Range(0, j);
                if (item < j - 1)
                {
                    var t = list[item];
                    list[item] = list[j - 1];
                    list[j - 1] = t;
                }
            }
            return list;
        }

        public static T PickRandom<T>(this IEnumerable<T> src)
        {
            if (src == null)
                throw new ArgumentNullException("src");

            var arr = src.ToArray();
            if (arr.Length == 0)
                throw new InvalidOperationException("Cannot pick a random element from an empty set.");
            return arr[Rnd.Range(0, arr.Length)];
        }

        public static T PickRandomAndRemove<T>(this List<T> src)
        {
            if (src == null)
                throw new ArgumentNullException("src");

            var ix = Rnd.Range(0, src.Count);
            var t = src[ix];
            src.RemoveAt(ix);
            return t;
        }

        public static string JoinString<T>(this IEnumerable<T> values, string separator = null, string prefix = null, string suffix = null, string lastSeparator = null)
        {
            if (values == null)
                throw new ArgumentNullException("values");
            if (lastSeparator == null)
                lastSeparator = separator;

            using (var enumerator = values.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return "";

                // Optimise the case where there is only one element
                var one = enumerator.Current;
                if (!enumerator.MoveNext())
                    return prefix + one + suffix;

                // Optimise the case where there are only two elements
                var two = enumerator.Current;
                if (!enumerator.MoveNext())
                {
                    // Optimise the (common) case where there is no prefix/suffix; this prevents an array allocation when calling string.Concat()
                    if (prefix == null && suffix == null)
                        return one + lastSeparator + two;
                    return prefix + one + suffix + lastSeparator + prefix + two + suffix;
                }

                StringBuilder sb = new StringBuilder()
                    .Append(prefix).Append(one).Append(suffix).Append(separator)
                    .Append(prefix).Append(two).Append(suffix);
                var prev = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    sb.Append(separator).Append(prefix).Append(prev).Append(suffix);
                    prev = enumerator.Current;
                }
                sb.Append(lastSeparator).Append(prefix).Append(prev).Append(suffix);
                return sb.ToString();
            }
        }

        public static int IndexOf<T>(this IEnumerable<T> source, Func<T, bool> lookingFor)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var index = 0;
            foreach (var element in source)
            {
                if (lookingFor(element))
                    return index;
                index++;
            }
            return -1;
        }

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> src)
        {
            if (src == null)
                throw new ArgumentNullException("src");
            return new HashSet<T>(src);
        }
    }
}
