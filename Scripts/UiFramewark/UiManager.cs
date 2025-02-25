
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace UiFramewark
{
    public class UiManager : MonoSingleton<UiManager>
    {

        public Transform _rootTrans;

        protected override void Awake()
        {
            base.Awake();

            _rootTrans = new GameObject("Ui_Root").transform;

            ///正确添加所有的扩展功能
            SetAllComponents();
        }

        /// <summary>
        /// 测试
        /// </summary>
        private void Start()
        {
            
        }



        private Dictionary<string, GameObject> _currentActiveUiDict = new();

        public bool haveUi = false;

        /// <summary>
        /// 判断当前是否有一个这样的Ui正在显示
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool JudgeTargetUiState(string name)
        {
            return !object.ReferenceEquals(_currentActiveUiDict.GetValueOrDefault(name,null), null);
        }

        public void ShowUi(string uiName)
        {
            this.haveUi = JudgeTargetUiState(uiName);

            ///允许做出修改haveUi的值
            ///以此来控制是否重复加载
            RunAllExtension();

            ///run主题函数如下：
            
            if(!haveUi)
                CreateUi(uiName);

            _currentActiveUiDict[uiName].SetActive(true);

            _currentActiveUiDict[uiName].transform.position = Vector3.zero;
        }

        public void HideUi(string uiName)
        {
            RunAllExtension();

            ///run主题函数如下：
            _currentActiveUiDict[uiName].SetActive(false);
        }



        public void CreateUi(string name)
        {
            GameObject ui = Instantiate<GameObject>(UiResoucesManager.Instance.LoadUi(name),_rootTrans);

            _currentActiveUiDict.Add(name,ui);
        }

        public void DestroyUi(string name)
        {
            _currentActiveUiDict.Remove(name);
        }

        #region Ui管理器功能扩展


        /// <summary>
        /// ui的功能插件
        /// </summary>
        private List<IUiComponent> _uiComponents = new();


        private void RunAllExtension()
        {
            for (int i = 0; i < _uiComponents.Count; ++i)
            {
                _uiComponents[i].Run();
            }
        }

        private void SetAllComponents()
        {
            //SetComponent();
        }

        private void SetComponent(IUiComponent extension)
        {
            if (object.ReferenceEquals(null, extension))
                return;

            _uiComponents.Add(extension);
        }

        #endregion
    }

}