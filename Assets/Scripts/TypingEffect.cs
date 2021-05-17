using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public Text txt;
    private string m_txt = "H A P P Y F L O O R";
    void Start()
    {
        StartCoroutine(typing());
    }

    IEnumerator typing()
    {
        yield return new WaitForSeconds(1f);

        for (int i= 0; i < m_txt.Length; i++)
        {
            txt.text = m_txt.Substring(0, i+1);

            yield return new WaitForSeconds(0.15f);
        }
    }
}
