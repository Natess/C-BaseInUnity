using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Maze
{
    internal class UIController
    {
        private Reference _reference;
        
        public ViewBonus ViewBonus { get; }
        public ViewEndGame ViewEndGame { get;}
        public Button RestartButton { get; }

        public UIController(Button restartButton)
        {
            _reference = new Reference();

            ViewBonus = new ViewBonus(_reference.BonusLabel);
            ViewEndGame = new ViewEndGame(_reference.EndGameLabel);
            RestartButton = restartButton;

            RestartButton.gameObject.SetActive(false);
            RestartButton.onClick.AddListener(RestartGame);
        }

        internal void WinGame()
        {
            ViewEndGame.WinGame();
        }

        internal void BonusDisplay(int points)
        {
            ViewBonus.Display(points);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
            RestartButton.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
