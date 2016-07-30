using UnityEngine;
using System.Collections;

public class Entrance : MonoBehaviour {

	// Use this for initialization
    private int count;
    private Rendering.PostProcessUnits.PPUBlackAndWhite bawppu;

	void Start () {
        Rendering.RenderingMgr.Instance.Init();
        bawppu = new Rendering.PostProcessUnits.PPUBlackAndWhite();
        WindowMgr.Instance.Init();
        //Dispatcher.Dispatch<int>(GameEvents.WindowStartUpEvent.EVT_NAME, UIModule.LOGIN);
        Rendering.RenderingMgr.Instance.AddUnitAtLast(bawppu);

        //Rendering.PostProcessUnits.PPUBlackAndWhite testppu1 = new Rendering.PostProcessUnits.PPUBlackAndWhite();
        //Rendering.RenderingMgr.Instance.AddUnitAtLast(testppu1);
        count = 0;

    }
	
	// Update is called once per frame
	void Update () {
        count++;
        if (count == 300)
            Rendering.RenderingMgr.Instance.RemoveNode(bawppu);

        if (count == 500)
            Rendering.RenderingMgr.Instance.PauseRendering();

        if (count == 700)
            Rendering.RenderingMgr.Instance.ResumeRendering();

        if (count == 900)
            Rendering.RenderingMgr.Instance.PauseRendering(true);

        if (count == 1100)
            Rendering.RenderingMgr.Instance.ResumeRendering();

        if (count == 1300)
            Rendering.RenderingMgr.Instance.AddUnitAtLast(bawppu);
    }
}
