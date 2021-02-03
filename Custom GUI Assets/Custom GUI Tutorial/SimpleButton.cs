using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SimpleButton : CustomGUIBehavior
{
    public int m_num;
    public string m_text;

    public delegate void CustomEvent();
    public CustomEvent m_event;

    protected override void ClickAction()
    {
        Debug.Log(m_text + ": " + m_num);
        m_event?.Invoke();
    }

    protected override void Init()
    {
       
    }
}

