using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutController : MonoBehaviour
{
    public bool longAnimations;
    private System.Action callback;
    [ContextMenu("FadeIn")]
    public void FadeIn() {
        if (longAnimations) {
            GetComponent<Animator>().Play("Fade_LongIn");
        } else {
            GetComponent<Animator>().Play("Fade_In");
        }
    }
    
    [ContextMenu("FadeOut")]
    public void FadeOut() {
        if (longAnimations) {
            GetComponent<Animator>().Play("Fade_LongOut");
        } else {
            GetComponent<Animator>().Play("Fade_Out");
        }
    }
    public void FadeOut(System.Action callback) {
        this.callback = callback;
        FadeOut();
    }

    public void OnAnimationEnds() {
        callback?.Invoke();
        this.callback = null;
    }

    public void SlapSound() {
        AudioManager.Instance.Play(Keys.Music.SLAP);
    }
}
