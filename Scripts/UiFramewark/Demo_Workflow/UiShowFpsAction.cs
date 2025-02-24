using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiFramewark;
using UnityEngine.SocialPlatforms;

namespace UiFramewark
{
    ///// <summary>
    ///// 1.确保你已经完成unityEditor层面的 UI设计，Ui相关组件绑定，AB包打包
    ///// （没有写好AB包的当下，使用拖动实现）
    ///// </summary>
    //public class UiShowFpsAction : BasicUiAction
    //{
    //    public override void OnCreate()
    //    {

    //    }

    //    public override void OnDestroy()
    //    {

    //    }

    //    public override void OnDisable()
    //    {

    //    }

    //    public override void OnEnable()
    //    {

    //    }
    //}
///使用lua实现这个脚本
//    -- 使用 CS 表访问 C# 的 BasicUiAction 类


//local BasicUiAction = CS.BasicUiAction

//-- 定义 UiShowFpsAction 类
//local UiShowFpsAction = {}

//--设置元表，使其可以访问 BasicUiAction 的方法
//UiShowFpsAction.__index = UiShowFpsAction

//-- 创建实例的方法
//function UiShowFpsAction:new()
//    local instance = setmetatable({}, UiShowFpsAction)
//    -- 调用 C# 的构造函数
//    BasicUiAction.Construct(instance)
//    return instance
//end

//-- 覆盖 OnCreate 方法
//function UiShowFpsAction:OnCreate()
//    print("UiShowFpsAction: OnCreate")
//    -- 调用基类的方法（可选）
//    -- BasicUiAction.OnCreate(self)
//end

//-- 覆盖 OnDestroy 方法
//function UiShowFpsAction:OnDestroy()
//    print("UiShowFpsAction: OnDestroy")
//    -- 调用基类的方法（可选）
//    -- BasicUiAction.OnDestroy(self)
//end

//-- 覆盖 OnDisable 方法
//function UiShowFpsAction:OnDisable()
//    print("UiShowFpsAction: OnDisable")
//    -- 调用基类的方法（可选）
//    -- BasicUiAction.OnDisable(self)
//end

//-- 覆盖 OnEnable 方法
//function UiShowFpsAction:OnEnable()
//    print("UiShowFpsAction: OnEnable")
//    -- 调用基类的方法（可选）
//    -- BasicUiAction.OnEnable(self)
//end

//-- 返回类
//return UiShowFpsAction
}
