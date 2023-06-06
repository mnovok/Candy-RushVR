using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudio : MonoBehaviour
{
    public AudioSource source;

    public void MuteToggle()
    {
        if (source.volume != 0)
        {
            source.volume = 0;
        }

        else
        {
           source.volume = 0.052f;
        }
    }
}
