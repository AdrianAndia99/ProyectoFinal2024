using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public void Perder()
    {
        SceneManager.LoadScene("GameOver");
    }
}