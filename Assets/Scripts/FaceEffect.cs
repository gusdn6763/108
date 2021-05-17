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
    private float fadeTime;                     // fadeSpeed값이 10이면 1초 ( 값이 클 수록 빠름)
    [SerializeField]
    private AnimationCurve fadeCurve;

    private Image image;                        // 페이드 효과에 사용되는 이미지
    private FadeState fadeState;                // 페이드 효과 상태

    void Awake()
    {
        image = GetComponent<Image>();

        //// Fade In. 배경의 알파 값이 1 ~ 0 으로 (화면이 밝아짐)
        //StartCoroutine(Fade(1, 0));
        //// Fade Out. 배경의 알파 값이 0 ~ 1 으로 (화면이 어두워짐)
        //StartCoroutine(Fade(0, 1));

        OnFade(FadeState.FadeIn);

    }

    public void OnFade(FadeState state)
    {
        fadeState = state;

        switch(fadeState)
        {
            // 1 ~ 0 : 점점 밝아짐
            case FadeState.FadeIn:
                StartCoroutine(Fade(1, 0));
                break;
            // 0 ~ 1 : 점점 어두워짐
            case FadeState.FadeOut:
                StartCoroutine(Fade(0, 1));
                break;
            case FadeState.FadeInOut:               // In -> Out 1회 반복
            case FadeState.FadeLoop:                // Out -> In 무한 반복
                StartCoroutine(FadeInout());
                break;
        }
    }

    private IEnumerator FadeInout()
    {
        // 코루틴 내부에서 코루틴 함수를 호출하면 해당 코루틴 함수가 종료되어야 다음 문장 실행.
        while (true)
        {
            // Fade In
            yield return StartCoroutine(Fade(1, 0));         
            
            // Fade Out
            yield return StartCoroutine(Fade(0, 1));          
            
            // 1회만 재생하는 상태일 때 break
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
            /* FadeTime으로 나누어서 FadeTime 시간 동안
             percent 값이 0 ~ 1로 증가하도록 함.*/
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            // 알파 값을 start부터 end까지 fadeTime시간 동안 변화
            Color color = image.color;
            color.a = Mathf.Lerp(start, end, percent);
            image.color = color;

            yield return null;
        }
    }


}
