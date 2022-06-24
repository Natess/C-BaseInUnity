using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

#if UNITY_EDITOR
public class Waypoints : MonoBehaviour
{
    public List<Transform> Nodes = new List<Transform>();

    public string DirectoryName;
    public string SavingPath { get; set; }
    public string SceneName;

    private void Awake()
    {
        SceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        DirectoryName = "BonusData";
        SavingPath = Path.Combine((Application.dataPath + "/" + DirectoryName), "BonusMap" + SceneName + ".xml");
    }

    private void OnDrawGizmos()
    {
        SceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        DirectoryName = "BonusData";
        SavingPath = Path.Combine((Application.dataPath + "/" + DirectoryName), "BonusMap" + SceneName + ".xml");
    }
}
#endif