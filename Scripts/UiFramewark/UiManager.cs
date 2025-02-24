using Assets.Scripts.UiFramewark;
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

            ///��ȷ������е���չ����
            SetAllComponents();
        }

        /// <summary>
        /// ����
        /// </summary>
        private void Start()
        {
            
        }



        private Dictionary<string, GameObject> _currentActiveUiDict = new();

        public bool haveUi = false;

        /// <summary>
        /// �жϵ�ǰ�Ƿ���һ��������Ui������ʾ
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

            ///���������޸�haveUi��ֵ
            ///�Դ��������Ƿ��ظ�����
            RunAllExtension();

            ///run���⺯�����£�
            
            if(!haveUi)
                CreateUi(uiName);

            _currentActiveUiDict[uiName].SetActive(true);

            _currentActiveUiDict[uiName].transform.position = Vector3.zero;
        }

        public void HideUi(string uiName)
        {
            RunAllExtension();

            ///run���⺯�����£�
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

        #region Ui������������չ


        /// <summary>
        /// ui�Ĺ��ܲ��
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