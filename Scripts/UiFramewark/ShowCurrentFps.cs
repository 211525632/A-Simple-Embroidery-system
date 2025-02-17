using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowCurrentFps : MonoBehaviour
{
    public TextMeshProUGUI TextMeshPro;

    private float m_LastUpdateShowTime = 0f;  //��һ�θ���֡�ʵ�ʱ��;  
    private float m_UpdateShowDeltaTime =0.2f;//����֡�ʵ�ʱ����;  
    private int m_FrameUpdate = 0;//֡��;  
    private float m_FPS = 0;//֡��

    private void Start()
    {
        m_LastUpdateShowTime = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        m_FrameUpdate++;
        if (Time.realtimeSinceStartup - m_LastUpdateShowTime >= m_UpdateShowDeltaTime)
        {
            //FPS = ĳ��ʱ���ڵ���֡�� / ĳ��ʱ��
            m_FPS = m_FrameUpdate / (Time.realtimeSinceStartup - m_LastUpdateShowTime);
            m_FrameUpdate = 0;
            m_LastUpdateShowTime = Time.realtimeSinceStartup;
            TextMeshPro.text = (1 / Time.deltaTime).ToString();
        }
    }
}
