using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace task5itransition.Pages.Models;

public class Settings : INotifyPropertyChanged
{
    private string _region = "de";
    private Random? _random;
    private int _seed = 123;
    private double _error = 0;

    public double Error
    {
        get => _error;
        set
        {
            if (_error == value) return;
            _error = value;
            OnPropertyChanged();
        }
    }
    
    public int Seed
    {
        get => _seed;
        set
        {
            if (_seed == value) return;
            _seed = value;
            OnPropertyChanged();
        }
    }

   public Random Random
    {
        get => _random;
        set
        {
            if (_random == value) return;
            _random = value;
            OnPropertyChanged();
        }
    }

    public string Region
    {
        get => _region;
        set
        {
            if (_region == value) return;
            _region = value;
            OnPropertyChanged();
        }
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}