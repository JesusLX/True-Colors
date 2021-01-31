using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeController : MonoBehaviour
{
    public ShakeTransformS shaker;
    public List<ParticleSystem> particles; 

    [ContextMenu("Shake")]
    public void Shake() {
        shaker.Begin();
        particles.ForEach(p => p.Play());
    }
}

