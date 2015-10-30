using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace UnityEngine.EventSystems
{
    public partial class UGUIEventHandler :
        IEventSystemHandler,
        IInitializePotentialDragHandler,
        IScrollHandler,
        ISelectHandler,
        ISubmitHandler,
        IUpdateSelectedHandler
    {
        public EVENT_CALLBACK<PointerEventData> FuncOnInitPotentialDrag = null;
        public EVENT_CALLBACK<PointerEventData> FuncOnScroll = null;
        public EVENT_CALLBACK<BaseEventData> FuncOnSelect = null;
        public EVENT_CALLBACK<BaseEventData> FuncOnSubmit = null;
        public EVENT_CALLBACK<BaseEventData> FuncOnUpdateSelected = null;

        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            if (FuncOnInitPotentialDrag != null)
            {
#if !_DEBUG
                try
                {
#endif
                    FuncOnInitPotentialDrag.Invoke(eventData);
#if !_DEBUG
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(e);
                }
#endif
            }
        }

        public void OnScroll(PointerEventData eventData)
        {
            if (FuncOnScroll != null)
            {
#if !_DEBUG
                try
                {
#endif
                    FuncOnScroll.Invoke(eventData);
#if !_DEBUG
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(e);
                }
#endif
            }
        }

        public void OnSelect(BaseEventData eventData)
        {
            if (FuncOnSelect != null)
            {
#if !_DEBUG
                try
                {
#endif
                    FuncOnSelect.Invoke(eventData);
#if !_DEBUG
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(e);
                }
#endif
            }
        }

        public void OnSubmit(BaseEventData eventData)
        {
            if (FuncOnSubmit != null)
            {
#if !_DEBUG
                try
                {
#endif
                    FuncOnSubmit.Invoke(eventData);
#if !_DEBUG
                }
                catch (Exception e)
                {
                    ExceptionHandler.LogException(e);
                }
#endif
            }
        }

        public void OnUpdateSelected(BaseEventData eventData)
        {
            if (FuncOnUpdateSelected != null)
            {
#if !_DEBUG
                try
                {
#endif
                    FuncOnUpdateSelected.Invoke(eventData);
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
