using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100; //okretanje novèiæa u mjestu
    private AudioSource source;
    public AudioClip clip;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) //skupljanje novèiæa
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
        PlayerManager.numberOfCoins++;
        Destroy(gameObject);
    }
}
