using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_footsteps : MonoBehaviour
{
    public S_playerMovement movement;
    public AudioSource audioSource;

    public float stepInterval = 0.25f;
    public float crouchStepInterval = 0.25f;

    [Header("Volumes for each step")]
    public float minVol = 0.5f;
    public float maxVol = 0.8f;

    [Header("Pitch for changing in each step")]
    public float minPitch = 0.5f;
    public float maxPitch = 0.8f;

    private void Start()
    {
        StartCoroutine("Step");
    }

    IEnumerator Step()
    {
        while (true)
        {
            yield return new WaitForSeconds(stepInterval);

            if (movement._moving && !audioSource.isPlaying)
            {
                if (movement.isCrouching)
                {
                    audioSource.pitch = Random.Range(minPitch/2, maxPitch/2); 
                    audioSource.volume = Random.Range(minVol/2, maxVol/2); 
                }
                else
                {
                    audioSource.pitch = Random.Range(minPitch, maxPitch); ;
                    audioSource.volume = Random.Range(minVol, maxVol);
                }
                this.audioSource.Play();
            }
        }
    }
}
