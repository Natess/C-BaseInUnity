using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class CameraController : IExecute
    {
        private readonly Unit _player;
        private readonly MainCamera _camera;

        public CameraController(MainCamera camera, Unit player)
        {
            _player = player;
            _camera = camera;
        }

        public void Update()
        {
            _camera.Move(_player.transform);
            //_camera.transform.position = _player.transform.position + new Vector3(-3, 3, 0) + _player.transform.forward * 0.15f;
            //_camera.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
    }
}