using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedScreen : MonoBehaviour {

    private Image image;
    
    private float maxAlpha = 0.9f;

    void Start() {
        image = GetComponent<Image>();

        GameEventSystem.Instance.OnPlayerInDangerZone += SetRedScreen;
    }

    void SetRedScreen(bool setScreen) {
        Color color = image.color;

        float secondsForOneFlash = 0.5f;

        maxAlpha = Mathf.Clamp(maxAlpha, 0, 1);


        if (setScreen) {   
            StartCoroutine(Flash(secondsForOneFlash, maxAlpha,setScreen));
        } else {
            StopCoroutine(Flash(secondsForOneFlash, maxAlpha, setScreen));
            image.color = new Color(color.r, color.g, color.b, 0);
        }
    }

    IEnumerator Flash(float secondsForOneFlash, float maxAlpha,bool setScreen)
    {
       while (setScreen)
       {
            float flashInDuration = secondsForOneFlash / 2;
            for (float t = 0; t <= flashInDuration; t += Time.deltaTime)
            {
                Color colorThisFrame = image.color;
                colorThisFrame.a = Mathf.Lerp(0, maxAlpha, t / flashInDuration);
                image.color = colorThisFrame;

                yield return null;
            }

            float flashOut = secondsForOneFlash / 2;
            for (float t = 0; t <= flashOut; t += Time.deltaTime)
            {
                Color colorThisFrame = image.color;
                colorThisFrame.a = Mathf.Lerp(maxAlpha, 0, t / flashOut);
                image.color = colorThisFrame;

               yield return null;
            }
            
       }

    }
}