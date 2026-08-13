using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject resumeButton;

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            bool isPaused = pausePanel.activeSelf;

            pausePanel.SetActive(!isPaused);

            if (!isPaused)
            {
                StartCoroutine(SelectResumeButton());
            }
        }
    }

    private System.Collections.IEnumerator SelectResumeButton()
    {
        yield return null;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resumeButton);
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
    }

    public bool IsPaused()
    {
        return pausePanel.activeSelf;
    }

    public void GoToTitle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }
}