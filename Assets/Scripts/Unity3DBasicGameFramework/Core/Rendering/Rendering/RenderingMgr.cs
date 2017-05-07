﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Rendering
{
    public class ScreenStruct
    {
        public GameObject ScreenRoot;
        public GameObject ScreenQuad;
        public GameObject ProcessCamObj;
        public GameObject OutputCamObj;
        public Camera ProcessCam;
        public Camera OutputCam;
        public Material DefaultMat;
        public Shader DefaultShader;
        public RenderTexture FFrameBuffer;
        public RenderTexture BFrameBuffer;
    };

    public partial class RenderingMgr : Singleton<RenderingMgr>
    {
        static private Vector2 m_vec2Resolution;

        private LinkedList<IRenderingNode> m_llRenderingNodeList;
        private Camera m_camProcessor;
        private RenderingDriver m_driver;
        public ScreenStruct m_csScreen;
        private Ticker m_ticker;
        private Dictionary<string, LinkedListNode<IRenderingNode>> m_dicCrucialNodes;


        public RenderingMgr()
        {
            m_dicCrucialNodes = new Dictionary<string, LinkedListNode<IRenderingNode>>();
            m_llRenderingNodeList = new LinkedList<IRenderingNode>();
            m_csScreen = new ScreenStruct();
        }

        public RenderTexture CFrameBuffer
        {
            get
            {
                return m_csScreen.FFrameBuffer;
            }
        }

        public ScreenStruct ScreenInfo
        {
            get
            {
                return m_csScreen;
            }
        }

        //the resolution of rt which is used for frame buffer must strictly the same with real screen resolution
        //otherwise the eventsystem and scaling of ugui will get into trouble
        //eventsystem trouble means serious accuracy problem
        public void ResetResolution()
        {
            ForceTerminateRendering();
            m_csScreen.FFrameBuffer = new RenderTexture(Screen.width, Screen.height, 24);
            m_csScreen.BFrameBuffer = new RenderTexture(Screen.width, Screen.height, 24);
            SetUpTestCam();
            m_vec2Resolution = new Vector2(Screen.width, Screen.height);
            SetFrameBuffer();
            float y = m_csScreen.ProcessCam.orthographicSize * 2.0f;
            float x = m_vec2Resolution.x / m_vec2Resolution.y * y;
            m_csScreen.ScreenQuad.transform.localScale = new Vector3(x, y, 1.0f);
            //m_csScreen.RawImgComp.texture = m_csScreen.CFrameBuffer;
            //m_csScreen.RawImgComp.material = m_csScreen.DefaultMat;


            ResumeRendering();
        }

        private void SetUpTestCam()
        {
            GameObject obj1 = new GameObject();
            obj1.name = "FFrameBufferHolder";
            Camera cam1 = obj1.AddComponent<Camera>();
            cam1.enabled = false;
            cam1.targetTexture = m_csScreen.FFrameBuffer;

            GameObject obj2 = new GameObject();
            obj2.name = "BFrameBufferHolder";
            Camera cam2 = obj2.AddComponent<Camera>();
            cam2.enabled = false;
            cam2.targetTexture = m_csScreen.BFrameBuffer;
        }

    }
}
