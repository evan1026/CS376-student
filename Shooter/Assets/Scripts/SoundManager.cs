using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioClip PewSound;
    public AudioClip BoomSound;

    private AudioSource audioSource;

    private static SoundManager inst;

    // Start is called before the first frame update
    void Start() {
        inst = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void PrivatePlayPew() {
        audioSource.PlayOneShot(PewSound, 0.8f);
    }

    public static void PlayPew() {
        inst.PrivatePlayPew();
    }

    private void PrivatePlayBoom() {
        audioSource.PlayOneShot(BoomSound, 0.5f);
    }

    public static void PlayBoom() {
        inst.PrivatePlayBoom();
    }

}
