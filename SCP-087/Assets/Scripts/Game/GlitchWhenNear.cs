using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

public class GlitchWhenNear : MonoBehaviour
{
    public AnalogGlitch analogGlitch;
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay in Sphere");
        Vector3 distanceFromPlayer = other.transform.position - transform.position;
        Debug.Log("Normalized Distance" + distanceFromPlayer.magnitude);
        analogGlitch.colorDrift = 1 - (distanceFromPlayer.magnitude/12f);
        analogGlitch.scanLineJitter = 1 - (distanceFromPlayer.magnitude/12f);
    }
    private void OnTriggerExit(Collider other)
    {
        analogGlitch.colorDrift = 0;
        analogGlitch.scanLineJitter = 0;

    }


}
