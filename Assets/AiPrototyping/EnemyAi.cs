using UnityEngine;

namespace Frap
{
    public class EnemyAi : MonoBehaviour
    {
        private static readonly int _maxAngle = 30;

        [SerializeField]
        private Transform _head;

        [SerializeField]
        private Transform _player;

        public void Update()
        {
            if (_player == null) 
                return;

            Ray ray = new(_head.position, _player.position - _head.position);

            Ray forwardRay = new(_head.position, _head.forward);

            //Debug.Log(Vector3.Angle(ray.direction, forwardRay.direction));
            float angle = Vector3.Angle(ray.direction, forwardRay.direction);
            Color color = angle < _maxAngle ? Color.green : Color.red;

            Debug.DrawRay(ray.origin, ray.direction * 100f, color);
            //Debug.DrawRay(forwardRay.origin, forwardRay.direction * 100f, Color.blue);
        }
    }
}