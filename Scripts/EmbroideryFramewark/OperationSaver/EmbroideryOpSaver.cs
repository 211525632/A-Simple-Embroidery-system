using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pinwheel.MeshToFile;

namespace EmbroideryFramewark
{
    public struct SingleRopeData
    {
        public Vector3 begin;
        public Vector3 end;

        /// <summary>
        /// ����й���ȵ������ٽ�����Ӽ���
        /// </summary>
        public MaterialData materalData;


        public SingleRopeData(Vector3 begin,Vector3 end,Material material)
        {
            this.begin = begin;
            this.end = end;

            this.materalData = new MaterialData(material);
        }

        public SingleRopeData(SingleRopeHelper ropeHelper)
        {
            this = new SingleRopeData(ropeHelper._beginTransform.position, ropeHelper._endTransform.position,
                ropeHelper.GetMeshRender().GetComponent<Renderer>().sharedMaterial);
        }
    }

    public struct MaterialData
    {
        //��ɫ
        public Vector4 color;

        ///����

        public MaterialData(Material material)
        {
            this.color = material.color;
        }
    }



    [RequireComponent(typeof(RopeManager))]
    public class EmbroideryOpSaver : MonoSingleton<EmbroideryOpSaver>
    {
        protected override void Awake()
        {
            base.Awake();
        }

        [Header("������أ�")]
        public bool isEnableSaveTest = false;

        public bool isEnableReSetTest = false;

        private void Update()
        {
            if (isEnableSaveTest)
            {
                isEnableSaveTest = false;
                this.SaveOp(RopeManager.Instance.PreferRopeHelper);
            }

            if (isEnableReSetTest)
            {
                isEnableReSetTest = false;
                this.ReCreateRope();
            }
        }


        /// <summary>
        /// ���ÿһ�β�����������Ϣ
        /// </summary>
        public readonly Stack<SingleRopeData> RopeDatas = new();


        /// <summary>
        /// ������б�ʵ������ģ��ʵ��
        /// ͨ�����ٻ���������������Ԫ����ʵ�ֳ�������
        /// </summary>
        public readonly Stack<GameObject> RopeModels = new();

        /// <summary>
        /// ����һ�δ������
        /// </summary>
        /// <param name="currentRopeHelper"></param>
        public void SaveOp(SingleRopeHelper currentRopeHelper)
        {
            RopeDatas.Push(new SingleRopeData(currentRopeHelper));
        }





        #region �浵���

        private SingleRopeData _singleRopeData;

        /// <summary>
        /// ���ݵ�ǰջ��Ԫ������ʼ���µ�Rope
        /// ���ڻָ�֮ǰ��û������Ĵ���
        /// </summary>
        public void ReCreateRope()
        {
            if (RopeDatas.TryPop(out _singleRopeData))
            {
                RopeManager.Instance.CreateRope(_singleRopeData.begin, _singleRopeData.end, 0.1f);
            }
        }

        #endregion

    }

}