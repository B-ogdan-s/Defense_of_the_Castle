using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    [SerializeField] private Image _timerImage;
    [SerializeField] private TextMeshProUGUI _text;

    public Action AddDetachment;
    public void UpdateText(int num)
    {
        _text.text = num.ToString();
    }

    public void StartTimer(float time)
    {
        StartCoroutine(CR_Timer(time));
    }

    private IEnumerator CR_Timer(float timer)
    {
        _timerImage.fillAmount = 0;

        float delta = 1 / timer;
        float value = 0;

        while(value < timer)
        {
            value += Time.deltaTime;

            _timerImage.fillAmount += delta * Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        AddDetachment?.Invoke();
    }
}
