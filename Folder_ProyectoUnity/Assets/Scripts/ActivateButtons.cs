using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButtons : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;

    public void ActiveOrNo1()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }

    public void ActiveOrNo2()
    {
        panel2.SetActive(false);
        panel1.SetActive(true);
    }
}
