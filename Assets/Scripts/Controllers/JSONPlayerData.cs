using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace Maze
{
    internal class JSONPlayerData : ISaveData<PlayerData>
    {
        string SavePath = Path.Combine(Application.dataPath, "JSONData.json");

        public void SaveData(PlayerData playerData, string savePath = null)
        {
            var fileJson = JsonUtility.ToJson(playerData);
            File.WriteAllText(SavePath, fileJson);
        }

        public PlayerData Load(string savePath = null)
        {
            PlayerData result = new PlayerData();
            if (!File.Exists(SavePath))
            {
                Debug.Log("File not exist!");
                return result;
            }

            var tempJson = File.ReadAllText(SavePath);
            result = JsonUtility.FromJson<PlayerData>(tempJson);
            return result;
        }
    }
}
