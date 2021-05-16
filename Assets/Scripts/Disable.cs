using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private SlimeController slime;
    private bool check = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && check == false)
        {
            check = true;
            mesh.enabled = false;
            for(int i = 0; i < spawnPoint.Length; i++)
            {
                 Instantiate(slime, spawnPoint[i].position, spawnPoint[i].rotation).GetComponent<SlimeController>();
            }
        }
    }
}
