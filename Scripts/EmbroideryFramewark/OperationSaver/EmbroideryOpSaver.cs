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
        /// 如果有光泽度等需求，再进行添加即可
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
        //颜色
        public Vector4 color;

        ///其他

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

        [Header("测试相关：")]
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
        /// 存放每一次操作的绳子信息
        /// </summary>
        public readonly Stack<SingleRopeData> RopeDatas = new();


        /// <summary>
        /// 存放所有被实例化的模型实例
        /// 通过销毁或者隐藏这个里面的元素来实现撤销操作
        /// </summary>
        public readonly Stack<GameObject> RopeModels = new();

        /// <summary>
        /// 保存一次刺绣操作
        /// </summary>
        /// <param name="currentRopeHelper"></param>
        public void SaveOp(SingleRopeHelper currentRopeHelper)
        {
            RopeDatas.Push(new SingleRopeData(currentRopeHelper));
        }





        #region 存档相关

        private SingleRopeData _singleRopeData;

        /// <summary>
        /// 根据当前栈顶元素来初始化新的Rope
        /// 用于恢复之前还没有秀完的刺绣
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