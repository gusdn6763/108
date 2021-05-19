using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disable5F : MonoBehaviour
{

    [SerializeField] private TypingEffect ty;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ty.typing());
        }
    }
}
