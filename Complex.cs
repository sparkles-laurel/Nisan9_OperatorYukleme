using System;
using System.Globalization;

/// <summary>
/// Represents a complex number with arbitrary precision real and imaginary parts.
/// </summary>
public class Complex
{
    decimal im, re;

    /// <summary>
    /// Initializes a new instance of the <see cref="Complex"/> class with zero value.
    /// </summary>
    public Complex() : this(0m, 0m)
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Complex"/> class with the specified real and imaginary parts.
    /// </summary>
    /// <param name="re">The real part of the complex number.</param>
    /// <param name="im">The imaginary part of the complex number.</param>
    public Complex(decimal re, decimal im)
    {
        this.re = re;
        this.im = im;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Complex"/> class with the specified complex number.
    /// </summary>
    /// <param name="other">The other complex number.</param>
    public Complex(Complex other) : this(other.re, other.im)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Complex"/> class with the specified real and imaginary parts as double.
    /// </summary>
    /// <param name="re">The real part of the complex number.</param>
    /// <param name="im">The imaginary part of the complex number.</param>
    public Complex(double re, double im) : this((decimal)re, (decimal)im)
    { }

    /// <summary>
    /// Gets a complex number that represents zero (0 + 0i).
    /// </summary>
    public static Complex Zero => new(0m, 0m);

    /// <summary>
    /// Gets or sets the real part of the complex number.
    /// </summary>
    public decimal Real
    {
        get => re;
        set => re = value;
    }

    /// <summary>
    /// Gets or sets the imaginary part of the complex number.
    /// </summary>
    public decimal Imaginary
    {
        get => im;
        set => im = value;
    }

    /// <summary>
    /// Gets the argument (phase) of the complex number in radians.
    /// </summary>
    public double Argument
    {
        get => Math.Atan((double)im / (double)re);
    }

    /// <summary>
    /// Gets the modulus (magnitude or absolute value) of the complex number as a double.
    /// </summary>
    public double Modulus
    {
        get => (double)(re * re + im * im).Sqrt();
    }

    /// <summary>
    /// Adds two complex numbers.
    /// </summary>
    /// <param name="lhs">The left-hand side operand.</param>
    /// <param name="rhs">The right-hand side operand.</param>
    /// <returns>The result of the addition.</returns>
    public static Complex operator +(Complex lhs, Complex rhs)
    {
        return new Complex(lhs.re + rhs.re, lhs.im + rhs.im);
    }

    /// <summary>
    /// Subtracts a complex number from another.
    /// </summary>
    /// <param name="lhs">The left-hand side operand.</param>
    /// <param name="rhs">The right-hand side operand.</param>
    /// <returns>The result of the subtraction.</returns>
    public static Complex operator -(Complex lhs, Complex rhs)
    {
        return new Complex(lhs.re - rhs.re, lhs.im - rhs.im);
    }

    /// <summary>
    /// Multiplies two complex numbers.
    /// </summary>
    /// <param name="lhs">The left-hand side operand.</param>
    /// <param name="rhs">The right-hand side operand.</param>
    /// <returns>The result of the multiplication.</returns>
    public static Complex operator *(Complex lhs, Complex rhs)
    {
        return new Complex(lhs.re * rhs.re - lhs.im * rhs.im, lhs.re * rhs.im + lhs.im * rhs.re);
    }

    /// <summary>
    /// Divides a complex number by another.
    /// </summary>
    /// <param name="lhs">The dividend.</param>
    /// <param name="rhs">The divisor.</param>
    /// <returns>The result of the division.</returns>
    public static Complex operator /(Complex lhs, Complex rhs)
    {
        return new Complex((lhs.re * rhs.re + lhs.im * rhs.im) / (rhs.re * rhs.re + rhs.im * rhs.im), (lhs.im * rhs.re - lhs.re * rhs.im) / (rhs.re * rhs.re + rhs.im * rhs.im));
    }

    /// <summary>
    /// Determines whether two complex numbers are equal.
    /// </summary>
    /// <param name="lhs">The left-hand side operand.</param>
    /// <param name="rhs">The right-hand side operand.</param>
    /// <returns><c>true</c> if the values are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Complex lhs, Complex rhs) => Complex.Equals(lhs, rhs);

    /// <summary>
    /// Determines whether two complex numbers are not equal.
    /// </summary>
    /// <param name="lhs">The left-hand side operand.</param>
    /// <param name="rhs">The right-hand side operand.</param>
    /// <returns><c>true</c> if the values are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Complex lhs, Complex rhs) => !Complex.Equals(lhs, rhs);

    /// <summary>
    /// Negates a complex number.
    /// </summary>
    /// <param name="z">The value to negate.</param>
    /// <returns>The negated value.</returns>
    public static Complex operator -(Complex z) => new(-z.re, -z.im);

    /// <summary>
    /// Implicitly converts a double to a complex number with a zero imaginary part.
    /// </summary>
    /// <param name="i">The double value.</param>
    /// <returns>A new complex number.</returns>
    public static implicit operator Complex(double i) => new((decimal)i, 0);

    /// <summary>
    /// Implicitly converts a decimal to a complex number with a zero imaginary part.
    /// </summary>
    /// <param name="i">The decimal value.</param>
    /// <returns>A new complex number.</returns>
    public static implicit operator Complex(decimal i) => new(i, 0);

    /// <summary>
    /// Implicitly converts a tuple of two decimals to a complex number.
    /// </summary>
    /// <param name="pair">The tuple containing the real and imaginary parts.</param>
    /// <returns>A new complex number.</returns>
    public static implicit operator Complex((decimal, decimal) pair) => new(pair.Item1, pair.Item2);

    /// <summary>
    /// Implicitly converts a tuple of two doubles to a complex number.
    /// </summary>
    /// <param name="pair">The tuple containing the real and imaginary parts.</param>
    /// <returns>A new complex number.</returns>
    public static implicit operator Complex((double, double) pair) => new(pair.Item1, pair.Item2);

    /// <summary>
    /// Explicitly converts a complex number to a double, dropping the imaginary part.
    /// </summary>
    /// <param name="z">The complex number.</param>
    /// <returns>The real part as a double.</returns>
    public static explicit operator double(Complex z) => (double)z.re;

    /// <summary>
    /// Explicitly converts a complex number to a decimal, dropping the imaginary part.
    /// </summary>
    /// <param name="z">The complex number.</param>
    /// <returns>The real part as a decimal.</returns>
    public static explicit operator decimal(Complex z) => z.re;

    /// <summary>
    /// Creates a pure imaginary complex number from a decimal.
    /// </summary>
    /// <param name="i">The imaginary coefficient.</param>
    /// <returns>A purely imaginary complex number.</returns>
    public static Complex FromImaginary(decimal i) => new(0, i);

    /// <summary>
    /// Creates a pure imaginary complex number from a double.
    /// </summary>
    /// <param name="i">The imaginary coefficient.</param>
    /// <returns>A purely imaginary complex number.</returns>
    public static Complex FromImaginary(double i) => new(0, (decimal)i);

    /// <summary>
    /// Computes the principal square root of a <see cref="double"/> value, returning a complex number.
    /// </summary>
    /// <param name="i">The value whose square root is to be found.</param>
    /// <returns>The square root as a complex number.</returns>
    public static Complex Sqrt(double i)
    {
        if (i < 0) return FromImaginary(Math.Sqrt(-i));
        return new((decimal)Math.Sqrt(i), 0);
    }

    /// <summary>
    /// Computes the principal square root of a <see cref="decimal"/> value, returning a complex number.
    /// </summary>
    /// <param name="i">The value whose square root is to be found.</param>
    /// <returns>The square root as a complex number.</returns>
    public static Complex Sqrt(decimal i)
    {
        if (i < 0) return FromImaginary(i.Abs().Sqrt());
        return new(i.Sqrt(), 0);
    }

    /// <summary>
    /// Computes the absolute value (modulus) of a complex number as a decimal.
    /// </summary>
    /// <param name="z">The complex number.</param>
    /// <returns>The absolute value.</returns>
    public static decimal Abs(Complex z) => (z.re * z.re + z.im * z.im).Sqrt();

    /// <summary>
    /// Deconstructs the complex number into its real and imaginary decimal components.
    /// </summary>
    /// <param name="re">The output variable to store the real part.</param>
    /// <param name="im">The output variable to store the imaginary part.</param>
    public void Deconstruct(out decimal re, out decimal im)
    {
        re = this.re;
        im = this.im;
    }

    /// <summary>
    /// Returns a string representation of the complex number.
    /// </summary>
    /// <returns>A formatted string.</returns>
    public override string ToString()
    {
        if (im == 0)
        {
            return re.ToString();
        }
        else if (re == 0)
        {
            return $"{im}i";
        }
        else if (re < 0 && im > 0)
        {
            // Instead of `-3 + 4i`, print `4i - 3` cleanly.
            // Using `{-re}` to strip the negative sign from `re`.
            return $"{im}i - {-re}";
        }
        else if (im < 0)
        {
            // E.g., `3 - 4i` instead of `3 + -4i`.
            // Using `{-im}` to strip the negative sign from `im`.
            return $"{re} - {-im}i";
        }
        else
        {
            return $"{re} + {im}i";
        }
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current complex number.
    /// </summary>
    /// <param name="obj">The object to compare with.</param>
    /// <returns><c>true</c> if the objects are equal; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is Complex other)
        {
            return this.re == other.re && this.im == other.im;
        }
        return false;
    }

    /// <summary>
    /// Returns the hash code for the current complex number.
    /// </summary>
    /// <returns>A hash code based on the real and imaginary parts.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(re, im);
    }
}