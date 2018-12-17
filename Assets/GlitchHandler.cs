using UnityEngine;
using System.Collections;

public class GlitchHandler : MonoBehaviour
{

    private Kino.AnalogGlitch analogGlitch;
    private Kino.DigitalGlitch digitalGlitch;
    public float dgi_first;
    public float slj_first;
    public float vj_first;
    public float hs_first;
    public float cd_first;
    public float dgi_worrying;
    public float slj_worrying;
    public float vj_worrying;
    public float hs_worrying;
    public float cd_worrying;
    public float dgi_critical;
    public float slj_critical;
    public float vj_critical;
    public float hs_critical;
    public float cd_critical;
    


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