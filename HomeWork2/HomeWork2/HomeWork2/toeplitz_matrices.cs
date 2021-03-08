using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class toeplitz_matrices
    {
       //toeplitz matrices question
        public static bool isToeplitz(int[][]a)
        {
            int m = a.Length;//if a matrix is a M*N matrix,then a.Length=M,a[0].Length=N
            int n = a[0].Length;//          
            for(int i = 1; i < m; i++)
            {
                for(int j = 1; j < n; j++)
                {
                    if (a[i-1][j-1] != a[i][j])
                    {
                        return false;
                    }
                    
                }
            }
            return true;
        }
    }
}
