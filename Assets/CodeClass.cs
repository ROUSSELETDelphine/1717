using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeClass : MonoBehaviour
{
    public float amountEuphoria;
    public AudioSource source;
    public AudioClip bipError, bipUnlocked;
    public List<int> Entry = new List<int>();
    public bool isValid = false;
    public GameObject led, bookshelf;
    public MentalHealthManager health;
    private Renderer ledRenderer;
    private List<int> code = new List<int>() { 1,9,1,0 };
    private bool ver = false;
    private bool error = false;
    private string enterredCode;
    private Color darkRed, brightRed, green;
    private int wait = 0;
    private static int waitingTime = 30;
    private static float speed = 0.05f;
    private int ctr = 0;
    private int iterMax = 40;

    private void Start()
    {
        ledRenderer = led.GetComponent<Renderer>();
        darkRed = new Color(0.3803922f, 0, 0, 1);
        brightRed = new Color(1, 0, 0, 1);
        green = new Color(0.04267097f, 1, 0, 1);
        source.playOnAwake = false;
    }

    private void Update()
    {
       if(!isValid && verif(Entry))
        {
            isValid = true;
            health.changeMentalState(amountEuphoria);
            //player.SendMessageUpwards("changeMentalState", amountEuphoria, SendMessageOptions.DontRequireReceiver);
        } 

       if (!isValid && error && (wait != waitingTime))
        {
            wait++;
        }

       if (wait == waitingTime)
        {
            ledRenderer.material.color = darkRed;
            error = false;
            wait = 0;
        }

       if (isValid && ctr != iterMax)
        {
            ctr++;
            //Debug.Log(ctr);
            bookshelf.transform.Translate(0, 0, speed);
        }

    }

    private bool verif(List<int> entry)
    {
       
        if(entry.Count==4 && entry[0]==code[0] && entry[1] == code[1] && entry[2] == code[2] && entry[3] == code[3])
        {
            ledRenderer.material.color = green;
            ver = true;
            source.PlayOneShot(bipUnlocked);
        }

        if(entry.Count == 4 && (entry[0] != code[0] || entry[1] != code[1] || entry[2] != code[2] || entry[3] != code[3]))
        {
            ledRenderer.material.color = brightRed;
            error = true;
            Entry.Clear();
            source.PlayOneShot(bipError);
        }
        return ver;
    }

}
