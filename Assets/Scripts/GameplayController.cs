using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public float timer;
    public Text timerText;
    public Text timerGameOverText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        DisplayTimer(timer);
    }

    public void DisplayTimer(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerGameOverText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
