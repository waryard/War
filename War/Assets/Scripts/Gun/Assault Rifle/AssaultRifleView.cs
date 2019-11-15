﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 突击步枪V层.
/// </summary>
public class AssaultRifleView : MonoBehaviour
{
    private Transform m_Transform;
    private Animator m_Animator;
    private Camera m_EnvCamera;

    // 枪械开镜动作优化.
    private Vector3 startPos;
    private Vector3 startRot;
    private Vector3 endPos;
    private Vector3 endRot;

    public Transform M_Transform { get => m_Transform; }
    public Animator M_Animator { get => m_Animator; }
    public Camera M_EnvCamera { get => m_EnvCamera; }

    void Awake()
    {
        FindAndLoadInit();
        InitHoldPose();
    }

    /// <summary>
    /// 查找加载初始化.
    /// </summary>
    private void FindAndLoadInit()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        m_Animator = gameObject.GetComponent<Animator>();
        m_EnvCamera = GameObject.Find("FPSController/EnvCamera").GetComponent<Camera>();
    }

    /// <summary>
    /// 初始化开镜动作.
    /// </summary>
    private void InitHoldPose()
    {
        startPos = m_Transform.localPosition;
        startRot = m_Transform.localRotation.eulerAngles;
        endPos = new Vector3(-0.065f, -1.85f, 0.25f);
        endRot = new Vector3(2.8f, 1.3f, 0.08f);
    }

    /// <summary>
    /// 进入开镜状态.
    /// </summary>
    public void EnterHoldPose(float time = 0.2f, float fov = 40.0f)
    {
        m_Transform.DOLocalMove(endPos, time);
        m_Transform.DOLocalRotate(endRot, time);

        m_EnvCamera.DOFieldOfView(fov, time);
    }

    /// <summary>
    /// 退出开镜状态.
    /// </summary>
    public void ExitHoldPose(float time = 0.2f, float fov = 60.0f)
    {
        m_Transform.DOLocalMove(startPos, time);
        m_Transform.DOLocalRotate(startRot, time);

        m_EnvCamera.DOFieldOfView(fov, time);
    }
}
