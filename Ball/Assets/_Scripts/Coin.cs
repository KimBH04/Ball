using UnityEngine;

public class Coin : MonoBehaviour
{
    public static AudioSource ballAudio;

    [SerializeField] private long ownScore;
    [SerializeField] private AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.GetScore(ownScore);

            ballAudio.PlayOneShot(clip);
            Destroy(gameObject);
        }
    }
}
