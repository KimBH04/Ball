using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Coin : MonoBehaviour
{
    public static AudioSource ballAudio;

    [SerializeField] private AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ballAudio.PlayOneShot(clip);
            Destroy(gameObject);
        }
    }
}
