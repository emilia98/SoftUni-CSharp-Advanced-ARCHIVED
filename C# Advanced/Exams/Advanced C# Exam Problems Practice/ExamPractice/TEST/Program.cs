using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    class Program
    {
        static char[][] matrix = new char[4][];
        static void Main(string[] args)
        {
            
            int rowsUsed = 0;
            int rows = 4;

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                if(rowsUsed == matrix.Length)
                {
                    rows += 4;
                    char[][] doubledMatrix = new char[rows][];
                    matrix.CopyTo(doubledMatrix, 0);
                    matrix = doubledMatrix;
                }

                matrix[rowsUsed] = input.ToCharArray();
                rowsUsed++;
            }

            Print(rowsUsed);

            for (int row = 1; row < rowsUsed - 1; row++)
            {
                for (int col = 1; col < matrix[row].Length - 1; col++)
                {
                    if(IsPlus(row, col))
                    {
                        Console.WriteLine(" " + matrix[row - 1][col]  + " ");
                        Console.WriteLine(matrix[row][col - 1] + matrix[row][col] + matrix[row][col + 1]);
                        Console.WriteLine(" " + matrix[row + 1][col] + " ");
                        Resize(row, col);
                        col--;
                    }
                   
                }

            }

            Print(rowsUsed);

        }

        static void Print(int rowsUsed)
        {
            for (int row = 0; row < rowsUsed; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        static bool IsInRange(int row, int col)
        {
            if(row - 1 < 0 || row + 1 >= matrix.Length)
            {
                return false;
            }
            // the cols in the row above
            int upperRowCols = matrix[row - 1].Length;
            // the cols in the row below
            int lowerRowCols = matrix[row + 1].Length;

            return col < upperRowCols && col < lowerRowCols;
        }

        static bool IsPlus(int row, int col)
        {
            char currentElement = matrix[row][col];

            if (!IsInRange(row, col))
            {
                return false;
            }

            return currentElement == matrix[row][col + 1]
                && currentElement == matrix[row][col - 1]
                && currentElement == matrix[row + 1][col]
                && currentElement == matrix[row - 1][col];
        }

        static void Resize(int row, int col)
        {
            int elementsOnRowAbove = matrix[row - 1].Length;
            int elementsOnRowBelow = matrix[row + 1].Length;
            int elementsOnCurrentRow = matrix[row].Length;

            char[] newRowAbove = new char[elementsOnRowAbove - 1];
            char[] newRowBelow = new char[elementsOnRowBelow - 1];
            char[] newRowCurrent = new char[elementsOnCurrentRow - 3];

            for(int i = 0; i <= elementsOnRowAbove; i++)
            {
                if(i == col)
                {
                    continue;
                }

                if(i > col)
                {
                    newRowAbove[i - 1] = matrix[row - 1][i];
                }
                else
                {
                    newRowAbove[i] = matrix[row - 1][i];
                }



                
            }

            for (int i = 0; i <= elementsOnRowBelow; i++)
            {
                if(i == col)
                {
                    continue;
                }

                newRowBelow[i] = matrix[row + 1][i];
            }

            for(int i = 0; i <= elementsOnCurrentRow; i++)
            {
                if(i == col || i == col - 1 || i == col + 1)
                {
                    continue;
                }

                newRowCurrent[i] = matrix[row][i];
            }
        }
    }
}
