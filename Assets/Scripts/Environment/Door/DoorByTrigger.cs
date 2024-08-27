using UnityEngine;

namespace Assets.Scripts.Environment.Door
{
    public class DoorByTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject desintegrate;

        public void Open()
        {
            Instantiate(desintegrate,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
