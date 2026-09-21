# LeetCode Submissions

Problem-solving solutions for the SIMULATION · Software House & Academy program (simulationeg.com).
These solutions are kept separate from the Academy Schedule Analyzer application.

## LeetCode Account

LeetCode Profile: https://leetcode.com/u/marwan-haitham/

---

## Valid Anagram

- **Problem name:** Valid Anagram
- **Problem URL:** https://leetcode.com/problems/valid-anagram/submissions/2148148166/


### Solution (C#)

```csharp
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
```

### Explanation

- **How it determines whether the strings are anagrams:** Two strings are anagrams if they contain exactly the same characters 
with the same counts. After sorting the characters of both strings, anagrams become identical sequences, so comparing them position 
by position gives the answer.

- **Different lengths:** If the lengths differ, the strings cannot have the same characters with the same counts,
  so the method returns `false` immediately without any sorting.

- **Comparing character frequencies:** Sorting groups equal characters together, which makes the frequency of each character implicitly
   equal when the sorted arrays match. A common alternative is to count frequencies directly with
   an array of 26 integers (increment for `s`, decrement for `t`, and check that all counts are zero), which is O(n) time.

- **Time complexity:** O(n log n), dominated by sorting both arrays (n = length of the strings). 
  The comparison loop and the length check are O(n).

- **Space complexity:** O(n), for the two character arrays created by `ToCharArray()` (and the lowercase copies).

---

## Greatest Common Divisor of Strings

- **Problem name:** Greatest Common Divisor of Strings
- **Problem URL:** https://leetcode.com/problems/greatest-common-divisor-of-strings/submissions/2148156062/


### Solution (C#)

```csharp
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
```

### Explanation

- **What it means for one string to divide another:
  ** String `t` divides string `s` if `s` is `t` repeated one or more times (`s = t + t + ... + t`). 
  For example, `"AB"` divides `"ABABAB"`.

- **How repeated patterns are detected:** If both strings are built from the same repeating pattern, then `str1 + str2 == str2 + str1`.
  This concatenation check is the core test.

- **Why some pairs have no common divisor string:** If `str1 + str2 != str2 + str1`,
    the strings are not made from a shared pattern, so no string can divide both, and the method returns `""`.

- **How the greatest valid pattern is found:
   ** After the check passes, the common prefix is measured.
   The answer's length must divide both string lengths,
   so the code counts down from the prefix length to the largest value that divides both lengths.
   That value equals `gcd(str1.Length, str2.Length)`, and the prefix of that length is the answer.
   Example: `"ABABAB"` and `"ABAB"` give a prefix length of 4, which is reduced to 2, so the answer is `"AB"`.

- **Time complexity:** O(n + m), where n and m are the lengths of the two strings.
   The concatenations, array copies, prefix loop, and downward loop are each linear.


- **Space complexity:** O(n + m), for the concatenated strings and the character arrays.
