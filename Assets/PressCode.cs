using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressCode : MonoBehaviour {

    public AudioSource source;
    public AudioClip bipButton;
    public CodeClass m_class;
    private List<int> t_list;
    private string value;
    private int number;
    private Color white, grey;
    private Renderer render;

    void Start()
    {
        white = Color.white;
        grey = new Color(0.5882353f, 0.5882353f, 0.5882353f, 1);
        render = GetComponent<Renderer>();
        source.playOnAwake = false;
    }

    void OnMouseDown()
    {
        render.material.color = white;
        value = gameObject.name;
        Debug.Log(value);
        if (value == "#" || value == "*")
        {
            m_class.Entry.Clear();
            value = "";
        }
        else
        {
            number = int.Parse(value);
            m_class.Entry.Add(number);
        }
        source.PlayOneShot(bipButton);
    }

    void OnMouseUp()
    {
        render.material.color = grey;
    }
}
