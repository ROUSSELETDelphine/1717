using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorOpen : MonoBehaviour {

    public GameObject Pivot, Porte;
    public int Angle = 130;
    private int CurAngle;
    public bool Ouverture = false;

    public void Open()
    {
        if (CurAngle < Angle)
        {
            CurAngle += 1;
            Porte.transform.RotateAround(Pivot.transform.position, -Vector3.up, CurAngle * Time.deltaTime);
        }
        else
        {
            Ouverture = true;
        }
    }
}
