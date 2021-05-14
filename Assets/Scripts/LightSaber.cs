using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour
{
    public AudioClip beamAudio;
    [SerializeField] private ObjectSlicer objectSlicer;

    private AudioSource audioSource;
    private Animator animator;
    private bool isOn = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void TriggerBeam()
    {
        isOn = animator.GetBool("LightSaberOn");
        if (!isOn)
        {
            audioSource.PlayOneShot(beamAudio);
        }
        else
        {
            audioSource.Stop();
        }
        objectSlicer.enabled = !isOn;
        animator.SetBool("LightSaberOn", !isOn);
    }
}
