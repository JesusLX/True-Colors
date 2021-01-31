using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour {
    public ConfigManager configPanel;
    public GameObject creditsPanel;

    private void Start() {
        configPanel.gameObject.SetActive(false);
        creditsPanel.SetActive(false);

        AudioManager.Instance.Play(Keys.Music.MENU_MUSIC);

    }

    private void Update() {
        if(configPanel.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape)) {
            ToggleConfig();
        }

        if (creditsPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape)) {
            ToggleCredits();
        }
    }

    public void StartGame() {
        Debug.Log("LLAMO 1");
        SceneManager.LoadScene(1);
    }

    public void ToggleConfig() {
        Debug.Log("LLAMO 2");
        if (configPanel.gameObject.activeSelf) {
            configPanel.gameObject.SetActive(false);
        } else {
            configPanel.gameObject.SetActive(true);
        }
    }

    public void ToggleCredits() {
        Debug.Log("LLAMO 2");
        if (creditsPanel.activeSelf) {
            creditsPanel.SetActive(false);
        } else {
            creditsPanel.SetActive(true);

        }
    }

    public void ExitGame() {
        Debug.Log("LLAMO 3");
        Application.Quit();
    }
}
