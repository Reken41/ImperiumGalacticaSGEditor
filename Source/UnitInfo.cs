namespace ImperiumGalacticaEditor
{
  public class UnitInfo
  {
    public string Name { get; set; }
    public string Tag { get; set; }

    public UnitInfo()
    {
    }

    public UnitInfo(string name, string tag)
    {
      Name = name;
      Tag = tag;
    }
  }
}
