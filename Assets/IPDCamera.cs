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
using EasyLazyLibrary;

public class IPDCamera : MonoBehaviour
{
    [SerializeField]
    private Camera LeftEye;
    [SerializeField]
    private Camera RightEye;
    [SerializeField]
    private GameObject Head;
    [SerializeField]
    private GameObject LeftHand;
    [SerializeField]
    private GameObject RightHand;

    EasyOpenVRUtil util = new EasyOpenVRUtil(); //姿勢取得ライブラリ

    void Start()
    {
        
    }

    void Update()
    {
        if (!util.IsReady())
        {
            util.Init();
            return;
        }

        var h = util.GetHMDTransform();
        if (h != null)
        {
            Head.transform.position = h.position;
            Head.transform.rotation = h.rotation;
        }

        //IPD取得してカメラに反映
        float IPD = util.GetPropertyFloatWhenConnected(util.GetHMDIndex(), Valve.VR.ETrackedDeviceProperty.Prop_UserIpdMeters_Float);
        if (!float.IsNaN(IPD))
        {
            LeftEye.transform.localPosition = new Vector3(-IPD / 2f, 0, 0);
            RightEye.transform.localPosition = new Vector3(IPD / 2f, 0, 0);
        }

        var l = util.GetLeftControllerTransform();
        if (l != null) {
            LeftHand.transform.position = l.position;
            LeftHand.transform.rotation = l.rotation;
        }

        var r = util.GetRightControllerTransform();
        if (r != null)
        {
            RightHand.transform.position = r.position;
            RightHand.transform.rotation = r.rotation;
        }
    }
}
