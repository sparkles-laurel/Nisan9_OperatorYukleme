Console.WriteLine("=== Named constructor of Complex ===");
Complex c0 = new Complex(3.0, 2.0);
Console.WriteLine($"c0 from named constructor: {c0}");

Console.WriteLine("=== Kompleks Tuple Conversions ===");

// 1. Implicit conversion from (decimal, decimal) tuple
Complex c1 = (3.5m, 2.1m);
Console.WriteLine($"c1 from (decimal, decimal): {c1}");

// 2. Implicit conversion from (double, double) tuple
Complex c2 = (1.2, -4.5);
Console.WriteLine($"c2 from (double, double): {c2}");

Console.WriteLine("\n=== Kompleks Deconstruction ===");

// 3. Deconstruct to variables
var (reDec, imDec) = c2; // Now correctly parses since Deconstruct is no longer ambiguous
Console.WriteLine($"Deconstructed c2: Real = {reDec}, Imaginary = {imDec}");

Console.WriteLine("\n=== Mathematical Operators ===");

Complex z1 = (3m, 4m);
Complex z2 = (1m, 2m);
Console.WriteLine($"z1 = {z1}");
Console.WriteLine($"z2 = {z2}");

Console.WriteLine($"Addition (z1 + z2): {z1 + z2}");
Console.WriteLine($"Subtraction (z1 - z2): {z1 - z2}");
Console.WriteLine($"Multiplication (z1 * z2): {z1 * z2}");
Console.WriteLine($"Division (z1 / z2): {z1 / z2}");
Console.WriteLine($"Unary Negation (-z1): {-z1}");

Console.WriteLine("\n=== Equality Operators ===");
Complex z3 = (3m, 4m);
Console.WriteLine($"z1 == z2: {z1 == z2}");
Console.WriteLine($"z1 != z2: {z1 != z2}");
Console.WriteLine($"z1 == z3 (where z3 is {z3}): {z1 == z3}");

Console.WriteLine("\n=== Properties ===");
Console.WriteLine($"z1.Real: {z1.Real}");
Console.WriteLine($"z1.Imaginary: {z1.Imaginary}");
Console.WriteLine($"z1.Modulus: {z1.Modulus}");
Console.WriteLine($"z1.Argument: {z1.Argument}");

Console.WriteLine("\n=== Explicit/Implicit Conversions ===");
Complex z4 = 5m; // implicit decimal
Console.WriteLine($"Implicit parameter conversions (5m): {z4}");
double realDouble = (double)z1; // explicit double
Console.WriteLine($"Explicit cast z1 to double: {realDouble}");

Console.WriteLine("\n=== Absolute Value & Named Constructors ===");
Complex z5 = Complex.FromImaginary(3.5m);
Console.WriteLine($"z5 created from Kompleks.FromImaginary(3.5m): {z5}");

decimal absZ1 = Complex.Abs(z1); // static absolute value
Console.WriteLine($"Absolute value of z1 (Kompleks.Abs(z1)): {absZ1}");
