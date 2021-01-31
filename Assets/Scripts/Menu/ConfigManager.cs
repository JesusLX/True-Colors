using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour {
    public bool soundActive, colorBlindActive;

    public void ToggleSound() {
        if (soundActive) {
            AudioManager.Instance.ChangeAllVolumes(0);
            soundActive = false;
        } else {
            AudioManager.Instance.ResetAllVolumes();
            soundActive = true;
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
