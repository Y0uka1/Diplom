using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchBar : MonoBehaviour
{

    RectTransform rect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    public void ValueChange(float val)
    {
        rect.localScale= new Vector3(val, 1f);

    }
}
