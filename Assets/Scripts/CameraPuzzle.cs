using UnityEngine;

namespace Assets.Scripts
{
    public class CameraPuzzle : MonoBehaviour
    {

        [SerializeField] private Transform cameraPoint;
        [SerializeField] private float camSize;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.Instance.playerCamera.Follow = cameraPoint;
                GameManager.Instance.playerCamera.m_Lens.OrthographicSize = camSize;
            }
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.Instance.playerCamera.Follow = other.transform;
                GameManager.Instance.playerCamera.m_Lens.OrthographicSize = GameManager.Instance.camSize;
            }
        }
    }
}
