using UnityEngine;
using TMPro;

public class GameHUD : MonoBehaviour
{
    public int players = 5;
    public float time = 60f;

    private bool gameEnded = false;

    public TMP_Text playersText;
    public TMP_Text timeText;

    void Start()
    {
        playersText.text = "Players: " + players;
        timeText.text = "Time: " + Mathf.CeilToInt(time);
    }

    void Update()
    {
        if (gameEnded)
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

    public void RemovePlayer()
    {
        if (players > 0)
        {
            players--;
            playersText.text = "Players: " + players;
        }
    }
}