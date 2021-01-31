using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXDirector : MonoBehaviour {

    public List<VFX> vfxEffects;
    public static VFXDirector Instance { get; private set; }
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public ParticleSystem Play(string name, Transform position, Color color) {
        VFX vfx = vfxEffects.Find(v => v.name.Equals(name));
        ParticleSystem ps = null;
        if (vfx != null) {
            ps = vfx.Play(position, color);
            ps.transform.SetParent(this.transform);
            StartCoroutine(DisablePS(ps, vfx.time));
        } else {
            Debug.LogWarning("El vfx no existe: " + name);
        }
        return ps;
    }  
    public ParticleSystem PlayEternal(string name, Vector3 position, Color color,Sprite sprite) {
        VFX vfx = vfxEffects.Find(v => v.name.Equals(name));
        ParticleSystem ps = null;
        if (vfx != null) {
            ps = vfx.PlayEternal(position, color, sprite);
            ps.transform.SetParent(this.transform);
           // StartCoroutine(DisablePS(ps, vfx.time));
        } else {
            Debug.LogWarning("El vfx no existe: " + name);
        }
        return ps;
    }
    public ParticleSystem Play(string name, Vector3 position, Color color) {
        VFX vfx = vfxEffects.Find(v => v.name.Equals(name));
        ParticleSystem ps = null;
        if (vfx != null) {
            ps = vfx.Play(position, color);
            ps.transform.SetParent(this.transform);
            StartCoroutine(DisablePS(ps, vfx.time));
        } else {
            Debug.LogWarning("El vfx no existe: " + name);
        }
        return ps;
    }
    public ParticleSystem Play(string name, Vector3 position) {
        VFX vfx = vfxEffects.Find(v => v.name.Equals(name));
        ParticleSystem ps = null;
        if (vfx != null) {
            ps = vfx.Play(position);
            ps.transform.SetParent(this.transform);
            StartCoroutine(DisablePS(ps, vfx.time));
        } else {
            Debug.LogWarning("El vfx no existe: " + name);
        }
        return ps;
    }
    IEnumerator DisablePS(ParticleSystem ps, float time) {
        yield return new WaitForSeconds(time);
        ps.Stop();
        ps.gameObject.SetActive(false);
    }
    [Serializable]
    public class VFX {

        public string name;
        public float time;
        public ParticleSystem PSPrefab;
        public List<ParticleSystem> pool;


        public ParticleSystem Play(Transform position, Color color) {

            ParticleSystem particles;
            if (!(particles = pool.Find(p => !p.gameObject.activeInHierarchy))) {
                particles = Instantiate(PSPrefab);
                pool.Add(particles);
            }
            SetColor(particles, color);
            foreach (ParticleSystem child in particles.GetComponentsInChildren<ParticleSystem>()) {
                SetColor(child, color);
            }
            particles.transform.position = position.position;
            particles.transform.rotation = position.rotation;
            particles.gameObject.SetActive(true);
            particles.time = 0;
            particles.Play();


            return particles;
        }
        public ParticleSystem PlayEternal(Vector3 position, Color color, Sprite sprite = null) {
            ParticleSystem particles;
            if (!(particles = pool.Find(p => !p.gameObject.activeInHierarchy))) {
                particles = Instantiate(PSPrefab);
                pool.Add(particles);
            }
            SetColors(particles,color);
            foreach (ParticleSystem child in particles.GetComponentsInChildren<ParticleSystem>()) {
                SetColors(child, color);
            }
            if (sprite != null) {
                if (particles.textureSheetAnimation.spriteCount > 0)
                    particles.textureSheetAnimation.RemoveSprite(particles.textureSheetAnimation.spriteCount - 1);
                particles.textureSheetAnimation.AddSprite(sprite);
            }

            particles.transform.position = position;
            particles.gameObject.SetActive(true);
            particles.time = 0;
            particles.Play();


            return particles;
        }
        private void SetColor(ParticleSystem ps, Color color) {
            ParticleSystem.MainModule settings = ps.main;
            settings.startColor = new ParticleSystem.MinMaxGradient(color);
        }   
        private void SetColors(ParticleSystem ps, Color color) {
            ParticleSystem.MainModule settings = ps.main;
            Color softColor = color;
            color.a = .7f;
            softColor.a = .2f;
            settings.startColor = new ParticleSystem.MinMaxGradient(softColor, color);
        }


        public ParticleSystem Play(Vector3 position, Color color) {
            ParticleSystem particles;
            if (!(particles = pool.Find(p => !p.gameObject.activeInHierarchy))) {
                particles = Instantiate(PSPrefab);
                pool.Add(particles);
            }
            ParticleSystem.MainModule settings = particles.main;
            SetColor(particles, color);
            foreach (ParticleSystem child in particles.GetComponentsInChildren<ParticleSystem>()) {
                SetColor(child, color);
            }
            //  particles.transform.rotation = position.rotation;
            particles.gameObject.SetActive(true);
            particles.time = 0;
            particles.Play();

            return particles;
        }
        public ParticleSystem Play(Vector3 position) {
            ParticleSystem particles;
            if (!(particles = pool.Find(p => !p.gameObject.activeInHierarchy))) {
                particles = Instantiate(PSPrefab);
                pool.Add(particles);
            }

            particles.transform.position = position;
            //  particles.transform.rotation = position.rotation;
            particles.gameObject.SetActive(true);
            particles.time = 0;
            particles.Play();

            return particles;
        }

        bool IsPlaying(Transform parent) {
            bool playing = false;

            foreach (ParticleSystem item in parent.GetComponentsInChildren<ParticleSystem>()) {
                if (playing = item.IsAlive(true)) {
                    break;
                }
            }
            return playing;
        }
    }
}
