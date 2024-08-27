using Assets.Scripts.Player.Combat;
using Cinemachine;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }


        public GameObject PauseWindow;
    
        public CinemachineVirtualCamera playerCamera;
        public float camSize;

        public BulletProvider BulletProvider;

        public GameObject player;

        public int[] bugNumbers;
        public string[] bugStrings;
    
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogError("More than one GameManager by name: " + gameObject.name);
                Destroy(gameObject);
            }
        }
    }
}
