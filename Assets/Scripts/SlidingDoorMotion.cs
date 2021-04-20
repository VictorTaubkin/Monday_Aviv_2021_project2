using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorMotion : MonoBehaviour
{
    private Animator anim;
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("doorOpen", true);
        sound.PlayDelayed(0.7f);
    }
    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("doorOpen", false);
        sound.PlayDelayed(0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
