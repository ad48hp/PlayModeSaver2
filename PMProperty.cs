using System.Collections.Generic;
public class PMProperty
{
    public string name;
    public bool enabled;
    public PMPropertyTypeTeh pmtype;

    public PMProperty()
    {
        enabled = true;
     }

    public PMProperty(string mb01, bool mb02, PMPropertyTypeTeh mb03)
    {
        name = mb01;
        enabled = mb02;
        pmtype = mb03;
    }
}
public enum PMPropertyTypeTeh
{
Field,
Property
}