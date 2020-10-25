using System.Windows.Media;

namespace ImperiumGalacticaEditor
{
  public class Planet : ByteManaged
  {
    public string Name { get; set; }
    public int XPosIdx { get; set; }
    public int YPosIdx { get; set; }

    public int RaceIdx { get; set; }
    public int OwnerIdx { get; set; }
    public int PopulationIdx { get; set; }
    public int TypeIdx { get; set; }
    public int SizeIdx { get; set; }
    public int VisibilityIdx { get; set; }

    public int SatIdx { get; set; }
    public int SpySat1Idx { get; set; }
    public int SpySat2Idx { get; set; }
    public int Hubble2Idx { get; set; }
    public int Orbit1Idx { get; set; }
    public int Orbit2Idx { get; set; }
    public int Orbit3Idx { get; set; }

    private bool _hasSat;
    public bool HasSat
    {
      get { return _hasSat; }
      set { _hasSat = value; NotifyPropertyChanged("HasSat"); }
    }

    private bool _hasSpySat1;
    public bool HasSpySat1
    {
      get { return _hasSpySat1; }
      set { _hasSpySat1 = value; NotifyPropertyChanged("HasSpySat1"); }
    }

    private bool _hasSpySat2;
    public bool HasSpySat2
    {
      get { return _hasSpySat2; }
      set { _hasSpySat2 = value; NotifyPropertyChanged("HasSpySat2"); }
    }

    private bool _hasHubble2;
    public bool HasHubble2
    {
      get { return _hasHubble2; }
      set { _hasHubble2 = value; NotifyPropertyChanged("HasHubble2"); }
    }

    private byte _orbit1;
    public byte Orbit1
    {
      get { return _orbit1; }
      set { _orbit1 = value; NotifyPropertyChanged("Orbit1"); }
    }

    private byte _orbit2;
    public byte Orbit2
    {
      get { return _orbit2; }
      set { _orbit2 = value; NotifyPropertyChanged("Orbit2"); }
    }

    private byte _orbit3;
    public byte Orbit3
    {
      get { return _orbit3; }
      set { _orbit3 = value; NotifyPropertyChanged("Orbit3"); }
    }

    private byte _visibility;
    public byte Visibility
    {
      get { return _visibility; }
      set { _visibility = value; IsVisible = (value > 0); NotifyPropertyChanged("Visibility"); }
    }

    private bool _isVisible;
    public bool IsVisible
    {
      get { return _isVisible; }
      set { _isVisible = value; NotifyPropertyChanged("IsVisible"); }
    }

    private bool _isSelected;
    public bool IsSelected
    {
      get { return _isSelected; }
      set { _isSelected = value; NotifyPropertyChanged("IsSelected"); }
    }

    private Brush _playerColor;
    public Brush PlayerColor
    {
      get { return _playerColor; }
      set { _playerColor = value; NotifyPropertyChanged("PlayerColor"); }
    }

    private string _playerName;
    public string PlayerName
    {
      get { return _playerName; }
      set { _playerName = value; NotifyPropertyChanged("PlayerName"); }
    }

    private short _x;
    public short X
    {
      get { return _x; }
      set { _x = value; NotifyPropertyChanged("X"); }
    }

    private short _y;
    public short Y
    {
      get { return _y; }
      set { _y = value; NotifyPropertyChanged("Y"); }
    }

    private byte _size;
    public byte Size
    {
      get { return _size; }
      set { _size = value; NotifyPropertyChanged("Size"); }
    }

    private int _population;
    public int Population
    {
      get { return _population; }
      set { _population = value; NotifyPropertyChanged("Population"); }
    }

    private byte _owner;
    public byte Owner
    {
      get { return _owner; }
      set { _owner = value; SetPlayer(); NotifyPropertyChanged("Owner"); }
    }

    private byte _Race;
    public byte Race
    {
      get { return _Race; }
      set { _Race = value; NotifyPropertyChanged("Race"); }
    }

    private short _type;
    public short Type
    {
      get { return _type; }
      set { _type = value; NotifyPropertyChanged("Type"); }
    }

    void SetPlayer()
    {
      switch (Owner)
      {
        case 1:
          PlayerColor = Brushes.Gold;
          break;
        case 2:
          PlayerColor = Brushes.Red;
          break;
        case 3:
          PlayerColor = Brushes.White;
          break;
        case 4:
          PlayerColor = Brushes.Cyan;
          break;
        case 5:
          PlayerColor = Brushes.Magenta;
          break;
        case 6:
          PlayerColor = Brushes.Yellow;
          break;
        case 7:
          PlayerColor = Brushes.LimeGreen;
          break;
        case 8:
          PlayerColor = Brushes.GreenYellow;
          break;
        case 9:
          PlayerColor = Brushes.Blue;
          break;
        case 10:
          PlayerColor = Brushes.LightBlue;
          break;
        default:
          PlayerColor = Brushes.Gray;
          break;
      }
    }
  }
}
