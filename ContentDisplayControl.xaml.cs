using System.Windows;
using System.Windows.Controls;

namespace ContentFontSizeChanged;

public partial class ContentDisplayControl : UserControl
{

    public static Action<object, double,double,double> UpdateProperty;

    public ContentDisplayControl()
    {
        InitializeComponent();
        WindowSizeManager.Instance.PropertyChanged += Instance_PropertyChanged;
        Loaded += ContentDisplayControl_Loaded;
    }

    private void ContentDisplayControl_Loaded(object sender, RoutedEventArgs e)
    {
        Apply();
    }

    private void Instance_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName != "WindowWidth") return;

        Apply();
    }


    public new static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register(nameof(Content), typeof(object), typeof(ContentDisplayControl), new PropertyMetadata(null));

    public new object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    public static readonly DependencyProperty MinWidthSizeProperty = DependencyProperty.Register(
        nameof(MinWidthSize), typeof(double), typeof(ContentDisplayControl), new PropertyMetadata(25.0));

    public double MinWidthSize
    {
        get => (double)GetValue(MinWidthSizeProperty);
        set => SetValue(MinWidthSizeProperty, value);
    }

    public static readonly DependencyProperty MaxWidthSizeProperty = DependencyProperty.Register(
        nameof(MaxWidthSize), typeof(double), typeof(ContentDisplayControl), new PropertyMetadata(55.0));

    public double MaxWidthSize
    {
        get => (double)GetValue(MaxWidthSizeProperty);
        set => SetValue(MaxWidthSizeProperty, value);
    }


    public static readonly DependencyProperty WidthCoefficientProperty = DependencyProperty.Register(
        nameof(WidthCoefficient), typeof(double), typeof(ContentDisplayControl), new PropertyMetadata(1.0));

    public double WidthCoefficient
    {
        get => (double)GetValue(WidthCoefficientProperty);
        set => SetValue(WidthCoefficientProperty, value);
    }


    public static readonly DependencyProperty MinHeightSizeProperty = DependencyProperty.Register(
        nameof(MinHeightSize), typeof(double), typeof(ContentDisplayControl), new PropertyMetadata(25.0));

    public double MinHeightSize
    {
        get => (double)GetValue(MinHeightSizeProperty);
        set => SetValue(MinHeightSizeProperty, value);
    }

    public static readonly DependencyProperty MaxHeightSizeProperty = DependencyProperty.Register(
        nameof(MaxHeightSize), typeof(double), typeof(ContentDisplayControl), new PropertyMetadata(55.0));

    public double MaxHeightSize
    {
        get => (double)GetValue(MaxWidthSizeProperty);
        set => SetValue(MaxWidthSizeProperty, value);
    }


    public static readonly DependencyProperty HeightCoefficientProperty = DependencyProperty.Register(
        nameof(HeightCoefficient), typeof(double), typeof(ContentDisplayControl), new PropertyMetadata(1.0));

    public double HeightCoefficient
    {
        get => (double)GetValue(HeightCoefficientProperty);
        set => SetValue(HeightCoefficientProperty, value);
    }


    public static readonly DependencyProperty HeightSizeProperty = DependencyProperty.Register(
        nameof(HeightSize), typeof(double), typeof(ContentDisplayControl), new PropertyMetadata(0.0));

    public double HeightSize
    {
        get => (double)GetValue(HeightSizeProperty);
        set => SetValue(HeightSizeProperty, value);
    }


    public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
        nameof(MinValue), typeof(double), typeof(ContentDisplayControl), new PropertyMetadata(12.0));

    public double MinValue
    {
        get => (double)GetValue(MinValueProperty);
        set => SetValue(MinValueProperty, value);
    }

    public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
        nameof(MaxValue), typeof(double), typeof(ContentDisplayControl), new PropertyMetadata(20.0));

    public double MaxValue
    {
        get => (double)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    public static readonly DependencyProperty CoefficientProperty = DependencyProperty.Register(
        nameof(Coefficient), typeof(double), typeof(ContentDisplayControl), new PropertyMetadata(1.0));

    public double Coefficient
    {
        get => (double)GetValue(CoefficientProperty);
        set => SetValue(CoefficientProperty, value);
    }

    private void Apply()
    {
        var fontSize = FontSizeChangedHelper.Execute(WindowSizeManager.Instance.WindowWidth, MinValue, MaxValue, Coefficient);
        var width = FontSizeChangedHelper.Execute(WindowSizeManager.Instance.WindowWidth, MinWidthSize, MaxWidthSize, WidthCoefficient);
        var height = FontSizeChangedHelper.Execute(WindowSizeManager.Instance.WindowWidth, MinHeightSize, MaxHeightSize, HeightCoefficient);
        ApplyFontSizeToContent(fontSize, width, height);
    }

    private void ApplyFontSizeToContent(double fontSize, double width, double height)
    {
        if (Content is not null)
        {
            UpdateProperty?.Invoke(Content, fontSize, width,height);
        }
    }
}

