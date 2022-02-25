using System;
using System.Text;

namespace DefaultExtension
{
    public static class Extensions
    {
        /// <summary>
        /// Takes a <see cref="string"/> and the string encoding and returns a Base64 encoded <see cref="string"/> 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string EncodeBase64(this string text, Encoding encoding = null)
        {
            if (text == null) return String.Empty;
            if (encoding == null) encoding = Encoding.Latin1;
            byte[] bytes = encoding.GetBytes(text);
            var encodedStr = Convert.ToBase64String(bytes);
            return encodedStr;
        }

        /// <summary>
        /// Takes an base64 <see cref="string"/> and a string encoding and returns the original string in the specified encoding
        /// </summary>
        /// <param name="text"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string DecodeBase64(this string text, Encoding encoding = null)
        {
            if (text == null) return String.Empty;
            if (encoding == null) encoding = Encoding.Latin1;
            byte[] bytes = Convert.FromBase64String(text);
            var decodedStr = Encoding.Latin1.GetString(bytes);
            return decodedStr;
        }
        
        public static string ToHex(this int n)
        {
            return n.ToString("X");
        }

        public static string ToHex(this string str)
        {
            return int.Parse(str).ToString("X");
        }

        public static string FromListToString<T>(this List<T> list, string seperator="\n")
        {
            string str = String.Empty;
            int i = 0;
            foreach (T item in list)
            {
                if (i + 1 == list.Count) 
                    str += item.ToString();
                else
                    str += item.ToString() + $"{seperator}";
            }
            return str;
        }

        public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0) return min;
            else if (value.CompareTo(max) > 0) return max;
            else return value;
        }

        public static int Clamp(this int value, int min, int max) => Math.Clamp(value, min, max);
    }
}