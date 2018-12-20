using UnityEngine;
using System.Collections;

public class GlitchHandler : MonoBehaviour
{

    private Kino.AnalogGlitch analogGlitch;
    private Kino.DigitalGlitch digitalGlitch;
    private float dgi_first = 0.006f;
    private float slj_first = 0.11f;
    private float vj_first = 0.01f;
    private float hs_first = 0;
    private float cd_first = 0;
    private float dgi_worrying = 0.1f;
    private float slj_worrying = 0.5f;
    private float vj_worrying = 0.02f;
    private float hs_worrying = 0.001f;
    private float cd_worrying = 0.1f;
    private float dgi_critical = 0.1f;
    private float slj_critical = 0.5f;
    private float vj_critical = 0.05f;
    private float hs_critical = 0.001f;
    private float cd_critical = 0.05f;
    


    void Start()
    {
        analogGlitch = GetComponent<Kino.AnalogGlitch>();
        digitalGlitch = GetComponent<Kino.DigitalGlitch>();

    }


    public void regularScreen()
    {
        analogGlitch.enabled = false;
        digitalGlitch.enabled = false;
    }

    public void firstSymptomsScreen()
    {
        analogGlitch.enabled = true;
        digitalGlitch.enabled = true;
        analogGlitch.colorDrift = cd_first;
        analogGlitch.scanLineJitter = slj_first;
        analogGlitch.verticalJump = vj_first;
        analogGlitch.horizontalShake = hs_first;
        digitalGlitch.intensity = dgi_first;
    }

    public void worryingStateScreen()
    {
        analogGlitch.enabled = true;
        digitalGlitch.enabled = true;
        analogGlitch.colorDrift = cd_worrying;
        analogGlitch.scanLineJitter = slj_worrying;
        analogGlitch.verticalJump = vj_worrying;
        analogGlitch.horizontalShake = hs_worrying;
        digitalGlitch.intensity = dgi_worrying;
    }

    public void criticalStateScreen()
    {
        analogGlitch.enabled = true;
        digitalGlitch.enabled = true;
        analogGlitch.colorDrift = cd_critical;
        analogGlitch.scanLineJitter = slj_critical;
        analogGlitch.verticalJump = vj_critical;
        analogGlitch.horizontalShake = hs_critical;
        digitalGlitch.intensity = dgi_critical;
    }
}