using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Maze
{
    internal class JSONData<T> : ISaveData<T>
        where T : new()
    {
        //public string SavePath { get; set; }

        //public JSONData(string fileName)
        //{
        //    SavePath = Path.Combine(Application.dataPath, fileName);
        //}

        public T Load(string savePath)
        {
            var result = new T();
            if (savePath == null)
            {
                Debug.Log("File name is null");
                return result;
            }
            if (!File.Exists(savePath))
            {
                Debug.Log("File with bonuses not exist!");
                return result;
            }

            var tempJson = File.ReadAllText(savePath);
            result = JsonConvert.DeserializeObject<T>(tempJson);

            return result;
        }

        public void SaveData(T bonuses, string savePath)
        {
            if (savePath == null)
            {
                Debug.Log("File name is null");
                return;
            }
            var fileJson = JsonConvert.SerializeObject(bonuses);
            File.WriteAllText(savePath, fileJson);
        }
    }
}
