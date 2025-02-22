using Assets.Scripts;
using Obi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;
using XLua;

namespace UiFramewark
{

    /// <summary>
    /// Ui集合，是ui的容器
    /// 方便各种Ui的使用
    /// 通过他们各自的名称
    /// </summary>
    /// 

    [LuaCallCSharp]
    public class UiCollection : MonoBehaviour
    {
        public string ActionClassName = "None";

        private void Awake()
        {
            _uiDict = new();

            GetAllUiElement();
        }



        #region 初始化

        /// <summary>
        /// 存储所有Ui
        /// </summary>
        private Dictionary<string, BasicUi> _uiDict;

        /// <summary>
        /// 测试用，
        /// 用于可视化观看获取情况
        /// </summary>
        public BasicUi[] basicUis;

        /// 获取所有在这个物体之下的BasicUi组件
        /// </summary>
        private void GetAllUiElement()
        {
            basicUis = this.GetComponentsInChildren<BasicUi>();

            for (int i = 0; i < basicUis.Length; ++i)
            {
                if (!_uiDict.TryAdd(basicUis[i].name, basicUis[i]))
                {
                    Debug.LogError("存在同名Ui！name：" + basicUis[i].name);
                }
            }
        }

        #endregion



        #region 外部获取内部Ui的接口

        /// <summary>
        /// 返回一个BasicUi对象
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public BasicUi GetUi(string name)
        {
            return this._uiDict.GetValueOrDefault(name, null);
        }

        public T GetUi<T>(string name) where T : BasicUi
        {
            return GetUi(name) as T;
        }

        #endregion



        #region Ui集合的功能定制化

        private Action onEnable;
        private Action onDisable;
        private Action onDestroy;
        private Action OnUpdate;

        /// <summary>
        /// 将组件与lua脚本进行绑定与调用
        /// </summary>
        /// <param name="LuaName"></param>
        public void LuaBinding(string LuaName)
        {
            LuaTable table = LuaManager.LuaEnv.Global.GetChainValue(this.ActionClassName) as LuaTable;

            if(object.ReferenceEquals(null,table))
            {
                Debug.LogError("Cant find this table:Name:"+ActionClassName);
                return;
            }

            //注入脚本对象，可以用于获取组件
            table.Set("uiCollection",this);

            onEnable = table.Get<Action>("OnEnable");
            onDisable= table.Get<Action>("OnDisable");
            onDestroy= table.Get<Action>("OnDestroy");
            OnUpdate= table.Get<Action>("OnUpdate");

            onEnable();
        }

        private void OnEnable()
        {
            onEnable?.Invoke();
        }

        private void OnDisable()
        {
            onDisable?.Invoke();
        }

        private void OnDestroy()
        {
            onDestroy?.Invoke();
        }

        private void Update()
        {
            OnUpdate?.Invoke();
        }

        #endregion


    }
}