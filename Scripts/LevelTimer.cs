using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    public float timeRemaining = 10f; 
    public TMP_Text timerText;
    public GameObject character; 

    private bool timerIsRunning = false;

    void Start()
    {
        timerIsRunning = true;
        UpdateTimerText(); 
    }

    void Update()
    {
       
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                
                timeRemaining -= Time.deltaTime;
                UpdateTimerText(); 
            }
            else
            {
                
                timeRemaining = 0;
                timerIsRunning = false;
                KillCharacter(); 
            }
        }
    }

    void UpdateTimerText()
    {
       
        timerText.text = "Time Left: " + Mathf.Round(timeRemaining).ToString();
    }

    void KillCharacter()
    {
        
        Destroy(character);
        SceneManager.LoadScene(1);

    }
}
