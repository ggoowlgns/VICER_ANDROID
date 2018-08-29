using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotoScreen2 : MonoBehaviour
{

    public void fade()
    {
        StartCoroutine(DoFade());
    }


    IEnumerator DoFade()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 2;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;

        GameManager.instance.Screen2_Active();
    }
}
