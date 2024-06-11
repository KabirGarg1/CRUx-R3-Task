using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;

    public int startingLives = 3, startingFruit = 0;

    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayMenuMusic();

        if(PlayerPrefs.HasKey("currentLevel"))
        {
            continueButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            AudioManager.instance.PlayLevelMusic(1);
        }

#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.DeleteAll();
        }
#endif
    }

    public void StartGame()
    {
        InfoTracker.instance.currentLives = startingLives;
        InfoTracker.instance.currentFruit = startingFruit;

        InfoTracker.instance.SaveInfo();

        SceneManager.LoadScene(firstLevel);
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("I Quit");
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("currentLevel"));
    }
}
