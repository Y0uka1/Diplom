using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ResourcesButton : MonoBehaviour
{
    UnityEngine.UI.Button button;
    GameObject panel;
    private void Start()
    {

        panel = gameObject.transform.parent.gameObject;
        Debug.Log(panel.GetComponent<RectTransform>().anchoredPosition);
        button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(PanelUP);
    }


    void PanelUP()
    {

        panel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-220, 250);
        button.onClick.AddListener(PanelDown);
        button.onClick.RemoveListener(PanelUP);
    }

    void PanelDown()
    {
        panel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-220, -150);
        button.onClick.AddListener(PanelUP);
        button.onClick.RemoveListener(PanelDown);
    }
}
