using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "newList", menuName = "PowerUps/List")]
public class PowerUpList : ScriptableObject
{
    public GameObject[] powerUps;

#if UNITY_EDITOR
    [SerializeField] private bool _revert;
    private string _initialJson = string.Empty;
#endif
    private void OnEnable()
    {
#if UNITY_EDITOR
        EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
#endif
    }

#if UNITY_EDITOR
    private void OnPlayModeStateChanged(PlayModeStateChange obj)
    {
        switch (obj)
        {
            case PlayModeStateChange.EnteredPlayMode:
                _initialJson = EditorJsonUtility.ToJson(this);
                break;

            case PlayModeStateChange.ExitingPlayMode:
                EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
                if (_revert)
                    EditorJsonUtility.FromJsonOverwrite(_initialJson, this);
                break;
        }
    }
#endif
}
