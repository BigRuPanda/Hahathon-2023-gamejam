using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TestMobile : MonoBehaviour
{
    #region WebGL is on mobile check

    [DllImport(dllName:"__Internal")]
    private static extern bool IsMobile();

    public bool isMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        return IsMobile();
#endif
        return false;
    }
    #endregion



    #region Joystick Related Functions

    [Header("Joystick related variables")]

    [SerializeField]
    private Joystick joystick;

    private void DisableJoystick()
    {
        if (isMobile() == true) return;

        joystick.gameObject.SetActive(false);
    }
    #endregion



    private void Start()
    {
        DisableJoystick();
    }

    private void Update()
    {
    }
}