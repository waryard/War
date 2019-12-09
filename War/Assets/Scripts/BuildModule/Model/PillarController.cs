﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 木柱管理器, 用于填充缝隙.
/// </summary>
public class PillarController : MaterialModelBase
{
    protected override void OnCollisionEnter(Collision other)
    {
        // 与环境物体交互.
        if (other.gameObject.tag != "PlatformToPillar")
        {
            canPut = false;
        }
    }

    protected override void OnCollisionStay(Collision other)
    {
        // 放置之后, 不能再次在此地放置物体.
        if (other.gameObject.tag == gameObject.tag &&
            other.gameObject.GetComponent<Transform>().position == m_Transform.position)
        {
            canPut = false;
        }
    }

    protected override void OnCollisionExit(Collision other)
    {
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlatformToPillar")
        {
            canPut = true;
            isAttach = true;

            m_Transform.position = other.GetComponent<Transform>().position;
            m_Transform.rotation = other.GetComponent<Transform>().rotation;
        }
    }

    protected override void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlatformToPillar")
        {
            canPut = true;
            isAttach = true;
        }

        // 放置之后, 不能再次在此地放置物体.
        if (other.gameObject.tag == gameObject.tag &&
            other.gameObject.GetComponent<Transform>().position == m_Transform.position)
        {
            canPut = false;
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
    }
}