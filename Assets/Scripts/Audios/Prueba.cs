using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.Play(Keys.Music.BAD_CHOICE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
