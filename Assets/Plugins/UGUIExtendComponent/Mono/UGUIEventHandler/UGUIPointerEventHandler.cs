using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace UnityEngine.EventSystems
{
    public partial class UGUIEventHandler :
        IPointerClickHandler,
        IPointerDownHandler,
        IPointerUpHandler,
        IPointerEnterHandler,
        IPointerExitHandler
    {
        public EVENT_CALLBACK<PointerEventData> FuncOnPointerClick = null;
        public EVENT_CALLBACK<PointerEventData> FuncOnPointerDown = null;
        public EVENT_CALLBACK<PointerEventData> FuncOnPointerUp = null;
        public EVENT_CALLBACK<PointerEventData> FuncOnPointerEnter = null;
        public EVENT_CALLBACK<PointerEventData> FuncOnPointerExit = null;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (FuncOnPointerClick != null)
            {
#if !_DEBUG
                try
                {
#endif
                    FuncOnPointerClick.Invoke(eventData);
#if !_DEBUG
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(e);
                }
#endif
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (FuncOnPointerDown != null)
            {
#if !_DEBUG
                try
                {
#endif
                    FuncOnPointerDown.Invoke(eventData);
#if !_DEBUG
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(e);
                }
#endif
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (FuncOnPointerUp != null)
            {
#if !_DEBUG
                try
                {
#endif
                    FuncOnPointerUp.Invoke(eventData);
#if !_DEBUG
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(e);
                }
#endif
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (FuncOnPointerEnter != null)
            {
#if !_DEBUG
                try
                {
#endif
                    FuncOnPointerEnter.Invoke(eventData);
#if !_DEBUG
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(e);
                }
#endif
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (FuncOnPointerExit != null)
            {
#if !_DEBUG
                try
                {
#endif
                    FuncOnPointerExit.Invoke(eventData);
#if !_DEBUG
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(e);
                }
#endif
            }
        }

    }
}