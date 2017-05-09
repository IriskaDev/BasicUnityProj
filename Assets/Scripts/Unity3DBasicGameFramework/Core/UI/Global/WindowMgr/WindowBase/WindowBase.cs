using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Common;

public class WindowBase : IWindow
{
    protected int m_iInstanceID;
    protected GameObject m_objInstanceRoot;
    protected RectTransform m_transInstanceRoot;
    protected Ticker m_ticker;
    protected WindowInfo m_wiInfo;

    private List<WindowWidgetBase> m_llWidgetList;

    protected WindowBase()
    {
        m_llWidgetList = new List<WindowWidgetBase>();
    }

    protected T CreateWidget<T>(GameObject widgetRoot) where T : WindowWidgetBase, new ()
    {
        T ins = new T();
        ins.BaseInit(widgetRoot, this);
        ins.Init();
        m_llWidgetList.Add(ins);
        return ins;
    }

    protected bool RemoveWidget(WindowWidgetBase ins)
    {
        m_llWidgetList.Remove(ins);
        return true;
    }


    public int GetModuleID()
    {
        return m_wiInfo.ModuleID;
    }

    public int GetWinInstanceID()
    {
        return m_iInstanceID;
    }

    public virtual bool IsUniqeWindow()
    {
        return m_wiInfo.UniqeWindow;
    }

    public GameObject GetRoot()
    {
        return m_objInstanceRoot;
    }

    public void BaseInit(int moduleId, int instanceId, GameObject root)
    {
        m_wiInfo = WindowInfoMgr.GetWindowInfo(moduleId);
        m_iInstanceID = instanceId;
        m_objInstanceRoot = root;
        m_transInstanceRoot = root.GetComponent<RectTransform>();
        m_ticker = m_objInstanceRoot.AddComponent<Ticker>();
    }

    public virtual void Init()
    {

    }

    public virtual void StartUp(object param = null)
    {
        for (int i = 0; i < m_llWidgetList.Count; ++i)
        {
            m_llWidgetList[i].StartUp(param);
        }
    }

    public virtual void StartListener()
    {
        for (int i = 0; i < m_llWidgetList.Count; ++i)
        {
            m_llWidgetList[i].StartListener();
        }
    }

    public virtual void RemoveListener()
    {
        for (int i = 0; i < m_llWidgetList.Count; ++i)
        {
            m_llWidgetList[i].RemoveListener();
        }
    }

    public virtual void Clear()
    {
        for (int i = 0; i < m_llWidgetList.Count; ++i)
        {
            m_llWidgetList[i].Clear();
        }
    }

    protected void Close()
    {
        Dispatcher.Dispatch<int>(GameEvents.WindowCloseEvent.EVT_NAME, m_iInstanceID);
    }
}
