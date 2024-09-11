using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton_hide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Show()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
    }
    public void Hide()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
    }
    public void Click()
    {
        Hide();
    }
}
