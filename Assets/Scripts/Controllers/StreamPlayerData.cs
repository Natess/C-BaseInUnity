using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Maze
{
    public class StreamPlayerData : ISaveData<PlayerData>
    {
        string SavePath = Path.Combine(Application.dataPath, "StreamData.txt");

        public void SaveData(PlayerData playerData, string path = null)
        {
            using(StreamWriter sw = new StreamWriter(SavePath))
            {
                sw.WriteLine(playerData.PlayerName);
                sw.WriteLine(playerData.PlayerHealth);
                sw.WriteLine(playerData.PlayerDead);
                sw.WriteLine(playerData.PlayerPosition);
            }
        }

        public PlayerData Load(string path = null)
        {
            PlayerData result = new PlayerData();
            if (!File.Exists(SavePath))
            {
                Debug.Log("File not exist!");
                return result;
            }

            using(StreamReader sr = new StreamReader(SavePath))
            {
                result.PlayerName = sr.ReadLine();
                result.PlayerHealth = Convert.ToInt32(sr.ReadLine());
                result.PlayerDead = Convert.ToBoolean(sr.ReadLine());
                result.PlayerPosition = (SVect3)sr.ReadLine();
            }
            return result;
        }
    }
}