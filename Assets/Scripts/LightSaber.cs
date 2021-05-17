using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour
{
    public AudioClip beamAudio;
    [SerializeField] private ObjectSlicer objectSlicer;
    [SerializeField] private Animator animatorPeople;

    private AudioSource audioSource;
    private Animator animator;
    public bool isOn = false;
    private bool oneCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void TriggerBeam()
    {
        if (!oneCheck)
        {
            animatorPeople.SetBool("Action", true);
            oneCheck = true;
        }
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
