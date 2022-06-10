using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyRotation : MonoBehaviour
{
  
  public void RotateBody(float r)
  {
      transform.localEulerAngles = Vector3.up * r;
  }
}
