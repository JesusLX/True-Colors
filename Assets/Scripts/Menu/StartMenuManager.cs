using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour {
    public ConfigManager configPanel;

    private void Start() {
        configPanel.gameObject.SetActive(false);

        AudioManager.Instance.Play(Keys.Music.MENU_MUSIC);

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

    public void ExitGame() {
        Debug.Log("LLAMO 3");
        Application.Quit();
    }
}
