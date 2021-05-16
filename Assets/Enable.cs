using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mesh.enabled = true;
        }
    }
}
