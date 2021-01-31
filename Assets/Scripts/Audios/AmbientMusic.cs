using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMusic : MonoBehaviour {
    public int actAmbientSelected;

    private void Start() {
        switch (actAmbientSelected) {
            case 1:
                CheckPause(Keys.Music.MENU_MUSIC);
                CheckPlaying(Keys.Music.FIRST_ACT);
                //AudioManager.Instance.Play(Keys.Music.SPREAD_3_CARDS);
                break;
            case 2:
                CheckPause(Keys.Music.FIRST_ACT);
                CheckPlaying(Keys.Music.SECOND_ACT);
                break;
            case 3:
                CheckPause(Keys.Music.SECOND_ACT);
                CheckPlaying(Keys.Music.THIRD_ACT);
                break;
            default:
                CheckPause(Keys.Music.FIRST_ACT);
                CheckPause(Keys.Music.SECOND_ACT);
                CheckPause(Keys.Music.THIRD_ACT);
                CheckPlaying(Keys.Music.MENU_MUSIC);
                break;
        }
    }

    private void CheckPlaying(string actName) {
        if (!AudioManager.Instance.IsPlaying(actName))
            AudioManager.Instance.Play(actName);
    }

    private void CheckPause(string actName) {
        if (AudioManager.Instance.IsPlaying(actName))
            AudioManager.Instance.Pause(actName);
    }

}
