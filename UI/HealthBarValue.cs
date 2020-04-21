using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarValue : MonoBehaviour
{
   

    public void ValueChange(float val)
    {
        transform.localScale = new Vector3(val, 1f);

    }
}
