using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigManager : MonoBehaviour {
    public bool soundActive, colorBlindActive;
    public Image soundIndicator;
    public Sprite audioOn, audioOff;

    public void ToggleSound() {
        if (soundActive) {
            AudioManager.Instance.ChangeAllVolumes(0);
            soundActive = false;
            soundIndicator.sprite = audioOff;
        } else {
            AudioManager.Instance.ResetAllVolumes();
            soundActive = true;
            soundIndicator.sprite = audioOn;
        }
        Debug.LogWarning("TENGO SOUND " + soundActive);
    }

    public void ToggleColor() {
        if (colorBlindActive) {
            // TBD
            colorBlindActive = false;
        } else {
            // TBD
            colorBlindActive = true;
        }
        Debug.LogWarning("TENGO COLOR " + soundActive);

    }
}
