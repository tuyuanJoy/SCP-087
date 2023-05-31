using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

public class GlitchWhenNear : MonoBehaviour
{
    public AnalogGlitch analogGlitch;
    private void OnTriggerStay(Collider other)
    {
        Vector3 distanceFromPlayer = other.transform.position - transform.position;
        analogGlitch.colorDrift = 1 - (distanceFromPlayer.magnitude/12f);
        analogGlitch.scanLineJitter = 1 - (distanceFromPlayer.magnitude/12f);
    }
    private void OnTriggerExit(Collider other)
    {
        analogGlitch.colorDrift = 0;
        analogGlitch.scanLineJitter = 0;

    }


}
