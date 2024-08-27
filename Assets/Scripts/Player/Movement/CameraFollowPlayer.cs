using UnityEngine;

namespace Assets.Scripts.Player.Movement
{
    public class CameraFollowPlayer : MonoBehaviour
    {
        public Transform target;
        public float speed;

        private void FixedUpdate()
        {
            Vector3 targetPos = new Vector3(target.position.x,target.position.y,-10);
            transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
        }
    }
}
