using System;
using System.Threading.Tasks;

class Program
{
    delegate void Callback(int[] result);

    static async Task<int[]> AddVectorsAsync(int size)
    {
        int[] vector1 = new int[size];
        int[] vector2 = new int[size];
        int[] result = new int[size];

        Random rand = new Random();

        for (int i = 0; i < size; i++)
        {
            vector1[i] = rand.Next(10);
            vector2[i] = rand.Next(10);
        }

        await Task.Run(() =>
        {
            for (int i = 0; i < size; i++)
            {
                result[i] = vector1[i] + vector2[i];
            }
        });

        return result;
    }

    static void Main(string[] args)
    {
        int size = 5;
        Callback callback = PrintResult;

        AddVectorsAsync(size).ContinueWith(task =>
        {
            callback(task.Result);
        });

        Console.ReadKey();
    }

    static void PrintResult(int[] result)
    {
        Console.Write("Result: ");
        for (int i = 0; i < result.Length; i++)
        {
            Console.Write(result[i] + " ");
        }
    }
}