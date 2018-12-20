using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Audio_Pointer : MonoBehaviour, IPointerEnterHandler
{

    public AudioSource source;

    public void OnPointerEnter(PointerEventData eventData)
    {
        source.PlayOneShot(source.clip);
    }

}