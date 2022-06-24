using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

namespace Maze
{
    [CustomEditor(typeof(Waypoints))]
    public class SaveWaypoint : Editor
    {
        static XmlSerializer serializer;
        public List<SVect3> SavingNodes = new List<SVect3>();

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            Waypoints Base = (Waypoints)target;

            if (serializer == null)
            {
                serializer = new XmlSerializer(typeof(SVect3[]));
            }

            if (GUILayout.Button("Сохранить"))
            {
                if (Base.Nodes.Count > 0)
                {
                    foreach (var item in Base.Nodes)
                    {
                        if (!SavingNodes.Contains(item.position))
                        {
                            SavingNodes.Add(item.position);
                        }

                    }
                }
                if (!string.IsNullOrEmpty(Base.SavingPath))
                {
                    using (FileStream fs = new FileStream(Base.SavingPath, FileMode.Create))
                    {
                        serializer.Serialize(fs, SavingNodes.ToArray());
                    } 
                }
                else
                {
                    Debug.Log(Base.SavingPath);
                    Debug.Log(Base.Nodes.Count);
                }
            }
        }
    }
}