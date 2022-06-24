using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Maze
{
    internal class PlayerController : IExecute
    {
        private int _points;

        private Player _player;
        private UIController _uiController;
        private int _winCondition;

        public PlayerController(Player player, UIController uiController)
        {
            _player = player;
            _uiController = uiController;

            _points = 0;
            _winCondition = 10;
        }

        internal void AddPoints(int points)
        {
            _points += points;
            _uiController.BonusDisplay(_points);

            if (_points == _winCondition)
            {
                _uiController.RestartButton.gameObject.SetActive(true);
                Time.timeScale = 0f;
                _uiController.WinGame();
            } 
        }

        internal int GetPoints() => _points;

        internal void SetSpeed(float speedModifier) => _player.Speed *= speedModifier;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _player.SavePlayer();
            }
        }
    }
}
