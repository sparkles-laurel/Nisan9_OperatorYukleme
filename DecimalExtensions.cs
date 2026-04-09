using System;

public static class DecimalExtensions
{
    /// <summary>
    /// Calculates square root for a <see cref="decimal"/>.
    /// </summary>
    /// <param name="x">The value to calculate the square root of.</param>
    /// <param name="epsilon"> 
    /// <returns>The square root of the value.</returns>
    public static decimal Sqrt(this decimal x, decimal epsilon = 0.0M)
    {
        if (x < 0) throw new OverflowException("Cannot calculate square root of a negative number.");
        if (x == 0) return 0;

        decimal current = (decimal)Math.Sqrt((double)x); // Start with a good guess
        decimal previous;
        do
        {
            previous = current;
            if (previous == 0) return 0;
            current = (previous + x / previous) / 2;
        }
        while (Math.Abs(previous - current) > epsilon);

        return current;
    }
    /// <summary>
    /// Calculates the absolute value of a <see cref="decimal"/>.
    /// </summary>
    /// <param name="x">The value to calculate the absolute value of.</param>
    /// <returns>The absolute value of the value.</returns>
    public static decimal Abs(this decimal x)
    {
        if (x < 0) return -x;
        return x;
    }
}