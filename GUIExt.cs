using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class GUIExt
{
    public static bool DropArea(ref List<object> listtoadd, GUIStyle boxzzstyly, string textmy, float sizex, float sizey, bool expanddzx, bool expanddzy)
    {
        Event evt = Event.current;
        Rect droparea = GUILayoutUtility.GetRect(sizex, sizey, new GUILayoutOption[] { GUILayout.ExpandWidth(expanddzx), GUILayout.ExpandHeight(expanddzy) });
            GUI.Box(droparea, textmy,boxzzstyly);

            switch (evt.type)
            {
                case EventType.DragUpdated:
                case EventType.DragPerform:
                if (droparea.Contains(evt.mousePosition))
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                    if (evt.type == EventType.DragPerform)
                    {
                        DragAndDrop.AcceptDrag();

                       listtoadd= new List<object>(DragAndDrop.objectReferences);
                        return true;
                    }
                }
                break;
            }

        return false;
        }
    }