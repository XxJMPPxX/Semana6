using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacionAudio : MonoBehaviour
{
    public AudioManager audioManager;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Entrar"))
        {
            audioManager.SFXSource.clip = audioManager.Entrar;
            audioManager.SFXSource.Play();
        }
        else if (collision.gameObject.CompareTag("Salir"))
        {
            audioManager.SFXSource.clip = audioManager.Salir;
            audioManager.SFXSource.Play();
        }

        if (collision.gameObject.CompareTag("Cuarto1"))
        {
            audioManager.MusicSource.clip = audioManager.Cuarto1;
            audioManager.MusicSource.loop = true;
            audioManager.MusicSource.Play();
        }
        else if (collision.gameObject.CompareTag("Cuarto2"))
        {
            audioManager.MusicSource.clip = audioManager.Cuarto2;
            audioManager.MusicSource.loop = true; 
            audioManager.MusicSource.Play();
        }
        else if (collision.gameObject.CompareTag("Cuarto3"))
        {
            audioManager.MusicSource.clip = audioManager.Cuarto3;
            audioManager.MusicSource.loop = true; 
            audioManager.MusicSource.Play();
        }
        else if (collision.gameObject.CompareTag("Cuarto4"))
        {
            audioManager.MusicSource.clip = audioManager.Cuarto4;
            audioManager.MusicSource.loop = true; 
            audioManager.MusicSource.Play();
        }
        else
        {
            audioManager.MusicSource.Stop();
        }
    }
}