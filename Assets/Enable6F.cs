using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enable6F : MonoBehaviour
{

    [SerializeField] private Image image;
    private bool check = false;

    [SerializeField] private FaceEffect face;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && check == false)
        {
            check = true;
            face.OnFade(FadeState.FadeIn);
        }
    }

}
