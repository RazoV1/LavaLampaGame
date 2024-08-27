using UnityEngine;

namespace Assets.Scripts
{
    public class SoundsBaseCollection : MonoBehaviour
    {

        [Header("Player")]
        public AudioSource jumpSound;
        public AudioSource[] runSound;
    
        [Header("UI")]
        public AudioSource correctAnswer;
    
        [Header("Cockroaches")]
        public AudioSource cockroachRun;
        public AudioSource cockroachDie;
    
        [Header("Elder")]
        public AudioSource awakeElder;

        [Header("Gay Death")]
        public AudioSource revive;

        [Header("Music))))")]
        public AudioSource fightMusic;


        public static SoundsBaseCollection Instance { get; private set; }

        private void Awake()
        {

            if (Instance == null)
            {
                Instance = this;
            }
        }
    
    }
}
