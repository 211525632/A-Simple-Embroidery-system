using System.Collections;
using UnityEngine;

namespace EmbroideryFramewark
{
    /// <summary>
    /// 用于检测输入操作
    /// 执行 保存/撤销 操作
    /// </summary>
    public class EmbroideryOpSaverCtl : MonoSingleton<EmbroideryOpSaverCtl>
    {

        private EmbroideryOpSaver _saver;


        protected override void Awake()
        {
            base.Awake();

            _saver = new();
        }

        void Update()
        {
            Run();
        }

        private bool _active = true;


        /// <summary>
        /// 触发必然是从\
        ///  
        /// (false,false) -> (false | true) -> (false,false)
        /// </summary>
        private void Run()
        {
            if(!_active)
            {
                if(!(m_MouseInput.IsRevokeOp || m_MouseInput.IsSaveOp))
                {
                    _active = true;    
                }
                return;
            }

            if (m_MouseInput.IsSaveOp)
            {
                Debug.Log("向前回忆");
                _saver.RecollectOp();
                _active = false;
            }
            else if(m_MouseInput.IsRevokeOp)
            {
                Debug.Log("向后撤销");
                _saver.RevokeOp();
                _active = false;
            }
        }


        public void RecollectOp() { 
            _saver.RecollectOp(); 
        }

        public void RevokeOp()
        {
            _saver.RevokeOp();
        }

        public void SaveNewOp(SingleRopeHelper currentRopeHelper, GameObject ropeModel) 
        { 
            _saver.SaveOp(currentRopeHelper,ropeModel); 
        }

        

        private void Enable()
        {
            this.gameObject.SetActive(true);
        }

        private void Disable()
        {
            this.gameObject.SetActive(false);
        }
    }
}