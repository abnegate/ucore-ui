using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public List<ButtonHandler> buttonHandlers;

    void Awake()
    {
        Button btn;
        foreach (var handler in buttonHandlers) {
            if (handler.buttonName == null
                || handler.onClick == null) {
                continue;
            }
            var obj = GameObject.Find(handler.buttonName);
            if (obj != null && (btn = obj.GetComponent<Button>()) != null) {
                btn.onClick.AddListener(handler.onClick.Invoke);
            }
        }
    }
}
