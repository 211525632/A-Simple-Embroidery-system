
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UiFramewark
{
    //public class Model
    //{

    //}

    //public class View
    //{

    //}

    //public class Controller
    //{

    //}

    //public class M_ButtonAsset : View, IButton
    //{
    //    private Button _button;

    //    public M_ButtonAsset()
    //    {
    //        AddOrGetUiComponent();
    //    }

    //    public void AddOrGetButtonComponent()
    //    {
    //        _button.GetOrAddComponent<Button>();
    //    }

    //    public void AddOrGetUiComponent()
    //    {
    //        AddOrGetButtonComponent();
    //    }

    //    public void Run()
    //    {
            
    //    }

    //    /// <summary>
    //    /// 应该是点击按钮之后自动触发
    //    /// </summary>
    //    /// <param name="onClickTriggerEvent"></param>
    //    public void AddListenner(UnityAction onClickTriggerEvent)
    //    {
    //        _button?.onClick?.AddListener(onClickTriggerEvent);
    //    }

    //}


    //public class M_TextAsset : IUiComponent, IText
    //{
    //    private GameObject _textObj;
    //    public M_TextAsset()
    //    {

    //    }

    //    public void AddOrGetTextComponent()
    //    {

    //    }

    //    public void AddOrGetUiComponent()
    //    {
    //        AddOrGetTextComponent();
    //    }

    //    public void Run()
    //    {

    //    }
    //}



    public interface IButton
    {
        bool CheckButtonComponent();
        void AddListener(UnityAction onClickAction);

        void RemoveListener(UnityAction releaseAction);
    }

    public interface IText
    {
        bool CheckTextComponent();

        void SetText(string text);
        void UpdateText(string text);
    }

    public interface ISlider
    {
        float currentIndex { get; set; }

        float MaxIndex { get; set; }

        float MinIndex { get; set; }


        void SetSliderIndex(float currentIndex);

        void UpdateSlide();

    }
}
