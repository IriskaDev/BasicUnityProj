using System;
using UnityEngine;
using Common;


public class WindowWidgetBase : IWindowWidget
{
    private GameObject m_objWidgetRoot;
    private RectTransform m_transWidgetRoot;
    private WindowBase m_winbaseWinRef;
    protected Ticker m_ticker;

    public void BaseInit(GameObject root, WindowBase winRef)
    {
        m_objWidgetRoot = root;
        m_transWidgetRoot = root.GetComponent<RectTransform>();

        m_winbaseWinRef = winRef;
        m_ticker = root.AddComponent<Ticker>();
    }

    public virtual void Init()
    {
        throw new NotImplementedException();
    }

    public virtual void StartUp(object param = null)
    {
        throw new NotImplementedException();
    }

    public virtual void StartListener()
    {
        throw new NotImplementedException();
    }

    public virtual void RemoveListener()
    {
        throw new NotImplementedException();
    }

    public virtual void Clear()
    {
        throw new NotImplementedException();
    }
}
