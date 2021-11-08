using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    public AudioClip crackSound;
    public AudioClip breakSound;
    public AudioClip bounceSound;
    public AudioSource audioSource;

    public void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void playBrickCrack() {
        audioSource.PlayOneShot(crackSound);
    }

    public void playBrickBreak() {
        audioSource.PlayOneShot(breakSound, 0.3f);
    }

    public void playBallBounce() {
        audioSource.PlayOneShot(bounceSound);
    }
}
