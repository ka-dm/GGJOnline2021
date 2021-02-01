using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer1 : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void ReproducirSonidoPasos()
    {
        audioSource.Play();
    }
}
