using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public void Perder()
    {
        SceneManager.LoadScene("GameOver");
    }
}