using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBorderController : MonoBehaviour {

    public List<Sprite> borders;

    [Range(0, 2)]
    public int currAct;
    void Start() {
        ChangeBorders();
    }

    [ContextMenu("ChangeBorders")]
    public void ChangeBorders() {
        ChangeBorders(currAct);
    }
    public void ChangeBorders(int currAct) {
        this.currAct = currAct;

        new List<Image>(GetComponentsInChildren<Image>()).ForEach(i => i.sprite = borders[currAct]);
    }
}
