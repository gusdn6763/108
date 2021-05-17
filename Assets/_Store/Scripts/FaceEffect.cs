using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FadeState
{
    FadeIn = 0,
    FadeOut,
    FadeInOut,
    FadeLoop
}

public class FaceEffect : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime;                     // fadeSpeed���� 10�̸� 1�� ( ���� Ŭ ���� ����)
    [SerializeField]
    private AnimationCurve fadeCurve;

    private Image image;                        // ���̵� ȿ���� ���Ǵ� �̹���
    private FadeState fadeState;                // ���̵� ȿ�� ����

    void Awake()
    {
        image = GetComponent<Image>();

        //// Fade In. ����� ���� ���� 1 ~ 0 ���� (ȭ���� �����)
        //StartCoroutine(Fade(1, 0));
        //// Fade Out. ����� ���� ���� 0 ~ 1 ���� (ȭ���� ��ο���)
        //StartCoroutine(Fade(0, 1));

        OnFade(FadeState.FadeIn);

    }

    public void OnFade(FadeState state)
    {
        fadeState = state;

        switch(fadeState)
        {
            // 1 ~ 0 : ���� �����
            case FadeState.FadeIn:
                StartCoroutine(Fade(1, 0));
                break;
            // 0 ~ 1 : ���� ��ο���
            case FadeState.FadeOut:
                StartCoroutine(Fade(0, 1));
                break;
            case FadeState.FadeInOut:               // In -> Out 1ȸ �ݺ�
            case FadeState.FadeLoop:                // Out -> In ���� �ݺ�
                StartCoroutine(FadeInout());
                break;
        }
    }

    private IEnumerator FadeInout()
    {
        // �ڷ�ƾ ���ο��� �ڷ�ƾ �Լ��� ȣ���ϸ� �ش� �ڷ�ƾ �Լ��� ����Ǿ�� ���� ���� ����.
        while (true)
        {
            // Fade In
            yield return StartCoroutine(Fade(1, 0));         
            
            // Fade Out
            yield return StartCoroutine(Fade(0, 1));          
            
            // 1ȸ�� ����ϴ� ������ �� break
            if(fadeState == FadeState.FadeInOut)
            {
                break;
            }

        }
    }

    private IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            /* FadeTime���� ����� FadeTime �ð� ����
             percent ���� 0 ~ 1�� �����ϵ��� ��.*/
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            // ���� ���� start���� end���� fadeTime�ð� ���� ��ȭ
            Color color = image.color;
            color.a = Mathf.Lerp(start, end, percent);
            image.color = color;

            yield return null;
        }
    }


}
