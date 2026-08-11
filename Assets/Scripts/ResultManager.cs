using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}