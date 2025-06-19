namespace ContentFontSizeChanged;

public static class FontSizeChangedHelper
{
    private static double ScaleFactor { get; } = 0.015;
    public static double Execute(double currentWidth, double minValue, double maxValue, double coefficient)
    {
        var baseSize = Math.Sqrt(currentWidth * currentWidth + (currentWidth * currentWidth) * 0.6) / Math.Sqrt(2);

        return Math.Clamp((baseSize * ScaleFactor) * coefficient, minValue, maxValue);
    }
}

