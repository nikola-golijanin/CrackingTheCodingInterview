namespace Chapter01_ArraysAndStrings;

public class MatrixHelpers
{
    public static void PrettyPrintMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
    }
    public static int[,] GetInputMatrix() => new int[4, 4] {
         { 1, 2, 0, 4 },
         { 5, 6, 7, 8 },
         { 9, 0, 11, 12 },
         { 13, 14, 15, 16 } };
}
