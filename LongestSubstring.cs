using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice
{
    public class LongestSubstring
    {
        public static string getLogngestSubstring(string str)
        {
            //aaaabbaa
            int n = str.Length;
            bool[,] dp = new bool[n,n];
            int start = 0;
            int end = 0;
            //mark palindrom for single element
            for(int i=0; i< n; i++)
            {
                dp[i, i] = true;
            }
            //mark palindrom for 2 elements
            for (int i = 1; i < n; i++)
            {
                if(str[i-1] == str[i])
                dp[i-1, i] = true;
                start = i - 1;
                end = i;
            }
            //length
            for(int j = 3; j<=n; j++)
            {
                for(int i=0; i<n-j+1; i++)
                {
                    // calculate end index
                    int k = i+j-1;
                    if(str[i] == str[k] && dp[i+1, k-1])
                    {
                        dp[i, k] = true;
                        start = i;
                        end = k;
                    }
                }
            }
            string result = str.Substring(start, end - start);
            return result;
        }
    }
}
