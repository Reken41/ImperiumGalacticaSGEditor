using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperiumGalacticaEditor
{
  public abstract class ByteManaged : INotifyPropertyChanged
  {
    protected byte[] array;
    protected bool isOpening;

    private string _status = "Click open to load saved game...";
    public string Status
    {
      get { return _status; }
      set { if (_status != value) { _status = value; NotifyPropertyChanged("Status"); } }
    }

    protected void UpdateValue(int value, int index)
    {
      if (isOpening == false)
      {
        var byteValue = BitConverter.GetBytes(value);
        byteValue.CopyTo(array, index);
      }
    }

    protected void UpdateValue(byte value, int index)
    {
      if (isOpening == false)
        array[index] = value;
    }

    protected void UpdateValue(short value, int index)
    {
      if (isOpening == false)
      {
        var byteValue = BitConverter.GetBytes(value);
        byteValue.CopyTo(array, index);
      }
    }

    protected void UpdateValue(bool value, int index)
    {
      if (isOpening == false)
      {
        var byteValue = BitConverter.GetBytes(value);
        byteValue.CopyTo(array, index);
      }
    }

    protected void UpdateValue3xByte(string value, int index)
    {
      if (isOpening == false)
      {
        array[index] = Convert.ToByte(value[0].ToString());
        array[index + 1] = Convert.ToByte(value[1].ToString());
        array[index + 2] = Convert.ToByte(value[2].ToString());
      }
    }

    protected int GetValueInt(int index)
    {
      return BitConverter.ToInt32(array, index);
    }

    protected string GetValue3xByte(int index)
    {
      return array[index].ToString() + array[index + 1].ToString() + array[index + 2].ToString();
    }

    protected short GetValueShort(int index)
    {
      return BitConverter.ToInt16(array, index);
    }

    protected bool GetValueBool(int index)
    {
      return BitConverter.ToBoolean(array, index);
    }

    protected byte GetValueByte(int index)
    {
      return array[index];
    }

    protected string GetValueString(int index, int length)
    {
      byte[] partArray = new byte[length];
      Array.Copy(array, index, partArray, 0, length);
      return Encoding.UTF8.GetString(partArray);
    }

    #region INotifyPropertyChanged Members
    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged(string propertyName)
    {
      if (propertyName != "Status")
        Status = "Modified";

      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
  }
}
