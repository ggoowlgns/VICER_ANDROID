using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTouch : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.BackBtn == "Screen3")
        {
            fade();
        }
    }
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

        GameManager.instance.Main_Active();
    }
}
