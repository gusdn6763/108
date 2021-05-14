using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStart : MonoBehaviour
{
    [SerializeField] private List<SlimeController> slime = new List<SlimeController>();

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            for(int i = 0; i < slime.Count; i++)
            {
                slime[i].slimeStatus = SlimeStatus.Move;
                
            }
        }
    }
}
