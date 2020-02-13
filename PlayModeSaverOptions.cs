using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class PlayModeSaverOptions : EditorWindow
{
    List<PMGameObject> tosavegozz = new List<PMGameObject>();
    public List<object> myobjzz = new List<object>();
    public GUIStyle whitendblack;
    public bool remembersettings = false;
    public bool showcomponents = true;
    public bool showfields = true;
    public bool serializefields = false;
    List<PMSerializedComponent> tosavegozz22 = new List<PMSerializedComponent>();
    List<PMSerializedComponent> tosavegozz48 = new List<PMSerializedComponent>();
    public List<string> tagzz911420 = new List<string>();
    public List<string> layerzz911420 = new List<string>();
    public bool sotbox = false;
    public bool sotbox22 = false;
    public bool serializeChildzz = true;

    [MenuItem("Window/Play Mode Saver , Preferences")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(PlayModeSaverOptions));
    }

    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }

    void OnGUI()
    {
        if (remembersettings)
        {
            if (tosavegozz.Count == 0)
            {
                if (EditorPrefs.HasKey("tosaveZZOG"))
                {
                    string mysavezz911911;
                    mysavezz911911 = EditorPrefs.GetString("tosaveZZOG");
                    Debug.Log(mysavezz911911);
                    if (mysavezz911911 == null)
                    {
                        tosavegozz = (List<PMGameObject>)JSONExt.Deserialize(mysavezz911911);
                    }
                }
            }
            else
            {
                string tosaveGOZZ6969 = JSONExt.Serialize(tosavegozz);
                Debug.Log(tosaveGOZZ6969);
                EditorPrefs.SetString("tosaveZZOG", tosaveGOZZ6969);
            }
        }
            EditorApplication.playModeStateChanged -= ChangedPM;
            EditorApplication.playModeStateChanged += ChangedPM;
       if (whitendblack == null)
        {
            whitendblack = new GUIStyle();
            whitendblack.fontSize = 16;
            whitendblack.normal.background = MakeTex(2, 2, Color.white);
            whitendblack.normal.textColor = Color.black;
        }
        showcomponents = GUILayout.Toggle(showcomponents, "Show Components");
        showfields = GUILayout.Toggle(showfields, "Show Fields");
        serializefields = GUILayout.Toggle(serializefields, "Serialize All Fields");
        serializeChildzz = GUILayout.Toggle(serializefields, "Serialize Children");
        GUILayout.Label("Tags to Save", EditorStyles.boldLabel);
        ShowList(ref tagzz911420, ",", ref sotbox);
        GUILayout.Label("Layers to Save", EditorStyles.boldLabel);
        ShowList(ref layerzz911420, ",", ref sotbox22);
        for (int curi8778 = 1; curi8778 < tagzz911420.Count + 1; curi8778++)
        {
            try
            {
                List<GameObject> tagzzobzz6996;
                tagzzobzz6996 = GameObject.FindGameObjectsWithTag(tagzz911420[curi8778 - 1]).ToList<GameObject>();
                for (int curi9449 = 1; curi9449 < tosavegozz.Count + 1; curi9449++)
                {
                    if (!ContainsGMObjects(tosavegozz, tagzzobzz6996[curi9449]))
                    {
                        tosavegozz.Add(new PMGameObject(tagzzobzz6996[curi9449], true));
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        List<GameObject> layerzzobzz6996;
        GUILayout.Label("GameObjects to Save", EditorStyles.boldLabel);
        List<PMGameObject> toremove9969 = new List<PMGameObject>();
        for (int curi = 1; curi < tosavegozz.Count + 1; curi++)
        {
            PMGameObject gmobj;
            gmobj = tosavegozz[curi - 1];
            EditorGUI.indentLevel = 0;
            gmobj.enabled = EditorGUILayout.BeginToggleGroup("Object #" + curi.ToString() + " - " + gmobj.myobject.name, gmobj.enabled);
            foreach (Component gmcomp in gmobj.myobject.GetComponents<Component>())
            {
                if (gmobj.mycomponents.Where(x => x.mycomponent == gmcomp).Count() == 0)
                {
                    PMComponent mycomp9886;
                    mycomp9886 = new PMComponent(gmcomp, true);
                    foreach (FieldInfo fld6991113373371 in gmcomp.GetType().GetFields())
                    {
                        mycomp9886.myproperties.Add(new PMProperty(fld6991113373371.Name, true, PMPropertyTypeTeh.Field));
                    }
                    foreach (PropertyInfo prop3371133791169 in gmcomp.GetType().GetProperties())
                    {
                        if (prop3371133791169.CanRead && prop3371133791169.CanWrite)
                        {
                            mycomp9886.myproperties.Add(new PMProperty(prop3371133791169.Name, true, PMPropertyTypeTeh.Property));
                        }
                    }
                    gmobj.mycomponents.Add(mycomp9886);
                }
            }
            List<PMComponent> toremove6699 = new List<PMComponent>();
            foreach (PMComponent gmcomp22 in gmobj.mycomponents)
            {
                if (gmobj.myobject.GetComponents<Component>().Where(x => x == gmcomp22.mycomponent).Count() == 0)
                {
                    toremove6699.Add(gmcomp22);
                }
            }
            foreach (PMComponent gmremoveem in toremove6699)
            {
                //gmobj.mycomponents.Remove(gmremoveem);
            }
            if (showcomponents)
            {
                for (int curi3 = 1; curi3 < gmobj.mycomponents.Count + 1; curi3++)
                {
                    PMComponent gmcomp;
                    gmcomp = gmobj.mycomponents[curi3 - 1];
                    EditorGUI.indentLevel = 2;
                    gmcomp.enabled = EditorGUILayout.BeginToggleGroup("Component #" + curi3.ToString() + " - " + gmcomp.mycomponent.GetType().FullName, gmcomp.enabled);
                    if (showfields)
                    {
                        for (int curi4 = 1; curi4 < gmcomp.myproperties.Count + 1; curi4++)
                        {
                            PMProperty gmprop;
                            gmprop = gmcomp.myproperties[curi4 - 1];
                            EditorGUI.indentLevel = 4;
                            gmprop.enabled = EditorGUILayout.BeginToggleGroup("Field #" + curi4.ToString() + " - " + gmprop.name, gmprop.enabled);
                            EditorGUILayout.EndToggleGroup();
                        }
                        if (GUILayout.Button("Select All", new GUILayoutOption[] { GUILayout.ExpandWidth(false) }))
                        {
                            for (int curi4 = 1; curi4 < gmcomp.myproperties.Count + 1; curi4++)
                            {
                                PMProperty gmprop;
                                gmprop = gmcomp.myproperties[curi4 - 1];
                                gmprop.enabled = true;
                            }
                        }
                        if (GUILayout.Button("Deselect All", new GUILayoutOption[] { GUILayout.ExpandWidth(false) }))
                        {
                            for (int curi4 = 1; curi4 < gmcomp.myproperties.Count + 1; curi4++)
                            {
                                PMProperty gmprop;
                                gmprop = gmcomp.myproperties[curi4 - 1];
                                gmprop.enabled = false;
                            }
                        }
                    }
                    EditorGUILayout.EndToggleGroup();
                }
            }
            EditorGUILayout.EndToggleGroup();
            if (GUILayout.Button("-", whitendblack, new GUILayoutOption[] { GUILayout.Width(21), GUILayout.Height(21) }))
            {
                toremove9969.Add(gmobj);
            }
            curi += 1;
        }
        foreach (PMGameObject gmgm911911 in toremove9969)
        {
            tosavegozz.Remove(gmgm911911);
        }
        if (GUIExt.DropArea(ref myobjzz, whitendblack, "+", 21, 21, false, false))
        {
            foreach (object myobjtmmt in myobjzz)
            {
                GameObject mb6969;
                mb6969 = (GameObject)myobjtmmt;
                tosavegozz.Add(new PMGameObject(mb6969, true));
            }
        }
    }

    private bool ContainsGMObjects(List<PMGameObject> myobjzz, GameObject gmobjTMMT)
    {
        for (int curi5775 = 1; curi5775 < tosavegozz.Count + 1; curi5775++)
        {
            if (myobjzz[curi5775 - 1].myobject==gmobjTMMT)
            {
                return true;
            }
        }
        return false;
                }

    private void ShowList(ref List<string> dzzlizztt, string sep, ref bool showastext)
    {
        if (!showastext)
        {
            List<string> toremove6956;
            toremove6956 = new List<string>();
            for (int curi94 = 1; curi94 < dzzlizztt.Count + 1; curi94++)
            {
                dzzlizztt[curi94 - 1] = EditorGUILayout.TextArea(dzzlizztt[curi94 - 1]);
                if (GUILayout.Button("-", whitendblack, new GUILayoutOption[] { GUILayout.Width(21), GUILayout.Height(21) }))
                {
                    toremove6956.Add(dzzlizztt[curi94 - 1]);
                }
            }
            foreach (string tgzz119119 in toremove6956)
            {
                dzzlizztt.Remove(tgzz119119);
            }
            if (GUILayout.Button("+", whitendblack, new GUILayoutOption[] { GUILayout.Width(21), GUILayout.Height(21) }))
            {
                dzzlizztt.Add("");
            }
        }
        else
        {
            String tempval6996;
            tempval6996 = EditorGUILayout.TextArea(ArrayToText(dzzlizztt, sep));
            dzzlizztt = TextToArray(tempval6996, sep, true);
        }
        showastext = GUILayout.Toggle(showastext, "Show as Text-Box");
    }

    private List<string> TextToArray(string myvall9696, string sep9191, bool remspacc2121)
    {
        List<string> mylizzt8998;
        mylizzt8998 = new List<string>();
        String mysuur;
        mysuur = "";
        for (int curi818 = 1; curi818 < myvall9696.Length + 1; curi818++)
        {
            if (myvall9696.Substring(curi818 - 1, 1) != sep9191)
            {
                mysuur += myvall9696.Substring(curi818 - 1, 1);
            }
            else
            {
                mylizzt8998.Add(mysuur);
                mysuur = "";
            }
        }
        mylizzt8998.Add(mysuur);
        return mylizzt8998;
      }

    private string ArrayToText(List<string> mylizzt8668, string sep)
    {
        String mystr9119;
        mystr9119 = "";
        for (int curi966 = 1; curi966 < mylizzt8668.Count + 1; curi966++)
        {
            mystr9119 += mylizzt8668[curi966-1] + sep;
        }
        if (mystr9119 != "")
        {
            mystr9119 = mystr9119.Substring(0, mystr9119.Length - 1);
        }
        return mystr9119;
     }

    private void ChangedPM(PlayModeStateChange obj)
    {
       if (!EditorApplication.isPlayingOrWillChangePlaymode)
        {
            if (EditorApplication.isPlaying)
            {
                SaveComponents();
            }
            else
            {
                LoadComponents();
            }
        }
    }

    public bool HazzEvHandlerRC(EventHandler ev01, Delegate ev02)
    {
        if (ev01 != null)
        {
            foreach (Delegate handboi in ev01.GetInvocationList())
            {
                if (handboi == ev02)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void SaveComponents()
    {
        tosavegozz22.Clear();
        for (int curi6 = 1; curi6 < tosavegozz.Count + 1; curi6++)
        {
            PMGameObject rezzgm;
            rezzgm = tosavegozz[curi6 - 1];
            if (rezzgm.enabled)
            {
                for (int curi9 = 1; curi9 < rezzgm.mycomponents.Count + 1; curi9++)
                {
                    PMComponent rezzcump69;
                    rezzcump69 = rezzgm.mycomponents[curi9 - 1];
                    if (rezzcump69.enabled)
                    {
                        PMSerializedComponent rezzcump;
                        rezzcump = new PMSerializedComponent();
                        rezzcump.gmmy65 = rezzgm;
                        rezzcump.compmy56 = rezzcump69;
                        rezzcump.serializedProduct = EditorJsonUtility.ToJson(rezzcump69.mycomponent);
                        tosavegozz22.Add(rezzcump);
                    }
                    }
            }
        }
    }

    public void LoadComponents()
    {
        for (int curi16 = 1; curi16 < tosavegozz22.Count + 1; curi16++)
        {
            PMSerializedComponent rezzsrcp;
            rezzsrcp = tosavegozz22[curi16 - 1];
            Component rezzcpmp;
            PMComponent rezzcp;
            rezzcp = rezzsrcp.compmy56;
            rezzcpmp = rezzsrcp.compmy56.mycomponent;
            if (rezzcp.enabled)
            {
                if (serializefields)
                {
                    Undo.RegisterCompleteObjectUndo(rezzcpmp, "Redo JSON..");
                    EditorJsonUtility.FromJsonOverwrite(rezzsrcp.serializedProduct, rezzcpmp);
                    }
                else
                {
                    object rezzcp22 = new object();
                    EditorJsonUtility.FromJsonOverwrite(rezzsrcp.serializedProduct, rezzcp22);
                    for (int curi64 = 1; curi64 < rezzcp.myproperties.Count + 1; curi16++)
                    {
                        PMProperty rezzproppp;
                        rezzproppp = rezzcp.myproperties[curi64 - 1];
                        if (rezzproppp.enabled)
                        {
                            if (rezzproppp.pmtype == PMPropertyTypeTeh.Field)
                            {
                                rezzcp22.GetType().GetField(rezzproppp.name).SetValue(rezzcpmp, rezzcp22.GetType().GetField(rezzproppp.name).GetValue(rezzcp22));
                            }
                        }
                    }
                }
            }
        }
    }
}