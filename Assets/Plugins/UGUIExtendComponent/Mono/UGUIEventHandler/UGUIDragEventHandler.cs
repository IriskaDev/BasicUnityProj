using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace UnityEngine.EventSystems
{
    public partial class UGUIEventHandler :
        IBeginDragHandler,
        ICancelHandler,
        IDeselectHandler,
        IDragHandler,
        IDropHandler,
        IEndDragHandler,
        IMoveHandler
    {
        public EVENT_CALLBACK<PointerEventData> FuncOnBeginDrag = null;
        public EVENT_CALLBACK<BaseEventData> FuncOnCancel = null;
        public EVENT_CALLBACK<BaseEventData> FuncOnDeselect = null;
        public EVENT_CALLBACK<PointerEventData> FuncOnDrag = null;
        public EVENT_CALLBACK<PointerEventData> FuncOnDrop = null;
        public EVENT_CALLBACK<PointerEventData> FuncOnEndDrag = null;
        public EVENT_CALLBACK<AxisEventData> FuncOnMove = null;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (FuncOnBeginDrag != null)
            {
#if !_DEBUG
                try
                {
#endif
                    FuncOnBeginDrag.Invoke(eventData);
#if !_DEBUG
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(e);
                }
#endif
            }
        }

        public void OnCancel(BaseEventData eventData)
        {
            if (FuncOnCancel != null)
           {
#if !_DEBUG
                try
                {
#endif
                    FuncOnCancel.Invoke(eventData);
#if !_DEBUG
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(e);
                }
#endif
           }
        }

        public void OnDeselect(BaseEventData eventData)
        {
            if (FuncOnDeselect != null)
            {
#if !_DEBUG
                try
                {
#endif
                    FuncOnDeselect.Invoke(eventData);
#if !_DEBUG
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(e);
                }
#endif
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (FuncOnDrag != null)
            {
#if !_DEBUG
                try
                {
#endif
                    FuncOnDrag.Invoke(eventData);
#if !_DEBUG
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(e);
                }
#endif
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (FuncOnDrop != null)
            {
#if !_DEBUG
                try
                {
#endif
                    FuncOnDrop.Invoke(eventData);
#if !_DEBUG
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(e);
                }
#endif
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (FuncOnEndDrag != null)
            {
#if !_DEBUG
                try
                {
#endif
                    FuncOnEndDrag.Invoke(eventData);
#if !_DEBUG
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(e);
                }
#endif
            }
        }
        public void OnMove(AxisEventData eventData)
        {
            if (FuncOnMove != null)
            {
#if !_DEBUG
                try
                {
#endif
                    FuncOnMove.Invoke(eventData);
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
