namespace Chapter01_ArraysAndStrings;

public class Question07_RotateMatrixFor90
{

    private const int n = 4;
    public static void Run()
    {
        //     Input matrix
        //
        //    1   2   3   4
        //    5   6   7   8
        //    9  10  11  12
        //   13  14  15  16


        //     Expected output matrix
        //    
        //   13   9   5   1
        //   14  10   6   2
        //   15  11   7   3
        //   16  12   8   4

        Console.WriteLine("============ Input matrix ====================");
        PrettyPrintMatrix(GetInputMatrix());

        var inputMatrix = GetInputMatrix();
        RotateFor90V1(inputMatrix, n);

        var inputMatrix2 = GetInputMatrix();
        RotateFor90MyVersion(inputMatrix2, n);

        var inputMatrix3 = GetInputMatrix();
        RotateFor90MyVersionUpdated(inputMatrix3, n);
    }

    private static void RotateFor90V1(int[,] matrix, int n)
    {
        for (var layer = 0; layer < n / 2; layer++)
        {
            var first = layer;
            var last = n - 1 - layer;

            for (var i = first; i < last; i++)
            {
                var offset = i - first;
                var top = matrix[first, i]; // save top

                // left -> top
                matrix[first, i] = matrix[last - offset, first];

                // bottom -> left
                matrix[last - offset, first] = matrix[last, last - offset];

                // right -> bottom
                matrix[last, last - offset] = matrix[i, last];

                // top -> right
                matrix[i, last] = top; // right <- saved top
            }
        }

        Console.WriteLine("============ RotateFor90V1 ===================");
        PrettyPrintMatrix(matrix);
    }
        
    private static void RotateFor90MyVersionUpdated(int[,] a, int n)
    {
        int[,] rotated = new int[n, n];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                rotated[i, j] = a[n - 1 - j, i];


        Console.WriteLine("============ RotateFor90MyVersionUpdated =====");
        PrettyPrintMatrix(rotated);
    }

    private static void RotateFor90MyVersion(int[,] a, int n)
    {
        int[,] rotated = new int[n, n];

        var rowIndex = n - 1;
        var columntIndex = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                rotated[i, j] = a[rowIndex, columntIndex];
                rowIndex--;
            }
            columntIndex++;
            rowIndex = n - 1;
        }

        Console.WriteLine("============ RotateFor90MyVersion ============");
        PrettyPrintMatrix(rotated);
    }

    private static void PrettyPrintMatrix(int[,] matrix)
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

    private static int[,] GetInputMatrix() => new int[n, n] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
}