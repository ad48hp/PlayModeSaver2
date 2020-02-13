using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PMComponent
{
    public Component mycomponent
    {
        get
        {
            if (mycomp == null)
            {
                Debug.Log("Bi");
                Component[] findcompzz;
                findcompzz = UnityEngine.Object.FindObjectsOfType<Component>();
                foreach (Component cpjob in findcompzz)
                {
                    if (cpjob.GetInstanceID() == id)
                    {
                        Debug.Log("ngo");
                        mycomp = cpjob;
                    }
                }
            }
            return mycomp;
        }
        set
        {
            mycomp = value;
            id = value.GetInstanceID();
        }
    }
    private Component mycomp;
    private int id;
    public bool enabled;
    public List<PMProperty> myproperties;

    public PMComponent()
    {
        enabled = true;
        myproperties = new List<PMProperty>();
    }

    public PMComponent(Component mb01, bool mb02)
    {
        mycomponent = mb01;
        enabled = mb02;
        myproperties = new List<PMProperty>();
    }

    public PMComponent(Component mb01, bool mb02, List<PMComponent> mb03)
    {
        mycomponent = mb01;
        enabled = mb02;
        myproperties = new List<PMProperty>();
    }
}