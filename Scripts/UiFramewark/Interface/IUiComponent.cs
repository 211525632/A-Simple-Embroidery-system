using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiFramewark
{
    /// <summary>
    /// 作为Ui系统扩展的模块
    /// 都需要继承这个接口
    /// 
    /// 
    /// 感觉需要分层
    /// 分为：
    /// OnShow
    /// OnHide
    /// OnDistroy（）
    /// ……
    /// UiManager中的不同执行函数来执行
    /// </summary>
    public interface IUiComponent
    {

        /// <summary>
        /// 功能模块运行
        /// </summary>
        void Run();
    }
}
