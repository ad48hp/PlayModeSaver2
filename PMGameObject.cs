using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PMGameObject
{
    public GameObject myobject
        {
        get
        {
            if (myobj == null)
            {
                Debug.Log("Bi");
                GameObject[] findobjectzz;
                findobjectzz = GameObject.FindObjectsOfType<GameObject>();
                foreach (GameObject gmjob in findobjectzz)
                {
                    if (gmjob.GetInstanceID() == id)
                    {
                        Debug.Log("ngo");
                        myobj = gmjob;
                    }
                }
            }
            return myobj;
        }
        set
         {
            myobj = value;
            id = value.GetInstanceID();
        }
    }
    private GameObject myobj;
    private int id;
    public bool enabled;
    public List<PMComponent> mycomponents;

    public PMGameObject()
    {
        enabled = true;
        mycomponents = new List<PMComponent>();
    }

    public PMGameObject(GameObject mb01,bool mb02)
    {
        myobject = mb01;
        enabled = mb02;
        mycomponents = new List<PMComponent>();
    }

    public PMGameObject(GameObject mb01, bool mb02, List<PMComponent> mb03)
    {
        myobject = mb01;
        enabled = mb02;
        mycomponents = mb03;
    }
}