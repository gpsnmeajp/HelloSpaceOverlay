/*
* HelloSpaceOverlay by gpsnmeajp
* https://github.com/gpsnmeajp/HelloSpaceOverlay
* https://sabowl.sakura.ne.jp/gpsnmeajp/
*
* These codes are licensed under CC0.
* http://creativecommons.org/publicdomain/zero/1.0/deed.ja
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BothEyeCameraScript : MonoBehaviour
{
    public Material RenderingMaterial;
    // Start is called before the first frame update
    void Start()
    {
        var buf = new CommandBuffer();
        var rt = new RenderTexture(16, 16, 24); //ダミー

        //マテリアルに指定されたほうが真の効果を発揮する
        buf.Blit(rt, BuiltinRenderTextureType.CameraTarget,RenderingMaterial);
        GetComponent<Camera>().RemoveAllCommandBuffers();
        GetComponent<Camera>().AddCommandBuffer(CameraEvent.AfterEverything, buf);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
