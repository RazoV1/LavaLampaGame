using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts.Player.lightUp
{
    public class AddRadius : MonoBehaviour
    {
        public Light2D playerLight;
        public float radius;

        public void UpdateRadius()
        {
            playerLight.shapeLightFalloffSize = radius;
        }
    }
}
