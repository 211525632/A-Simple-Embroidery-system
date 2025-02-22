using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using XLua;

namespace UiFramewark
{
    [CSharpCallLua]
    [LuaCallCSharp]
    public class BasicLuaUiAction : BasicUiAction
    {

        public BasicLuaUiAction():base() 
        {
            
        }

        public void TestLua()
        {
            Debug.Log("TestLua");
        }

        public BasicLuaUiAction New()
        {
            Debug.Log("LuaBasicAction：：New");

            return new BasicLuaUiAction();
        }

        public override void OnCreate()
        {
            Debug.Log("LuaBasicAction：：Create");
        }

        public override void OnDestroy()
        {
            Debug.Log("LuaBasicAction：：Destroy");
        }

        public override void OnDisable()
        {
            Debug.Log("LuaBasicAction：：Disable");
        }

        public override void OnEnable()
        {
            Debug.Log("LuaBasicAction：：Enable");
        }
    }
}
