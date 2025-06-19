using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContentFontSizeChanged;

public class WindowSizeManager : INotifyPropertyChanged
{
    private static readonly WindowSizeManager _instance = new WindowSizeManager();
    public static WindowSizeManager Instance => _instance;

    private double _windowWidth;

    public double WindowWidth
    {
        get => _windowWidth;
        set
        {
            if (_windowWidth == value)
            {
                return;
            }

            _windowWidth = value;
            OnPropertyChanged(nameof(WindowWidth));

        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}


