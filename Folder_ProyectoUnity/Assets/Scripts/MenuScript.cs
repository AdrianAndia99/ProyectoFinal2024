using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class MenuScript : MonoBehaviour
{
    public Transform[] menuInicio;

    void Start()
    {
        Time.timeScale = 1;
        for (int i = 0; i < menuInicio.Length; i++)
        {
            menuInicio[i].transform.localScale = new Vector3(0, 0, 0);
        }

        StartCoroutine(TimeOnMenu());
    }

    IEnumerator TimeOnMenu()
    {
        for (int i = 0; i < menuInicio.Length; i++)
        {
            menuInicio[i].DOScale(4f, 0.25f);
            yield return new WaitForSeconds(0.25f);
            menuInicio[i].DOScale(3f, 0.25f);
            Debug.Log("funciona");
        }
    }  
}