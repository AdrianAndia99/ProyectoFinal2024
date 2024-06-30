using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FullScreen : MonoBehaviour
{
    public Toggle Toggle;
    public TMP_Dropdown Resolutiondropdown;
    Resolution[] ResolutionArray;

    private void Start()
    {
        if (Screen.fullScreen)
        {
            Toggle.isOn = true;
        }
        else
        {
            Toggle.isOn = false;
        }

        SeeResolution();
    }

    public void ActivateScreen(bool screen)
    {
        Screen.fullScreen = screen;
    }

    public void SeeResolution()
    {
        ResolutionArray = Screen.resolutions;
        Resolutiondropdown.ClearOptions();

        List<string> options = new List<string>();

        int actualResolution = 0;

        for(int i = 0; i < ResolutionArray.Length; i++)
        {
            int refreshRate = Mathf.RoundToInt((float)ResolutionArray[i].refreshRateRatio.value); // q será XD

            string option = ResolutionArray[i].width + " x " + ResolutionArray[i].height +"-"+refreshRate+"Hz";
            options.Add(option);
            // locazo esta parte XD
            if (Screen.fullScreen && ResolutionArray[i].width == Screen.currentResolution.width && ResolutionArray[i].height == Screen.currentResolution.height && refreshRate == Mathf.RoundToInt((float)Screen.currentResolution.refreshRateRatio.value))
            {
                actualResolution = i;
            }
        }

        Resolutiondropdown.AddOptions(options);
        Resolutiondropdown.value = actualResolution;
        Resolutiondropdown.RefreshShownValue();

        Resolutiondropdown.value = PlayerPrefs.GetInt("ResolutionNumber",0);

    }

    public void ChangeResolution(int ResolutionIndex)
    {
        PlayerPrefs.SetInt("ResolutionNumber", Resolutiondropdown.value);

        Resolution resolution = ResolutionArray[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}

// este codigo no lo cuento para nada, esta usando la lista de unity asi q gg nomas