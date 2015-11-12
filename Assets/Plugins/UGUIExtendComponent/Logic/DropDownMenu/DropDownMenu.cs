using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityEngine.UI.Logic
{
    public class DropDownMenu<T> where T: class, IDropDownMenuItem
    {
        private DropDownMenu m_compMonoCtrl;

        public delegate void ON_SELECTED_CALLBACK(T item);
        public ON_SELECTED_CALLBACK onSelectedCallback;

        protected List<T> m_lLogicInsList;
        protected Dictionary<GameObject, T> m_dictLogicInsMapper;

        private T m_tCurSelectedItem;

        public DropDownMenu(DropDownMenu mono)
        {
            m_compMonoCtrl = mono;
            m_lLogicInsList = new List<T>();
            m_dictLogicInsMapper = new Dictionary<GameObject, T>();
            mono.AddOnSelectedCallback(OnItemSelected);
        }

        public void AddItem(T item)
        {
            DropDownMenuItem itemObj = m_compMonoCtrl.AddSingleItem(item.GetItemDesc());
            item.SetItemObj(itemObj.gameObject);
            m_lLogicInsList.Add(item);
            m_dictLogicInsMapper.Add(itemObj.gameObject, item);
        }

        public void AddItemList(List<T> itemList)
        {
            List<string> strList = new List<string>();
            for (int i = 0; i < itemList.Count; ++i)
                strList.Add(itemList[i].GetItemDesc());

            List<DropDownMenuItem> newItemList = m_compMonoCtrl.AddMultiItem(strList);
            for (int i = 0; i < newItemList.Count; ++i)
            {
                T item = itemList[i];
                item.SetItemObj(newItemList[i].gameObject);
                m_lLogicInsList.Add(item);
                m_dictLogicInsMapper.Add(newItemList[i].gameObject, item);
            }
        }

        public void RemoveItem(T item)
        {
            m_lLogicInsList.Remove(item);
            m_dictLogicInsMapper.Remove(item.GetItemObj());
            if (item == CurSelectedItem)
            {
                if (m_lLogicInsList.Count > 0)
                    CurSelectedItem = m_lLogicInsList[0];
                else
                    CurSelectedItem = default(T);
            }
            m_compMonoCtrl.RemoveItem(item.GetItemObj());
        }

        public void ClearAllItem()
        {
            for (int i = 0; i < m_lLogicInsList.Count; ++i)
            {
                m_compMonoCtrl.RemoveItem(m_lLogicInsList[i].GetItemObj());
            }
            CurSelectedItem = default(T);

            m_lLogicInsList.Clear();
            m_dictLogicInsMapper.Clear();
        }

        public T CurSelectedItem
        {
            get
            {
                return m_tCurSelectedItem;
            }
            set
            {
                if (value == default(T))
                {
                    m_tCurSelectedItem = default(T);
                    m_compMonoCtrl.CurItemDesc = "None";
                    return;
                }
                T item;
                if (!m_dictLogicInsMapper.TryGetValue(value.GetItemObj(), out item))
                {
                    throw new Exception("No Such Item in List!!");
                }
                m_tCurSelectedItem = item;
                m_compMonoCtrl.CurItemDesc = item.GetItemDesc();
            }
        }

        public void SetCurSelectedItemByDesc(string desc)
        {
            for (int i = 0; i < m_lLogicInsList.Count; ++i)
            {
                if (desc == m_lLogicInsList[i].GetItemDesc())
                {
                    CurSelectedItem = m_lLogicInsList[i];
                    return;
                }
            }
        }

        private void OnItemSelected(GameObject itemObj)
        {
            T item;
            if (m_dictLogicInsMapper.TryGetValue(itemObj, out item))
            {
                CurSelectedItem = item;
                if (onSelectedCallback != null)
                    onSelectedCallback.Invoke(item);
            }
        }

        public void AddOnSelectedCallback(ON_SELECTED_CALLBACK func)
        {
            onSelectedCallback += func;
        }

        public void RemoveOnSelectedCallback(ON_SELECTED_CALLBACK func)
        {
            onSelectedCallback -= func;
        }
    }
}
