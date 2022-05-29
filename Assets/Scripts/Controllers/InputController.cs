using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class InputController : IExecute
    {
        private readonly Unit _player;
        private float horizontal;
        private float vertical;

        public InputController(Unit player)
        {
            _player = player;
        }
        
        public void Update()
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = -Input.GetAxis("Horizontal");

            _player.Move(vertical, 0f, horizontal);
        }
    }
}