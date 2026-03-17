namespace Memos.Console.Models;

/// <summary>
/// Integer array class with methods to generate random numbers and find duplicities in the array.
/// </summary>
public class IntegerArray
{
    #region Properties

    /// <summary>
    /// Array containing numbers.
    /// </summary>
    public int[] Array { get; set; } = [];

    /// <summary>
    /// Dictionary containing duplicies in the array;
    /// </summary>
    public Dictionary<int, int> Duplicities { get; set; } = [];

    #endregion

    #region Constructors

    /// <summary>
    /// Default constructor
    /// </summary>
    public IntegerArray(int arraySize, int minValue, int maxValue)
    {
        if(arraySize <= 0)
        {
            throw new ArgumentException("Array size must be a positive number.");
        }

        Array = new int[arraySize];
        GenerateArray(minValue, maxValue);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Metod to generate random numbers in the array and the given range.
    /// </summary>
    /// <param name="minValue">Min value of the range.</param>
    /// <param name="maxValue">Max value of the range.</param>
    public void GenerateArray(int minValue, int maxValue)
    {
        var random = new Random();

        if(minValue > maxValue)
        {
            var tempValue = minValue;
            minValue = maxValue;
            maxValue = tempValue;
        }

        for (int i = 0; i < Array.Count(); i++)
        {
            Array[i] = random.Next(minValue, maxValue + 1);
        }
    }

    /// <summary>
    /// Find duplicities in the array and save them to the Duplicities property.
    /// </summary>
    public void FindDuplicitiesInArray()
    {
        Duplicities = Array.GroupBy(x => x)
            .Where(g => g.Count() > 1)
            .ToDictionary(g => g.Key, g => g.Count());
    }

    /// <summary>
    /// To string method to print the array and the duplicities in it.
    /// </summary>
    /// <returns>Result.</returns>
    public override string ToString()
    {
        var str = string.Empty;

        if (Array == null || Array.Length == 0)
        {
            return "Array is empty. \n";
        }

        if (Duplicities.Count == 0)
        {
            return "No duplicities found in the array. \n";
        }

        foreach(var item in Duplicities.OrderBy(x => x.Key))
        {
            str += $"{item.Key}: {item.Value} x. \n";
        }

        str += $"Total numbers with duplicies: {Duplicities.Count}";

        return str;
    }

    #endregion
}
