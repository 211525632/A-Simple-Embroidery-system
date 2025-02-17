using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePinRotation : MonoBehaviour
{
    public GameObject pin;

    private int fushu = 1;

    public void Rotate()
    {
        pin.transform.rotation = Quaternion.Euler(90 * fushu, 0, 0);
        fushu = -fushu ;
    }
}
