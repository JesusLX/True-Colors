using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimatorController : MonoBehaviour {
    System.Action callback;
    public void DoEntrance(System.Action callback) {
        this.callback = callback;
        GetComponent<Animator>().SetTrigger("ToEntrance");
    }
    public void DoHappy(System.Action callback) {
        this.callback = callback;
        GetComponent<Animator>().SetTrigger("ToHappy");
    }
    public void DoRage(System.Action callback) {
        this.callback = callback;
        GetComponent<Animator>().SetTrigger("ToRage");
    }
    public void DoExit(System.Action callback) {
        this.callback = callback;
        GetComponent<Animator>().SetTrigger("ToExit");
    }
    public void OnAnimaionEnds() {
        callback?.Invoke();
        this.callback = null;
    }
}
