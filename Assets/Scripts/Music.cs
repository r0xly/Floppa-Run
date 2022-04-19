using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour
{
    AudioSource audioData;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        StartCoroutine(PlayMusic());
    }

    IEnumerator PlayMusic() {
        yield return new WaitUntil(() => !GameLoop.Paused);
        audioData.Play(0);
    }
}
