using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : MonoBehaviour
{
    S_soundEmitter _se;
    AudioSource _as;
    Enemy enemy;
    Animator anim;

    public float cooldown = 5f;
    public bool isTriggered = false;

    private float _elapsed = 0;
    private bool _waitingEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        _se = GetComponent<S_soundEmitter>();
        _as = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();

        if (isTriggered)
        {
            enemy.StopMooving();
            anim.SetBool("isWaiting", false);
        }
        else
        {
            StartCoroutine("Screaming");
        }
    }

    // Update is called once per frame
    IEnumerator Screaming()
    {
        while (!_waitingEnd)
        {
            yield return new WaitForSeconds(1f);

            _elapsed++;
            int probs = Random.Range(1, 10);
            if (probs == 1 && _elapsed > cooldown)
            {
                _se.stop = true;
                yield return new WaitForSeconds(1.5f);
                LauchScream();
            }
        }
    }

    IEnumerator JustScream()
    {
        yield return new WaitForSeconds(2.5f);
        _se.EmitDoubleRing();
        yield return new WaitForSeconds(0.1f);
        _as.Play();
        _se.EmitDoubleRing();
        yield return new WaitForSeconds(0.1f);
        _se.EmitDoubleRing();
    }

    void LauchScream()
    {
        enemy.StopMooving();

        _waitingEnd = true;
        _elapsed = 0;

        anim.SetTrigger("scream");

        StartCoroutine("JustScream");

    }

    public void StopScreaming()
    {
        _se.stop = false;
        _waitingEnd = false;

        enemy.ResumeMovement();
        StartCoroutine("Screaming");
    }

    public void TriggerScream()
    {
        anim.SetBool("isWaiting", true);
        _se.stop = true;
        LauchScream();
    }
}
