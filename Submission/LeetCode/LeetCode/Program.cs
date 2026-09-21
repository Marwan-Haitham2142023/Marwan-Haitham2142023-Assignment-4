namespace LeetCode
{
    internal class Program
    {
        public static bool isAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            char[] charArray1 = s.ToLower().ToCharArray();
            char[] charArray2 = t.ToLower().ToCharArray();
            Array.Sort(charArray1);
            Array.Sort(charArray2);
            for (int i = 0; i < charArray1.Length; i++)
            {
                if (charArray1[i] != charArray2[i])
                    return false;
            }
            return true;
        }
        public static string GcdOfStrings(string str1, string str2)
        {
            if (str1 + str2 != str2 + str1)
                return "";

            char[] charArray1 = str1.ToCharArray();
            char[] charArray2 = str2.ToCharArray();

            int minLength = Math.Min(charArray1.Length, charArray2.Length);
            int count = 0;

            for (int i = 0; i < minLength; i++)
            {
                if (charArray1[i] == charArray2[i])
                    count++;
                else
                    break;
            }

            if (count == 0)
                return "";

            
            while (count > 0)
            {
                if (str1.Length % count == 0 && str2.Length % count == 0)
                    return str1.Substring(0, count);
                count--;
            }

            return "";
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GcdOfStrings("ABCABC", "ABC"));
        }
    }
}

