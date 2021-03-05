using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class VoiceTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClip;
    private AudioSource audioSource;
    private bool triggered= false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Player")&& !triggered)
        {
            triggered = true;
            audioSource.clip = audioClip[Random.Range(0, audioClip.Length)];
            audioSource.Play();
        }
    }
}
