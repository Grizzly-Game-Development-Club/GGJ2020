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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Airlock(string motion)
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

    private void TakeItem(string type)
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

    private void Footsteps()
    {
        int rand = Random.Range(1, 3);
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

    private void RepairWires()
    {
        myAudioSource.PlayOneShot(wirekit);
    }
}
