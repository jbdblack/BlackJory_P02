using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;

public class JetPack : MonoBehaviour
{
    public float speed = 3f;

    public CharacterController CharCont;
    //public FirstPersonController FPC;

    public Vector3 currentVector = Vector3.up;

    public float CurrentForce = 0;

    public float MaxForce = 30;

    // Audio
    private AudioSource source;
    [SerializeField] AudioClip jetpackSound;


    void Start()
    {
        source = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.C) && MaxForce > 0)
        {
            MaxForce -= Time.deltaTime;

            if(CurrentForce < 1)
            
                CurrentForce += Time.deltaTime * 10;
            else
                    CurrentForce = 1;
            
        }

        if(MaxForce < 0 && CurrentForce > 0)
        {
            CurrentForce -= Time.deltaTime;
        }

        if (!Input.GetKey(KeyCode.C))
        {
            if (CurrentForce > 0)
                CurrentForce -= Time.deltaTime;
            else
                CurrentForce = 0;

            if (MaxForce < 30)
                MaxForce += Time.deltaTime;
            else
                MaxForce = 30;
        }

        if (CurrentForce > 0 )
            UseJetPack();
    }

    public void UseJetPack()
    {
        currentVector = Vector3.up;

        currentVector += transform.right * Input.GetAxis("Horizontal");
        currentVector += transform.forward * Input.GetAxis("Vertical");

        //CharCont.Move((currentVector * speed * Time.fixedDeltaTime - CharCont.velocity * Time.fixedDeltaTime) * CurrentForce);
        CharCont.Move((currentVector * speed * Time.deltaTime - CharCont.velocity * Time.deltaTime) * CurrentForce);

        //play audio 
        if (Input.GetKeyDown(KeyCode.C))
        {
            source.PlayOneShot(jetpackSound, .5f);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            source.Stop();
        }
        
    }
}
