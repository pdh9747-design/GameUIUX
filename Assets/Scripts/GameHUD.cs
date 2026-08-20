using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class GameHUD : MonoBehaviour
{
    public TMP_Text playersText;
    public TMP_Text timeText;
    public TMP_Text taggerText;

    public GameObject toastText;
    public GameObject resultPanel;
    public GameObject resultTitleButton;
    public GameObject gameTitle;

    public PauseManager pauseManager;

    public int players = 5;
    public float time = 60f;

    private int taggerCount = 1;

    private bool gameEnded = false;

    void Start()
    {
        playersText.text = "Players: " + players;
        timeText.text = "Time: " + Mathf.CeilToInt(time);
        taggerText.text = "술래: " + taggerCount;

        toastText.SetActive(false);
        resultPanel.SetActive(false);
    }

    void Update()
    {
        if (gameEnded)
        {
            return;
        }

        if (pauseManager != null && pauseManager.IsPaused())
        {
            return;
        }

        if (time > 0)
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                time = 0;
                gameEnded = true;

                timeText.text = "Time: 0";

                Debug.Log("게임 종료!");
            }

            timeText.text = "Time: " + Mathf.CeilToInt(time);
        }
    }

    public void FindPlayer()
    {
        if (gameEnded)
        {
            return;
        }

        if (players > 0)
        {
            players--;
        }

        playersText.text = "Players: " + players;

        taggerCount++;
        taggerText.text = "술래: " + taggerCount;

        ShowPlayerFound();

        if (players <= 0)
        {
            players = 0;
            playersText.text = "Players: 0";

            ShowResult();
        }
    }

    public void ShowPlayerFound()
    {
        StartCoroutine(ShowToast());
    }

    private System.Collections.IEnumerator ShowToast()
    {
        toastText.SetActive(true);

        yield return new WaitForSeconds(2f);

        toastText.SetActive(false);
    }

    public void ShowResult()
    {
        resultPanel.SetActive(true);
        gameTitle.SetActive(false);

        gameEnded = true;

        EventSystem.current.SetSelectedGameObject(null);

        GameObject button = resultTitleButton;

        EventSystem.current.SetSelectedGameObject(button);

        Debug.Log("현재 선택된 UI: " + EventSystem.current.currentSelectedGameObject);
    }
}