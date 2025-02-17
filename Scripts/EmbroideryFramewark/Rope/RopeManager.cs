using Obi;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace EmbroideryFramewark
{
    /// <summary>
    /// 1.����ʹ������������ RopeHelper��������ӵ�ģ��
    /// 2.��ɴ����RopeHelper�ڽ���֮�󣬻��ȱ��浱ǰ��Mesh
    /// 3.֮�����������һ������ģ���RopeHelper
    /// </summary>

    [RequireComponent(typeof(SingleRopeHelper))]
    [RequireComponent(typeof(RopePool))]

    public class RopeManager : MonoSingleton<RopeManager>
    {
        [Header("����ʹ��AB��ʵ�֣�")]

        ///�����Ҫ���������Ĳ��ʣ�����Ҫ�������ģ��Ĳ���
        [SerializeField] public GameObject _ropeModel;

        [SerializeField] public GameObject _obiSolverModel;

        [SerializeField] public GameObject _empty;


        public GameObject _objModelRoot { get; private set; }



        #region RopeHelper��
        /// <summary>
        /// ֻ�ܴӳ��л�ȡRopeHelper
        /// </summary>
        private RopePool _ropePool;

        /// <summary>
        /// TODO���ĳɷ���ʹ��
        /// ��ǰ���ӵĲ���
        /// </summary>
        public SingleRopeHelper CurrentRopeHelper
        {
            get => this._ropePool.CurrentRopeHelper;
        }

        /// <summary>
        /// ��һ�����ӵĲ���
        /// </summary>
        public SingleRopeHelper PreferRopeHelper
        {
            get => this._ropePool.PreRopeHelper;
        }

        #endregion


        public float RopeRidus
        {
            get => _ropePool.RopeRidus;
        }


        protected override void Awake()
        {
            base.Awake();
            //_objRoot = Instantiate<GameObject>(_obiSolverModel);
            //_objRoot.name = "Root_"+_obiSolverModel.name;


            _objModelRoot = Instantiate<GameObject>(_empty);
            _objModelRoot.name = "Root_RopePool";


            _ropePool = new();

            SetEvent();
        }

        private void Start()
        {
            
        }

        /// <summary>
        /// ��ÿһ�����ӵĴ洢
        /// TODO����Ҫά��
        /// </summary>
        private List<SingleRopeHelper> _ropeList = new();

        [SerializeField] private List<GameObject> _ropeModelList = new();


        /// <summary>
        /// �����µ�����
        /// �����CurrentRope��PreferRope��ֵ
        /// </summary>
        /// <param name="ropeBeginPosition"></param>
        /// <param name="ropeEnd"></param>
        /// <param name="ropeLength"></param>
        public void CreateRope(Vector3 ropeBeginPosition, Vector3 ropeEnd, float ropeLength)
        {
            CreateRope(ropeBeginPosition, ropeEnd, ropeLength,null);
        }

        public void CreateRope(Vector3 ropeBeginPosition, Vector3 ropeEnd, float ropeLength,Material ropeMaterial)
        {

            _ropePool.ReturnPreRope();
            _ropePool.BorrowRopeAndInit(ropeBeginPosition, ropeEnd, ropeLength);

            CurrentRopeHelper.SetEndLoackState(true);

            if (!object.ReferenceEquals(null, ropeMaterial))
            {
                CurrentRopeHelper.GetComponentInChildren<Renderer>().sharedMaterial = ropeMaterial;
            }
        }


        #region RopeHelper��ģ�ͻ�

        /// <summary>
        /// ��ָ����ŵ�Rope�滻��Model
        /// 
        /// ������ҪRopeHelper
        /// </summary>
        public void RopeChangeToModel()
        {
            GameObject model = this.PreferRopeHelper.
                GetRopeModelObj();
            //��̬������
            model.isStatic = true;


            _ropeModelList.Add(model);

        }

        #endregion


        #region �¼�����

        public void SetEvent()
        {
            //EventCenter<Action>.Instance.AddEvent(EventConst.OnPinEndEnter, _ropePool.ReturnPreRope);
        }

        #endregion

    }
}