using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public struct PlayerData
    {
        public string PlayerName;
        public int PlayerHealth;
        public bool PlayerDead;
        public SVect3 PlayerPosition;
    }

    public sealed class Player : Unit
    {
        PlayerData SinglePlayerData = new PlayerData();
        private ISaveData<PlayerData> _saveData;

        public float Speed
        {
            get { return _speed; }
            set
            {
                if (value < 1f)
                    _speed = 1f;
                else if (value > 10f)
                    _speed = 10f;
                else _speed = value;
            }
        }

        protected override void Awake()
        {
            base.Awake();

            _isDead = false;
            _health = 100;

            SinglePlayerData.PlayerHealth = _health;
            SinglePlayerData.PlayerDead = _isDead;
            SinglePlayerData.PlayerName = gameObject.name;
            SinglePlayerData.PlayerPosition = _transform.position;

            _saveData = new StreamPlayerData();
        }

        public override void Move(float x, float y, float z)
        {
            if (_rb)
            {
                _rb.AddForce(new Vector3(x, y, z) * _speed);
            }
            else
            {
                Debug.Log("No Rigidbody");
            }
        }

        public void SavePlayer()
        {
            _saveData.SaveData(UpdateData());
            PlayerData playerData = _saveData.Load();

            Debug.Log(playerData.PlayerName);
            Debug.Log(playerData.PlayerHealth);
            Debug.Log(playerData.PlayerPosition.X + " " + playerData.PlayerPosition.Y + " " + playerData.PlayerPosition.Z);
        }

        private PlayerData UpdateData()
        {
            SinglePlayerData.PlayerPosition = _transform.position;
            SinglePlayerData.PlayerHealth = _health;
            SinglePlayerData.PlayerDead = _isDead;
            return SinglePlayerData;
        }
    }
}