using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;

namespace Maze
{
    internal class GenerateBonusWindow : EditorWindow
    {
        [MenuItem("Инструменты/Окна/Генератор бонусов")]
        public static void ShowWindow()
        {
            GetWindow(typeof(GenerateBonusWindow), false, "Генератор бонусов");
        }

        private int typeSelectedIdx = 0;

        private string posX = "0";
        private string posY = "0";
        private string posZ = "0";

        void OnGUI()
        {
            var screenRect = new Rect(10, 10, 200, 20);
            Rect labelPosition = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);
            GUI.Label(labelPosition, "Позиция");   // создаём Label на экране

            var posRect = new Rect(25, 30, 50, 20);
            GUI.Label(posRect, "X");
            posRect.y += 25;
            GUI.Label(posRect, "Y");
            posRect.y += 25;
            GUI.Label(posRect, "Z");

            posRect = new Rect(45, 30, 50, 20);
            posX = GUI.TextField(posRect, posX);
            posRect.y += 25;
            posY = GUI.TextField(posRect, posY);
            posRect.y += 25;
            posZ = GUI.TextField(posRect, posZ);
            posRect.y += 25; 

            var bonusTypes = new string[] {
                "GoodBonusAddPoints",
                "GoodBonusSpeed",
                "BadBonusSpeed",
                "BadBonusGameOver",
            };
            posRect = new Rect(10, posRect.y + 10, 300, 40);
            GUI.Label(posRect, "Тип"); 
            posRect = new Rect(10, posRect.y + 30, 300, 40);
            GUILayout.BeginArea(posRect); 
            typeSelectedIdx = EditorGUILayout.Popup(typeSelectedIdx, bonusTypes);
            GUILayout.EndArea();

            if (GUI.Button(new Rect(10, 180, 100, 30), "Создать"))
            {
                GameObject bonusPrefab = Resources.Load<GameObject>($"{bonusTypes[typeSelectedIdx]} Variant");
                if (float.TryParse(posX.Replace('.', ','), out float X) && float.TryParse(posY.Replace('.', ','), out float Y) && float.TryParse(posZ.Replace('.', ','), out float Z))
                {
                    GameObject bonus = Instantiate(bonusPrefab, new Vector3(X, Y, Z), new Quaternion(0,0,0,0));
                }
               
            }
        }
    }
}
