using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource myAudioSource;
    public AudioClip airlockClose;
    public AudioClip airlockOpen;
    public AudioClip equip;
    public AudioClip footstep1;
    public AudioClip footstep2;
    public AudioClip footstep3;
    public AudioClip pickup;
    public AudioClip wirekit;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Airlock(string motion)
    {
        if(motion == "close")
        {
            myAudioSource.PlayOneShot(airlockClose);
        }
        else
        {
            myAudioSource.PlayOneShot(airlockOpen);
        }
    }

    public void TakeItem(string type)
    {
        //use for held items
        if (type == "held")
        {
            myAudioSource.PlayOneShot(equip);
        }
        //use for suit (and maybe wires?)
        else
        {
            myAudioSource.PlayOneShot(pickup);
        }
    }

    public void Footsteps()
    {
        if (!myAudioSource.isPlaying)
        {
            int rand = Random.Range(0, 3);
            if (rand == 1)
            {
                myAudioSource.PlayOneShot(footstep1);
            }
            else if (rand == 2)
            {
                myAudioSource.PlayOneShot(footstep2);
            }
            else
            {
                myAudioSource.PlayOneShot(footstep3);
            }
        }
    }

    public void RepairWires()
    {
        myAudioSource.PlayOneShot(wirekit);
    }
}
