using System;

public class Fraction
{
    // 🔐 Private fields
    private int _top;
    private int _bottom;

    // 🏗 Constructor 1: No parameters (defaults to 1/1)
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // 🏗 Constructor 2: One parameter (top only, bottom is 1)
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // 🏗 Constructor 3: Two parameters (top and bottom)
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // 🚪 Getter and Setter for Top
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    // 🚪 Getter and Setter for Bottom
    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // 📄 Returns the fraction as a string like "3/4"
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // 🔢 Returns the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
