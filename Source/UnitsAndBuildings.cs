using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperiumGalacticaEditor
{
  public class UnitsAndBuildings : ByteManaged
  {
    public string Name { get; set; }

    private byte _researchState;
    public byte ResearchState
    {
      get { return _researchState; }
      set { _researchState = value; NotifyPropertyChanged("ResearchState"); }
    }

    private short _count;
    public short Count
    {
      get { return _count; }
      set { _count = value; NotifyPropertyChanged("Count"); }
    }

    private byte _civ;
    public byte Civ
    {
      get { return _civ; }
      set { _civ = value; NotifyPropertyChanged("Civ"); }
    }

    private byte _mech;
    public byte Mech
    {
      get { return _mech; }
      set { _mech = value; NotifyPropertyChanged("Mech"); }
    }

    private byte _comp;
    public byte Comp
    {
      get { return _comp; }
      set { _comp = value; NotifyPropertyChanged("Comp"); }
    }

    private byte _ai;
    public byte Ai
    {
      get { return _ai; }
      set { _ai = value; NotifyPropertyChanged("Ai"); }
    }

    private byte _mil;
    public byte Mil
    {
      get { return _mil; }
      set { _mil = value; NotifyPropertyChanged("Mil"); }
    }


    public int ResearchStateIdx { get; set; }
    public int CountIdx { get; set; }

    public int CivIdx { get; set; }
    public int MechIdx { get; set; }
    public int CompIdx { get; set; }
    public int AiIdx { get; set; }
    public int MilIdx { get; set; }

    private string _req1;
    public string Req1
    {
      get { return _req1; }
      set { _req1 = value; NotifyPropertyChanged("Req1"); }
    }

    private string _req2;
    public string Req2
    {
      get { return _req2; }
      set { _req2 = value; NotifyPropertyChanged("Req2"); }
    }

    private string _req3;
    public string Req3
    {
      get { return _req3; }
      set { _req3 = value; NotifyPropertyChanged("Req3"); }
    }

    public int Req1Idx { get; set; }
    public int Req2Idx { get; set; }
    public int Req3Idx { get; set; }

    private int _researchCost;
    public int ResearchCost
    {
      get { return _researchCost; }
      set { _researchCost = value; NotifyPropertyChanged("ResearchCost"); }
    }
    
    public int ResearchCostIdx { get; set; }
  }
}
