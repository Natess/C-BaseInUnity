using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public interface ISaveData<T>
        where T : new() 
    { 
        void SaveData(T data, string savePath = null);

        T Load(string savePath = null);

    }
}