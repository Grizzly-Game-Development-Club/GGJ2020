using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach this to systems for damage and the fire ext. for foam
public class EmissionController : MonoBehaviour
{
    public bool emitting;
    ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        particles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (emitting)
        {
            particles.Play();
        }
        else
        {
            particles.Stop();
        }
    }
}
