using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable3F : MonoBehaviour
{
    [SerializeField] private AudioSource treeAudio;
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private ParticleSystem[] particles;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mesh.enabled = true;
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].Stop();
            }
            treeAudio.Stop();
        }
    }
}
