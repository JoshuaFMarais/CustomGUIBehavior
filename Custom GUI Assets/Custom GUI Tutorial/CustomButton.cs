using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class CustomButton : CustomGUIBehavior
{
    [HideInInspector]
    public GameObject TargetSceneGameobject;
    [HideInInspector]
    public MonoBehaviour SelectedMono;
    [HideInInspector]
    public MethodInfo m_method;

    [Header("Sound")]
    public AudioClip ClickSound;

    AudioSource source;
         
    protected override void Init()
    {        
        if (ClickSound == null) ClickSound = Resources.Load<AudioClip>("click_sound");
        source = GetComponent<AudioSource>();
    }

    protected override void ClickAction()
    {       
        source.PlayOneShot(ClickSound);
        m_method?.Invoke(SelectedMono, null);
    }

}
