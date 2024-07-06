namespace Chapter01_ArraysAndStrings;
using static MatrixHelpers;
public class Question08_ZeroMatrix
{
    public static void Run()
    {
        var matrix = GetInputMatrix();

        Console.WriteLine("============ Input matrix ====================");
        PrettyPrintMatrix(matrix);

        ZeroMatrix(matrix);

        Console.WriteLine("============ Output matrix ====================");
        PrettyPrintMatrix(matrix);


        Console.WriteLine("============= ZeroMatrixV2 ==================");

        var matrix2 = GetInputMatrix();

        Console.WriteLine("============ Input matrix ====================");
        PrettyPrintMatrix(matrix2);

        ZeroMatrixV2(matrix2);

        Console.WriteLine("============ Output matrix ====================");
        PrettyPrintMatrix(matrix2);
    }

    private static void ZeroMatrix(int[,] matrix)
    {
        var row = new bool[matrix.GetLength(0)];
        var column = new bool[matrix.GetLength(1)];

        // Store the row and column index with value 0
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    row[i] = true;
                    column[j] = true;
                }
            }
        }

        // Nullify rows
        for (var i = 0; i < row.Length; i++)
        {
            if (row[i])
            {
                NullifyRow(matrix, i);
            }
        }

        // Nullify columns
        for (var j = 0; j < column.Length; j++)
        {
            if (column[j])
            {
                NullifyColumn(matrix, j);
            }
        }
    }

    private static void ZeroMatrixV2(int[,] matrix)
    {
        var rowHasZero = false;
        var colHasZero = false;

        // Check if first row has a zero
        for (var j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[0, j] == 0)
            {
                rowHasZero = true;
                break;
            }
        }

        // Check if first column has a zero
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, 0] == 0)
            {
                colHasZero = true;
                break;
            }
        }

        // Check for zeros in the rest of the array
        for (var i = 1; i < matrix.GetLength(0); i++)
        {
            for (var j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    matrix[i, 0] = 0;
                    matrix[0, j] = 0;
                }
            }
        }

        // Nullify rows based on values in first column
        for (var i = 1; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, 0] == 0)
            {
                NullifyRow(matrix, i);
            }
        }

        // Nullify columns based on values in first row
        for (var j = 1; j < matrix.GetLength(1); j++)
        {
            if (matrix[0, j] == 0)
            {
                NullifyColumn(matrix, j);
            }
        }

        // Nullify first row
        if (rowHasZero)
        {
            NullifyRow(matrix, 0);
        }

        // Nullify first column
        if (colHasZero)
        {
            NullifyColumn(matrix, 0);
        }
    }

    private static void NullifyRow(int[,] matrix, int row)
    {
        for (var j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[row, j] = 0;
        }
    }

    private static void NullifyColumn(int[,] matrix, int col)
    {
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            matrix[i, col] = 0;
        }
    }

}
