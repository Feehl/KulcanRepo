using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;

/// <summary>
/// A static class for general helpful methods
/// </summary>
public static class Helpers 
{
    //Helpers.Camera
    private static Camera _camera;
    public static Camera Camera
    {
        get
        {
            if (_camera == null) _camera = Camera.main;
            return _camera;
        }
    }

    //transform.DestroyChildren()
    public static void DestroyChildren(this Transform t) {
        foreach (Transform child in t) Object.Destroy(child.gameObject);
    }

    //Helpers.GetWait(time)
    private static readonly Dictionary<float, WaitForSeconds> WaitDict = new Dictionary<float, WaitForSeconds>();
    public static WaitForSeconds GetWait(float time)
    {
        if (WaitDict.TryGetValue(time, out var wait)) return wait;

        WaitDict[time] = new WaitForSeconds(time);
        return WaitDict[time];
    }

    //Helpers.IsOverUI()
    private static PointerEventData _currentPos;
    private static List<RaycastResult> _results;
    public static bool IsOverUI()
    {
        _currentPos = new PointerEventData(EventSystem.current) { position = Input.mousePosition };//wrong inputsystem
        _results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(_currentPos, _results);
        return _results.Count > 0;
    }

    //Helpers.GetWorldPositionOfCanvasElement(followTarget)
    public static Vector2 GetWorldPositionOfCanvasElement(RectTransform rectTransform)
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, rectTransform.position, Camera, out var result);
        return result;
    }

}
