using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public AudioSource source;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public void hoveredSound()
    {
        source.PlayOneShot(hoverSound);
    }

    public void clickedSound()
    {
        source.PlayOneShot(clickSound);
    }
}
