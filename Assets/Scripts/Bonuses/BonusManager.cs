using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Maze
{

    internal class BonusManager
    {
        private Player _player;
        private MainCamera _camera;

        private BadBonusGameOver[] _badBonusesGameOver;
        private GoodBonusSpeed[] _goodBonusesSpeed;
        private BadBonusSpeed[] _badBonusesSpeed;
        private GoodBonusAddPoints[] _goodBonusesAddPoint;

        public BonusManager(Player player, MainCamera camera)
        {
            _player = player;
            _camera = camera;
        }

        internal void InitiateBadBonusesGameOver(BadBonusGameOver[] badBonusesGameOver)
        {
            _badBonusesGameOver = badBonusesGameOver;
            badBonusesGameOver.ToList().ForEach(
                b =>
                {
                    b.OnCaughtPlayer += delegate (string name, Color color) { Debug.Log(name + $"color:{color}"); };
                    b.OnCaughtPlayer += _camera.GameOverHandler;
                }
                );
        }

        internal void InitiateGoodBonusesSpeed(GoodBonusSpeed[] goodBonusesSpeed)
        {
            _goodBonusesSpeed = goodBonusesSpeed;
            goodBonusesSpeed.ToList().ForEach(b => b.OnCaughtPlayer += SetPlayerSpeed);
        }

        internal void InitiateGoodBonusesAddPoints(GoodBonusAddPoints[] goodBonusesAddPoint)
        {
            _goodBonusesAddPoint = goodBonusesAddPoint;
            goodBonusesAddPoint.ToList().ForEach(b => b.OnCaughtPlayer += AddPointsToPlayer);
        }

        internal void InitiateBadBonusesSpeed(BadBonusSpeed[] badBonusesSpeed)
        {
            _badBonusesSpeed = badBonusesSpeed;
            badBonusesSpeed.ToList().ForEach(b => b.OnCaughtPlayer += SetPlayerSpeed);
        }

        private void SetPlayerSpeed(float speedModifier)
        {
            Debug.Log($"SetPlayerSpeed:{speedModifier}");
            _player.SetSpeed(speedModifier);
        }

        //private void GameOver(string name, Color color)
        //{
        //    Debug.Log(name + $"color:{color}");
        //}

        private void AddPointsToPlayer(int points)
        {
            Debug.Log($"AddPointsToPlayer:{points}");
            _player.AddPoints(points);
        }
    }
}
