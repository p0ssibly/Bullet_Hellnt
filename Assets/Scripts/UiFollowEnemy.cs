using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiFollowEnemy : MonoBehaviour
{
    public Transform objectTofollow;
    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (objectTofollow != null)
            rectTransform.anchoredPosition = objectTofollow.localPosition;
    }
}
