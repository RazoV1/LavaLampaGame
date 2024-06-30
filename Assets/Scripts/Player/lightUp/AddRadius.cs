using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AddRadius : MonoBehaviour
{
    public Light2D playerLight;
    public float radius;

    public void UpdateRadius()
    {
        playerLight.shapeLightFalloffSize = radius;
    }
}
