using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsEnemy : MonoBehaviour
{
    public AudioSource audioSource;
    public Enemy _enemy;

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

            if (!_enemy._agent.isStopped && !audioSource.isPlaying)
            {
                audioSource.pitch = Random.Range(minPitch, maxPitch / 2);
                audioSource.volume = Random.Range(minVol, maxVol / 2);
                
                this.audioSource.Play();
            }
        }
    }
}
