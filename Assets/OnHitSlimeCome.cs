using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitSlimeCome : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private Transform[] spawnPoint2;
    [SerializeField] private SlimeController slime;
    [SerializeField] private SlimeController slime2;
    // Start is called before the first frame update
    private bool check = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon") && check == false)
        {
            check = true;
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                Instantiate(slime, spawnPoint[i].position, spawnPoint[i].rotation).GetComponent<SlimeController>();
            }
            for (int i = 0; i < spawnPoint2.Length; i++)
            {
                Instantiate(slime2, spawnPoint2[i].position, spawnPoint2[i].rotation).GetComponent<SlimeController>();
            }
        }
    }
}
