using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable3F : MonoBehaviour
{
    [SerializeField] private AudioSource treeAudio;
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private ParticleSystem[] particles;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            treeAudio.Play();
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].Play();
            }
            mesh.enabled = false;
        }
    }
}
