using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice
{
    public class Island
    {
        public static bool[,] GetIsland(int m, int n)
        {
            bool[,] island = new bool[m, n];
            Random random = new Random();
            
            for(int i= 0; i<m; i++)
            {
                for(int j=0; j<n; j++)
                {
                    int num = random.Next(10);
                    if(num%2 == 0)
                    {
                        island[i, j] = true;
                    }
                    else
                    {
                        island[i, j] = false;
                    }
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(island[i, j]);
                }
                Console.WriteLine();
            }
            return island;
        }

        public static int GetNumberOfIsland(bool[,] grid)
        {
            int count = 0;
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            for(int i =0; i<m; i++)
            {
                for(int j= 0; j<n; j++)
                {
                    if (grid[i,j])
                    {
                        count++;
                        makeConectedToFalse(grid, i, j, m, n);
                    }
                
                }
            }
            return count;
        }

        public static int getMaxArea(bool[,] grid)
        {
            int maxArea = 0;
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            for(int i = 0; i< m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (grid[i, j])
                    {
                        int area = makeItZeroWithCount(grid, i, j, m, n);
                        if(area > maxArea)
                        {
                            maxArea = area;
                        }
                    }
                }
            }
            return maxArea;
        }

        public static int getUniqueIsland(bool[,] grid)
        {
            int count = 0;
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i, j])
                    {
                        string path=  computePath(grid, i, j, m, n, "X");
                        if (dic.ContainsKey(path))
                        {
                            dic[path]++;
                        }
                        else
                        {
                            dic.Add(path, 1);
                        }
                        int tempCount = dic[path];
                        if(tempCount > count)
                        {
                            count = tempCount;
                        }
                    }
                }
            }
            return count;
        }
        private static int makeItZeroWithCount(bool[,] grid, int i, int j, int m, int n)
        {
            int count = 0;
            if(i<0 || j< 0 || i>= m || j >= n || !grid[i, j])
            {
                return 0;
            }
            grid[i, j] = false;
            int up= makeItZeroWithCount(grid, i - 1, j, m, n);
            int down = makeItZeroWithCount(grid, i + 1, j, m, n);
            int right = makeItZeroWithCount(grid, i, j - 1, m, n);
            int left = makeItZeroWithCount(grid, i, j + 1, m, n);
            count = up + down + right + left + 1;
            return count;
        }

        private static string computePath(bool[,] grid, int i, int j, int m, int n, string path)
        {
            string tempPath = "";
            if (i < 0 || j < 0 || i >= m || j >= n || !grid[i, j])
            {
                return "O";
            }
            grid[i, j] = false;
            string up = computePath(grid, i - 1, j, m, n, "U");
            string down = computePath(grid, i + 1, j, m, n, "D");
            string right = computePath(grid, i, j - 1, m, n, "R");
            string left = computePath(grid, i, j + 1, m, n, "L");
            tempPath = up + down + right + left + path;
            return tempPath;
        }

        private static void makeConectedToFalse(bool[,] grid, int i, int j, int m, int n)
        {
            if(i<0 || j<0 || i>=m || j>=n || !grid[i,j])
            {
                return;
            }
            grid[i,j] = false;
            makeConectedToFalse(grid, i -1, j, m, n);
            makeConectedToFalse(grid, i+1, j, m, n);
            makeConectedToFalse(grid, i, j-1, m, n);
            makeConectedToFalse(grid, i, j+1, m, n);
        }
    }
}
