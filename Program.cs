using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Practice_new
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] ch = { 'a','b','b','b','b','b','b','b','b','b','b'};
            Console.WriteLine($"Length of Char Array is {Compress(ch)}");
            //Console.WriteLine($"{CountandSay(5)}");
           // Console.WriteLine($"Squareroot of given muber is {Mysqrt(8)}");
            //int[] a = { 5,7,7,8,8,11};
            ////Console.WriteLine($"Minimum Element in Array is {findMinElement(a)}");
            //// printNFibonacciseries(7,4);
            //var findelem = 8;
            //var elementPosition = findElementinSortedArray(a, findelem);
            //int start = elementPosition, end = elementPosition;
            //while (start > 0 && a[start - 1] == findelem)
            //{
            //    start--;
            //}
            //while (end < a.Length - 1 && a[end + 1] == findelem)
            //{
            //    end++;
            //}
           // Console.WriteLine($"{start} to {end}");
            //Console.WriteLine($"Balanced:{IsbakancedBrackets("{{}}")}");
            //Console.WriteLine($"length of longest Substring is {lengthofLongestSubstring("ababcbd")}");
            // Console.WriteLine($"Number of characters to be deleted is {makeAnagram("abcdc", "cdcef")}");
            //Console.WriteLine($"Number divisible by all 1 to 10: {GetDivisibleNumber()}");

            // Console.WriteLine($"Count of balanced Strings is {balancedString("RLRLL")}");
            //TextInput input = new NumericInput();
            //input.Add('3');
            //input.Add('3');
            //input.Add('i');
            //input.Add('0');
            //string s = input.GetValue();
            //Console.WriteLine($"Value is {s} and length is {s.Length}");
            Console.ReadLine();
        }

        private static int Mysqrt(int X)
        {
            int n=0;
            n = Convert.ToInt32(Math.Sqrt(X));
            return n;
        }

        private static  int findMinElement(int[] nums) {
            int min = 0,len=nums.Length;
            min = nums[0];
            for (int i = 1; i < len; i++)
            {
                if (nums[i] < min)
                {
                    min = nums[i];
                }
            }
            
            return min;
        }
        //binary search algorithm
        private static int findElementinSortedArray(int []nums,int val)
        {
            int start = 0, n = nums.Length,end=nums.Length-1,index=-1;
            if (n == 0) { return -1; }
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (val == nums[mid])
                {
                    index = mid;
                    return index;
                    //Console.WriteLine($"Index of element {val} is {index}");

                
                }
                else if (val < nums[mid])
                {
                    end = mid - 1;
                     index = end+1;
                }
                else
                {
                    start = mid + 1;
                     index = start;
                }
            }
            return index;

            
        }

        private static void printNFibonacciseries(int n,int N)
        {
            int a = 0, b = 1, t = 0;
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{ b}");
                arr[i] = b;
                t = a + b;
                a = b;
                b = t;
                
            }
            Console.WriteLine($"{N}th element in fibonacci series is {arr[N - 1]}");
        }

        private static int Compress(char[] chars)
        {
            int len = 0,j=0;
            
            //Dictionary<char, int> set = new Dictionary<char, int>();
            //for(int i=0;i<chars.Length;i++)
            //{
            //    int count = 1;
            //    if (!set.ContainsKey(chars[i])) 
            //    {
            //        set.Add(chars[i], count);
            //    }
            //    else
            //    {
            //        set[chars[i]]++;

            //    }
            //}



            for (int i = 0;  i < chars.Length; i = j)
        {

                while ((j < chars.Length && chars[i] == chars[j]))
                {
                   
                    j++;

                }
                chars[len++] = chars[i];
                if ((j - i) <= 1) continue;
          
                foreach (char c in (j - i).ToString()) { chars[len++]= c; }
            }
            return len;



        }

        private static string CountandSay(int n)
        {
            string res = "1";
            int count = 0;
            if (n < 1 || n > 30)
            {
                Console.WriteLine("Number is not in the given range");
            }
            while (n > 1)
            {
                StringBuilder cur = new StringBuilder();
                for (int i = 0; i < res.Length; i++)
                {
                    count = 1;
                    while (i + 1 < res.Length && res.ElementAt(i) == res.ElementAt(i + 1))
                    {
                        count++;
                        i++;
                    }
                    cur.Append(count).Append(res.ElementAt(i));
                }
                n--;
                res = cur.ToString();
            }
            
            return res;
        }

        private static string IsbakancedBrackets(string s)
        {
           
            int i = 0, n = s.Length;
            if (n == 0) { return "NO"; }
            Dictionary<char,char> dct = new Dictionary<char,char>();
            dct.Add('}', '{');
            dct.Add(']', '[');
            dct.Add(')', '(');
            Stack<char> st = new Stack<char>();
            for (i = 0; i < n; i++)
            {
                char c = s.ElementAt(i);
                if (dct.ContainsKey(c))
                {
                    char topElement = dct[c];
                    if (st.Any())
                    {
                        if (st.Peek() == topElement)
                        {
                            st.Pop();
                        }
                        else { return "NO"; }
                    }
                    else { return "NO"; }
                   

                }
                else
                {
                    st.Push(c);
                }
                    
            }
            if (st.Count == 0)
            {
                return "YES";
            }
            else
            {
                return "NO";
            }
           
        }

        private static int makeAnagram(string src, string target)
        {
            var srcMap = new Dictionary<char, int>();

            foreach (var c in src)
            {
                if (!srcMap.ContainsKey(c))
                    srcMap.Add(c, 1);
                else
                    srcMap[c]++;
            }

            int charToDeleteCnt = 0;

            foreach (var c in target)
            {
                if (srcMap.ContainsKey(c))
                {
                    if (srcMap[c] <= 1) srcMap.Remove(c);
                    else srcMap[c]--;
                }
                else
                    charToDeleteCnt++;
            }

            charToDeleteCnt += srcMap.Sum(x => x.Value);

            return charToDeleteCnt;
        }

        private static int lengthofLongestSubstring(string s)
        {
            int len = 0,i=0,j=0, n = s.Length;
            HashSet<char> st = new HashSet<char>(); 
            while (i<n && j<n)
            {
                if (!st.Contains(s.ElementAt(j)))
                {
                    st.Add(s.ElementAt(j));
                    j++;
                    len = Math.Max(len, j - i);
                }
                else
                {
                    st.Remove(s.ElementAt(j));
                    i++;
                    
                }
                
            }
            //st.GetEnumerator();
            foreach(var str in st) { Console.WriteLine(str); }
            

            return len;

        }

        public static int balancedString(string s)
        {
            int count = 0, n = s.Length, i = 0;
           
            Stack<char> st = new Stack<char>();
            for (i = 0; i < n; i++)
            {
                if (!st.Any() || st.Peek()==(s.ElementAt(i)))
                {
                    st.Push(s.ElementAt(i));
                }
                else
                { st.Pop(); }

                if (!st.Any()) { count++; }
              }
            
            return count;
        }

           
        

            static int GetDivisibleNumber()
        {
            
            for (int i = 1; i < int.MaxValue; i++)
            {
                if (IsDivisible(i))
                
                 return i; 
                
            }

            return -1;
        }

        private static bool IsDivisible(int input)
        {
            for (int i = 1; i <= 10; i++)
            {
                if (input % i != 0)
                    return false;
            }
            return true;
        }
    }
    public class TextInput
    {

        public string str = "";
        public virtual void Add(char c)
        {
            str = str + c;
        }
        public string GetValue()
        {

            return str;
        }
    }

    public class NumericInput : TextInput
    {
        string oldstring = "";
        public override void Add(char c)
        {

            oldstring = str + c;
            str = Regex.Replace(oldstring, "[^.0-9]", "");
           
        }
    }
}
