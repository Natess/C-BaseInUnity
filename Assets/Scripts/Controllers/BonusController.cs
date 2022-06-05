using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Maze
{
    internal class BonusController
    {
        private PlayerController _playerController;
        private UIController _uiController;

        private List<BadBonusGameOver> _badBonusesGameOver = new List<BadBonusGameOver>();
        private List<GoodBonusSpeed> _goodBonusesSpeed = new List<GoodBonusSpeed>();
        private List<BadBonusSpeed> _badBonusesSpeed = new List<BadBonusSpeed>();
        private List<GoodBonusAddPoints> _goodBonusesAddPoint = new List<GoodBonusAddPoints>();

        public BonusController(PlayerController playerController, UIController uiController)
        {
            _playerController = playerController;
            _uiController = uiController;
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
    }
}
