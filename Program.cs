using System;
using System.Collections.Generic;

namespace CodingPractice
{
    struct S
    {
        public int i;
    }
    class Program
    {
        static void Main(string[] args)
        {
            //LongestSubstring.getLogngestSubstring("aaaabbaa");

            //bool[,] grid = Island.GetIsland(2, 2);
            //int count = Island.GetNumberOfIsland(grid);

            bool[,] grid = Island.GetIsland(3, 3);

            int uCount = Island.getUniqueIsland(grid);

            //int count = NumberOfUniquePath.GetUniquePath(3, 5);
        }
        public static void f1(out string s1,ref string s2)
        {
            s1 = "0";
            s2 += "0";
        }
        static String f2()
        {
            String s1 = "42", s2 = "43";
            f1(out s1,ref s2);
            return s1+s2;
        }

        public static void print(string s)
        {
            string[] lines = s.Split("\n");
            List<string> result = new List<string>();
            Dictionary<string, string[]> dic = new Dictionary<string, string[]>();
            foreach(string l in lines)
            {
                string[] data = l.Split(",");
                if (dic.ContainsKey(data[2]))
                {
                    if(Int32.Parse(dic[data[2]][1]) > Int32.Parse(data[3]))
                    {
                        //Adding name
                        dic[data[2]][0] = data[0].Trim();
                        //Adding version
                        dic[data[2]][1] = data[3].Trim();

                    }
                    //Adding count
                    int count = Int32.Parse(dic[data[2]][2]);
                    dic[data[2]][2] = (count + 1).ToString();
                }
                else
                {
                    string[] temp = new string[3];
                    temp[0] = data[0].Trim(); 
                    temp[1] = data[3].Trim().Split(' ')[1]; ;
                    temp[2] = "1".Trim();
                    dic.Add(data[2], temp);
                }
            }
            foreach(string key in dic.Keys)
            {
                string[] strs = dic[key];
                if (Int32.Parse(strs[2])>1){
                    Console.WriteLine(strs[0]);
                }
            }

        }

        public static bool ValidMountainArray(int[] arr)
        {
            bool isDec = false;
            int n = arr.Length;
            if (n < 3)
            {
                return false;
            }
            bool result = true;
            bool isFirstTrig = true;
            for (int i = 1; i < n; i++)
            {
                if (!isDec)
                {
                    if (arr[i - 1] < arr[i])
                    {

                    }
                    else if (isFirstTrig && i != 1)
                    {
                        isDec = true;
                        isFirstTrig = false;
                        i++;
                        if(i == n && arr[i-1] >= arr[i-2])
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        result = false;
                        return result;
                    }
                }
                else
                {
                    if (arr[i - 1] < arr[i])
                    {
                        result = false;
                        return result;
                    }
                }
            }
            return result;
        }



        public static int  solution(string S, string[] L)
        {
            int maxStr = 0;
            int[] charCount = getCharCount(S);
            foreach(string str in L)
            {
                int[] chars = getCharCount(str);
                int min = int.MaxValue;
                bool flagNotPossible = false;
                for(int i =0; i< 26; i++)
                {
                    if(chars[i] > 0)
                    {
                        int rChar = chars[i];
                        int hChar = charCount[i];
                        if(rChar == 0)
                        {
                            flagNotPossible = true;
                            break;
                        }
                        int possible = hChar / rChar;
                        if (possible == 0)
                        {
                            flagNotPossible = true;
                            break;
                        }
                        if (possible >= 1)
                        {

                            if (min> possible)
                            {
                                min = possible;
                            }
                        }
                    }
                }
                if(maxStr < min && !flagNotPossible && min != int.MaxValue)
                {
                    maxStr = min;
                }
            }

            return maxStr;
        }

        public static int[] solution2(string[] board, string moves)
        {
            int[] a = new int[2] { 0, 0 };
            int nextindex;
            string rowvalue;
            char v;
            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i] == 'D')
                {
                    if (board.Length - 1 < a[0] + 1)
                    {
                    }
                    else
                    {
                        nextindex = a[0] + 1;
                        rowvalue = board[nextindex];
                        v = rowvalue[a[1]];
                        if (v == '.')
                        {
                            a[0] = a[0] + 1;
                        }

                    }

                }
                else if (moves[i] == 'L')
                {
                    if (a[1] - 1 < 0)
                    {
                    }
                    else
                    {
                        nextindex = a[1] - 1;
                        rowvalue = board[a[0]];
                        v = rowvalue[nextindex];
                        if (v == '.')
                        {
                            a[1] = a[1] - 1;
                        }
                    }

                }
                else if (moves[i] == 'R')
                {
                    if (board[0].Length - 1 < a[1] + 1)
                    {

                    }
                    else
                    {
                        nextindex = a[1] + 1;
                        rowvalue = board[a[0]];
                        v = rowvalue[nextindex];
                        if (v == '.')
                        {
                            a[1] = a[1] + 1;
                        }
                    }

                }
                else
                {
                    if (a[0] - 1 < 0)
                    {

                    }
                    else
                    {
                        nextindex = a[0] - 1;
                        rowvalue = board[nextindex];
                        v = rowvalue[a[1]];
                        if (v == '.')
                        {
                            a[0] = a[0] - 1;
                        }
                    }

                }
            }


            return a;
        }


        public static int[] getCharCount(string S)
        {
            int[] charCount = new int[26];
            for (int i = 0; i < S.Length; i++)
            {
                int index = S[i] - 65;
                charCount[index]++;
            }
            return charCount;
        }

        public static string removeDuplicateFromString(string str)
        {
            string result = "";
            bool[] charInString = new bool[256];
            foreach(char c in str)
            {
                if (!charInString[c])
                {
                    charInString[c] = true;
                    result = result + c;
                }
                
            }
            return result;
        }
        public static int majorityElement(List<int> A)
        {
            float size = (float)((float)A.Count / 2);
            IDictionary<int, int> numbers = new Dictionary<int, int>();
            foreach (int num in A)
            {
                if (numbers.ContainsKey(num))
                {
                    numbers[num]++;
                }
                else
                {
                    numbers.Add(num, 1);
                }
            }
            Console.WriteLine(size);
            foreach (int key in numbers.Keys)
            {
                if (numbers[key] >= size)
                {
                    return key;
                }
            }
            return -1;
        }
        /// <summary>
        /// Q2
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        //public static int candy(List<int> A)
        //{
        //    List<int> candy = new List<int>();
        //    int count = 0;
        //    for (int i = 0; i < A.Count; i++)
        //    {
        //        candy.Add(1);
        //        count++;
        //    }
        //    for (int i = 0; i < A.Count; i++)
        //    {
        //        int next = i + 1;
        //        int pre = i - 1;
        //        if (next < A.Count && A[next] < A[i])
        //        {
        //            candy[i]++;
        //            count++;
        //            for (int j = i-1; j > 0; j--)
        //            {
        //                if(A[j] > A)
        //            }
        //        }
        //    }
        //    return count;
        //}
        public static bool isPriorityOk(List<int> A, List<int> priority, int index){
            bool p = false;
            if(index > 0 && A[index] > A[index - 1])
            {

            }
            return p;
        }

    }
}
