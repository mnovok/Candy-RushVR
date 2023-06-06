using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject flag;
    public GameObject winPanel;

     public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            Time.timeScale = 0f;
            Destroy(flag);
            winPanel.SetActive(true);
        }
    }
}
