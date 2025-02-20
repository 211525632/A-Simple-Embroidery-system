using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

namespace UiFramewark
{

    /// <summary>
    /// Ui集合，是ui的容器
    /// 方便各种Ui的使用
    /// 通过他们各自的名称
    /// </summary>
    public class UiCollection : MonoBehaviour
    {

        private Dictionary<string, BasicUi> _uiDict;

        public BasicUi[] basicUis;

        /// 获取所有在这个物体之下的BasicUi组件
        /// </summary>
        private void GetAllUiElement()
        {
             basicUis = this.GetComponentsInChildren<BasicUi>();

            for(int i=0;i<basicUis.Length;++i)
            {
                if (!_uiDict.TryAdd(basicUis[i].name, basicUis[i]))
                {
                    Debug.LogError("存在同名Ui！name：" + basicUis[i].name);
                }
            }
        }

        private void Awake()
        {
            _uiDict = new();

            GetAllUiElement();
        }

        /// <summary>
        /// 返回一个BasicUi对象
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public BasicUi GetUi(string name)
        {
            return this._uiDict.GetValueOrDefault(name, null);
        }

        public T GetUi<T>(string name)where T : BasicUi
        {
            return GetUi(name) as T;
        }

        //public T GetUi(Type types,string name)
        //{
        //    Resources.Load();
        //    return 
        //}


    }
}