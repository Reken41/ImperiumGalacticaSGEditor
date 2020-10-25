using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ImperiumGalacticaEditor
{
  public class SavedGame : ByteManaged
  {
    int moneyIdx = 45;
    int levelIdx = 28;
    int planetsStartIdx = 139023;
    int unitsStartIdx = 69380;
    int unitBytes = 42;
    int planetBytes = 71;
    int planetNameLength = 12;
    int planetPopulationIdx = 52;
    int planetOwnerIdx = 48;
    int planetRaceIdx = 47;
    int planetTypeIdx = 49;

    public List<UnitInfo> UnitInfos { get; set; }

    public ObservableCollection<Planet> Planets { get; set; }
    public ObservableCollection<UnitsAndBuildings> UnitsAndBuildings { get; set; }

    private string _fileName;
    public string FileName
    {
      get { return _fileName; }
      set { _fileName = value; NotifyPropertyChanged("FileName"); }
    }

    private byte _level;
    public byte Level
    {
      get { return _level; }
      set { _level = value; UpdateValue(value, levelIdx); NotifyPropertyChanged("Level"); }
    }

    private string _path;
    public string Path
    {
      get { return _path; }
      set { _path = value; NotifyPropertyChanged("Path"); }
    }

    private int _money;
    public int Money
    {
      get { return _money; }
      set { _money = value; UpdateValue(value, moneyIdx); NotifyPropertyChanged("Money"); }
    }

    string[] unitNames = new string[] { "Fighter 1", "Fighter 2", "Fighter 3", "Fighter 4", "Fighter 5", "Fighter 6", "Destroyer 1", "Destroyer 2", "Destroyer 3", "Cruiser 1", "Cruiser 2", "Cruiser 3", "Flagship 1", "Flagship 2", "Flagship 3", "Colonization Ship", "Leviatan", "X", "Survey Satellite", "Spy Satellite", "Adv. Spy Satellite", "Hubble 2", "X", "X", "Space Base 1", "Orbital Factory", "Space Base 2", "Space Base 3", "X", "X", "Hyperdrive v1.0", "Hyperdrive v2.0", "Hyperdrive v3.0", "Hyperdrive v4.0", "Hyperdrive v5.0", "X", "Fuzzbox ECM", "Shocker ECM", "Cargo Pod", "Heavy Cargo Pod", "X", "X", "Radar Array", "Field Array", "Phased Array", "X", "X", "X", "Light Shield", "Medium Shield", "Heavy Shield", "Super Heavy Shield", "X", "X", "X", "X", "X", "X", "X", "X", "Laser", "Pulse Laser", "UV Laser", "UV Pulse Laser", "X", "X", "Ion Gun", "Plasma Gun", "Neutron Gun", "Meson Gun", "X", "X", "Bomb v1.0", "Bomb v2.0", "VirusBomb", "Missile v1.0", "Missile v2.0", "Mul-Head Missile", "Light Tank", "Medium Tank", "Heavy Tank", "Behemoth", "X", "X", "Radar Car", "Rocked Sled", "Heavy Rocket Sled", "X", "X", "X", "Solar Plant", "Phood(TM) Factory", "Trade Center", "X", "X", "X", "Invasion Shield", "Hyper Shield", "Fortress", "Stronghold", "Bunker", "X", "Radar Telescope", "Field Telescope", "Phased Telescope", "X", "X", "X", "Plasma Projector", "Fusion Projector", "Meson Projector", "X", "X", "X", "X", "X", "X", "X", "X", "X", };

    public SavedGame()
    {
      Planets = new ObservableCollection<Planet>();
      UnitsAndBuildings = new ObservableCollection<UnitsAndBuildings>();
      UnitInfos = new List<UnitInfo>();
      UnitInfos.Add(new UnitInfo("", "000"));

      int unit = 0;
      for (int g = 1; g < 5; g++)
      {
        for (int i = 1; i < 6; i++)
        {
          for (int k = 1; k < 7; k++)
          {
            if (unitNames[unit] != "X")
              UnitInfos.Add(new UnitInfo(unitNames[unit], g.ToString() + i.ToString() + k.ToString()));
            unit++;
          }
        }
      }

      for (int i = 0; i < unit; i++)
      {
        if (unitNames[i] != "X")
        {
          int unitIdx = unitsStartIdx + (i * unitBytes);
          UnitsAndBuildings.Add(new UnitsAndBuildings() { Name = unitNames[i], ResearchStateIdx = unitIdx, ResearchCostIdx = unitIdx + 10, CountIdx = unitIdx + 1, CivIdx = unitIdx + 29, MechIdx = unitIdx + 30, CompIdx = unitIdx + 31, AiIdx = unitIdx + 32, MilIdx = unitIdx + 33, Req1Idx = unitIdx + 18, Req2Idx = unitIdx + 21, Req3Idx = unitIdx + 24 });
        }
      }
    }

    public void Save()
    {
      if (string.IsNullOrWhiteSpace(Path) == false && array != null && array.Length > 0)
      {
        foreach (Planet planet in Planets)
        {
          UpdateValue(planet.X, planet.XPosIdx);
          UpdateValue(planet.Y, planet.YPosIdx);
          UpdateValue(planet.Owner, planet.OwnerIdx);
          UpdateValue(planet.Population, planet.PopulationIdx);
          UpdateValue(planet.Race, planet.RaceIdx);
          UpdateValue(planet.Type, planet.TypeIdx);
          UpdateValue(planet.Size, planet.SizeIdx);
          UpdateValue(planet.Visibility, planet.VisibilityIdx);

          UpdateValue(planet.HasSat, planet.SatIdx);
          UpdateValue(planet.HasSpySat1, planet.SpySat1Idx);
          UpdateValue(planet.HasSpySat2, planet.SpySat2Idx);
          UpdateValue(planet.HasHubble2, planet.Hubble2Idx);

          UpdateValue(planet.Orbit1, planet.Orbit1Idx);
          UpdateValue(planet.Orbit2, planet.Orbit2Idx);
          UpdateValue(planet.Orbit3, planet.Orbit3Idx);
        }

        foreach (UnitsAndBuildings unit in UnitsAndBuildings)
        {
          UpdateValue(unit.Count, unit.CountIdx);
          UpdateValue(unit.ResearchState, unit.ResearchStateIdx);
          UpdateValue(unit.ResearchCost, unit.ResearchCostIdx);
          UpdateValue(unit.Civ, unit.CivIdx);
          UpdateValue(unit.Mech, unit.MechIdx);
          UpdateValue(unit.Comp, unit.CompIdx);
          UpdateValue(unit.Ai, unit.AiIdx);
          UpdateValue(unit.Mil, unit.MilIdx);

          UpdateValue3xByte(unit.Req1, unit.Req1Idx);
          UpdateValue3xByte(unit.Req2, unit.Req2Idx);
          UpdateValue3xByte(unit.Req3, unit.Req3Idx);
        }

        ByteArrayToFile(Path, array);
        Status = "Saved";
      }
    }

    public void Open(string path)
    {
      FileName = path;
      isOpening = true;
      Planets.Clear();
      _path = path;
      array = File.ReadAllBytes(path);

      Money = GetValueInt(moneyIdx);
      Level = GetValueByte(levelIdx);

      for (int i = 0; i < 105; i++)
      {
        int planetZeroIdx = planetsStartIdx + (i * planetBytes);
        Planet planet = new Planet();
        planet.Name = GetValueString(planetZeroIdx, planetNameLength).Trim('\0');

        planet.XPosIdx = planetZeroIdx + planetNameLength;
        planet.X = GetValueShort(planet.XPosIdx);

        planet.YPosIdx = planetZeroIdx + planetNameLength + 2;
        planet.Y = GetValueShort(planet.YPosIdx);

        planet.PopulationIdx = planetZeroIdx + planetPopulationIdx;
        planet.Population = GetValueInt(planet.PopulationIdx);

        planet.OwnerIdx = planetZeroIdx + planetOwnerIdx;
        planet.Owner = GetValueByte(planet.OwnerIdx);

        planet.RaceIdx = planetZeroIdx + planetRaceIdx;
        planet.Race = GetValueByte(planet.RaceIdx);

        planet.TypeIdx = planetZeroIdx + planetTypeIdx;
        planet.Type = GetValueByte(planet.TypeIdx);

        planet.SizeIdx = planetZeroIdx + 16;
        planet.Size = GetValueByte(planet.SizeIdx);

        planet.SatIdx = planetZeroIdx + planetTypeIdx + 12;
        planet.HasSat = GetValueBool(planet.SatIdx);

        planet.SpySat1Idx = planetZeroIdx + planetTypeIdx + 13;
        planet.HasSpySat1 = GetValueBool(planet.SpySat1Idx);

        planet.SpySat2Idx = planetZeroIdx + planetTypeIdx + 14;
        planet.HasSpySat2 = GetValueBool(planet.SpySat2Idx);

        planet.Hubble2Idx = planetZeroIdx + planetTypeIdx + 15;
        planet.HasHubble2 = GetValueBool(planet.Hubble2Idx);

        planet.Orbit1Idx = planetZeroIdx + planetTypeIdx + 16;
        planet.Orbit1 = GetValueByte(planet.Orbit1Idx);

        planet.Orbit2Idx = planetZeroIdx + planetTypeIdx + 17;
        planet.Orbit2 = GetValueByte(planet.Orbit2Idx);

        planet.Orbit3Idx = planetZeroIdx + planetTypeIdx + 18;
        planet.Orbit3 = GetValueByte(planet.Orbit3Idx);

        planet.VisibilityIdx = planetZeroIdx + 51;
        planet.Visibility = GetValueByte(planet.VisibilityIdx);

        Planets.Add(planet);
      }

      foreach (UnitsAndBuildings unit in UnitsAndBuildings)
      {
        unit.Count = GetValueByte(unit.CountIdx);
        unit.ResearchState = GetValueByte(unit.ResearchStateIdx);
        unit.ResearchCost = GetValueInt(unit.ResearchCostIdx);

        unit.Civ = GetValueByte(unit.CivIdx);
        unit.Mech = GetValueByte(unit.MechIdx);
        unit.Comp = GetValueByte(unit.CompIdx);
        unit.Ai = GetValueByte(unit.AiIdx);
        unit.Mil = GetValueByte(unit.MilIdx);

        unit.Req1 = GetValue3xByte(unit.Req1Idx);
        unit.Req2 = GetValue3xByte(unit.Req2Idx);
        unit.Req3 = GetValue3xByte(unit.Req3Idx);
      }

      //var view = CollectionViewSource.GetDefaultView(Planets);71942
      //view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));71952

      isOpening = false;
    }

    bool ByteArrayToFile(string fileName, byte[] byteArray)
    {
      try
      {
        FileStream _FileStream = new FileStream(fileName, FileMode.Create);
        _FileStream.Write(byteArray, 0, byteArray.Length);
        _FileStream.Close();
        return true;
      }
      catch (Exception ex)
      {
      }

      return false;
    }


  }
}
