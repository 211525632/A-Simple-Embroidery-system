using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowCurrentFps : MonoBehaviour
{
    public TextMeshProUGUI TextMeshPro;

    private float m_LastUpdateShowTime = 0f;  //上一次更新帧率的时间;  
    private float m_UpdateShowDeltaTime =0.2f;//更新帧率的时间间隔;  
    private int m_FrameUpdate = 0;//帧数;  
    private float m_FPS = 0;//帧率

    private void Start()
    {
        m_LastUpdateShowTime = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        m_FrameUpdate++;
        if (Time.realtimeSinceStartup - m_LastUpdateShowTime >= m_UpdateShowDeltaTime)
        {
            //FPS = 某段时间内的总帧数 / 某段时间
            m_FPS = m_FrameUpdate / (Time.realtimeSinceStartup - m_LastUpdateShowTime);
            m_FrameUpdate = 0;
            m_LastUpdateShowTime = Time.realtimeSinceStartup;
            TextMeshPro.text = (1 / Time.deltaTime).ToString();
        }
    }
}
