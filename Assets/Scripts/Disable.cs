using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh;

    private bool check = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && check == false)
        {
            check = true;
            mesh.enabled = false;
        }
    }
}
