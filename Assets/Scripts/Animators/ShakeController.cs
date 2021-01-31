using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeController : MonoBehaviour {
    public static ShakeController Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public ShakeTransformS shaker;
    public List<ParticleSystem> particles;

    [ContextMenu("Shake")]
    public void Shake() {
        shaker.Begin();
        particles.ForEach(p => p.Play());
    }
}

