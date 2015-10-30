using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Login : WindowBase {
    private InputField m_ifAcc;
    private GameObject m_objBTNLogin;
    private GameObject m_objBTNExit;

    public override void Init()
    {
        base.Init();
        m_ifAcc = m_transInstanceRoot.FindChild("Acc").GetComponent<InputField>();
        m_objBTNLogin = m_transInstanceRoot.FindChild("BtnLogin").gameObject;
        m_objBTNExit = m_transInstanceRoot.FindChild("BtnExit").gameObject;
        UGUIEventHandler.AddListener(m_objBTNLogin, UGUIEventType.POINTER_CLICK, OnLoginClick);
        UGUIEventHandler.AddListener(m_objBTNExit, UGUIEventType.POINTER_CLICK, OnExit);
    }

    private void OnLoginClick(PointerEventData evtDat)
    {
        Debug.Log(m_ifAcc.text);
    }

    private void OnExit(PointerEventData evtDat)
    {
        Application.Quit();
    }
}
