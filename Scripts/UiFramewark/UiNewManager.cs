using System.Collections;
using System.Collections.Generic;
using UiFramewark;
using UnityEngine;

namespace Assets.Scripts.UiFramewark
{

    /// <summary>
    /// TODO:需要写，对于刚刚初始化的UI
    /// 我们需要一个Ui事件监听器。
    /// 当某个UiCollection被show的时候
    /// 需要发送广播
    /// 对于需要的模块进行事件 绑定
    /// </summary>
    public class UiNewManager : MonoSingleton<UiNewManager>
    {

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            _uilayerManager = new UiLayerManager();
        }

        private UiLayerManager _uilayerManager;


        #region -------------------------Ui的显示-------------------------------



        /// <summary>
        /// 生成的UiCollection位于Main层
        /// </summary>
        /// <param name="collectionName">UiCollection的名称</param>
        public void ShowUiCollection(string collectionName)
        {
            ShowUiCollection(collectionName, UiLayer.GetLayer("Main"));
        }





        /// <summary>
        /// 生成的UiCollection位于指定层
        /// </summary>
        /// <param name="collectionName">   UiCollection的名称</param>
        /// <param name="uiLayerNum">       Layer的标号</param>
        public void ShowUiCollection(string collectionName, int uiLayerNum)
        {
            this.ShowUiColliction(collectionName, _uilayerManager.GetLayerRootTrans(uiLayerNum));
        }






        private GameObject tempUiCollection = null;

        /// <summary>
        /// 生成的UiCollection位于指定的物体之下
        /// </summary>
        /// <param name="collectionName">   UiCollection的名称</param>
        /// <param name="uilayerTrans"      被设置成ui集群的父物体</param>
        private void ShowUiColliction(string collectionName, Transform uilayerTrans)
        {
            /// if(在pool中存在合适的对象)
            /// {   直接调用pool中的active代码  }
            /// else
            /// {   进行下面操作 }

            ///资源加载
            tempUiCollection = UiResoucesManager.Instance.LoadUi(collectionName);
            //实例化
            tempUiCollection = Instantiate<GameObject>(tempUiCollection);

            if (object.ReferenceEquals(null, tempUiCollection))
            {
                Debug.LogError("在ui资源中找不到合适的资源：name:" + collectionName);
                return;
            }

            ///TODO:设置在uiPool的管理下
            ///AddToUiPool（）；

            this._uilayerManager.SetUiLayer(
                tempUiCollection.GetComponent<UiCollection>(),
                uilayerTrans
                );


            ///添加到资源管理
            _currentActiveUiCollections.Add(collectionName,tempUiCollection.GetComponent<UiCollection>());

        }

        #endregion


        #region ---------------------ui资源管理------------------------ 

        private Dictionary<string, UiCollection> _currentActiveUiCollections = new();

        /// <summary>
        /// 得到当前
        /// </summary>
        /// <param name="name"></param>
        public UiCollection GetUiCollection(string name)
        {
            return _currentActiveUiCollections.GetValueOrDefault(name, null);
        }


        #endregion
    }
}