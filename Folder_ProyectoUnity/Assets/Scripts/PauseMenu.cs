using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public RectTransform pausePanelRect;
    [SerializeField] float topPosY, middlePosY;
    [SerializeField] float TweenDuration;
    [SerializeField] CanvasGroup blackPanelTransition;

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        pausePanelIntro();
    }

    public  void Continue()
    {
        pausePanelOutro();      
    }

    void pausePanelIntro()
    {
        blackPanelTransition.DOFade(1, TweenDuration).SetUpdate(true);
        pausePanelRect.DOAnchorPosY(middlePosY,TweenDuration).SetUpdate(true);
    }

    public void pausePanelOutro()
    {
        blackPanelTransition.DOFade(1, TweenDuration).SetUpdate(true);
        pausePanelRect.DOAnchorPosY(topPosY, TweenDuration).SetUpdate(true).OnComplete(() =>
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
        });
    }
}