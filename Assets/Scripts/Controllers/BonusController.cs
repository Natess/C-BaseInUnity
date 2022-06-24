using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Maze
{
    internal class BonusController : IExecute
    {
        private PlayerController _playerController;
        private UIController _uiController;

        private List<BadBonusGameOver> _badBonusesGameOver = new List<BadBonusGameOver>();
        private List<GoodBonusSpeed> _goodBonusesSpeed = new List<GoodBonusSpeed>();
        private List<BadBonusSpeed> _badBonusesSpeed = new List<BadBonusSpeed>();
        private List<GoodBonusAddPoints> _goodBonusesAddPoint = new List<GoodBonusAddPoints>();

        //List<BonusData> BonusData = new List<BonusData>();
        private ISaveData<List<BonusData>> _saveData;

        public BonusController(PlayerController playerController, UIController uiController)
        {
            _playerController = playerController;
            _uiController = uiController;

            _saveData = new JSONData<List<BonusData>>();
        }

        internal void AddBonus(Bonus bonus)
        {
            if (bonus == null)
                return;
            if(bonus is BadBonusGameOver goBonus)
            {
                goBonus.OnCaughtPlayer += GameOver;
                _badBonusesGameOver.Add(goBonus);
            }
            if(bonus is BadBonusSpeed bbBonus)
            {
                bbBonus.OnCaughtPlayer += SetPlayerSpeed;
                _badBonusesSpeed.Add(bbBonus);
            }
            if(bonus is GoodBonusAddPoints apBonus)
            {
                apBonus.OnCaughtPlayer += AddPointsToPlayer;
                _goodBonusesAddPoint.Add(apBonus);
            }
            if(bonus is GoodBonusSpeed gsBonus)
            {
                gsBonus.OnCaughtPlayer += SetPlayerSpeed;
                _goodBonusesSpeed.Add(gsBonus);
            }
        }

        private void SetPlayerSpeed(float speedModifier)
        {
            Debug.Log($"SetPlayerSpeed:{speedModifier}");
            _playerController.SetSpeed(speedModifier);
        }

        private void GameOver(string name, Color color)
        {
            _uiController.ViewEndGame.GameOver(name, color);
            _uiController.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        private void AddPointsToPlayer(int points)
        {
            Debug.Log($"AddPointsToPlayer:{points}");
            _playerController.AddPoints(points);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                SaveBonuses();
            }
        }

        public void SaveBonuses()
        {
            var goodBonusData = new List<BonusData>();
            goodBonusData.AddRange(_goodBonusesAddPoint.Select(x => new BonusData() { BonusPosition = x.Position, BonusType = x.BonusType, IsInteractable = x.IsInteractable }));
            goodBonusData.AddRange(_goodBonusesSpeed.Select(x => new BonusData() { BonusPosition = x.Position, BonusType = x.BonusType, IsInteractable = x.IsInteractable }));

            _saveData.SaveData(goodBonusData, Path.Combine(Application.dataPath, "JSONGoodBonusesData.json"));
            var goodBonuses = _saveData.Load(Path.Combine(Application.dataPath, "JSONGoodBonusesData.json"));
            Debug.Log(goodBonuses.Count);
            Debug.Log(goodBonuses[0].BonusType.ToString() + " " + goodBonuses[0].IsInteractable + " " + goodBonuses[0].BonusPosition);


            var badBonusData = new List<BonusData>();
            badBonusData.AddRange(_badBonusesGameOver.Select(x => new BonusData() { BonusPosition = x.Position, BonusType = x.BonusType, IsInteractable = x.IsInteractable }));
            badBonusData.AddRange(_badBonusesSpeed.Select(x => new BonusData() { BonusPosition = x.Position, BonusType = x.BonusType, IsInteractable = x.IsInteractable }));

            _saveData.SaveData(badBonusData, Path.Combine(Application.dataPath, "JSONBadBonusesData.json"));
            var badBobuses = _saveData.Load(Path.Combine(Application.dataPath, "JSONBadBonusesData.json"));
            Debug.Log(badBobuses.Count);
            Debug.Log(badBobuses[0].BonusType.ToString() + " " + badBobuses[0].IsInteractable + " " + badBobuses[0].BonusPosition);
        }
    }
}
