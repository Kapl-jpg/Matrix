using Assets.Scripts.Map;
using General;
using General.Save;
using Map;
using UnityEditor.Overlays;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private LockMap lockMap;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GameObject entryButton;

    private PointData _currentPointData;

    private void Start()
    {
        PointSelector.activate += ShowEntryPoint;
        PointSelector.deactivate += HideEntryPoint;
    }

    private void OnDestroy()
    {
        PointSelector.activate -= ShowEntryPoint;
        PointSelector.deactivate -= HideEntryPoint;
    }

    private void ShowEntryPoint(PointData data)
    {
        entryButton.SetActive(true);
        _currentPointData = data;
    }

    private void HideEntryPoint()
    {
        entryButton.SetActive(false);
    }

    //Изменить название метода
    public void GoHome()
    {
        if (_currentPointData.IsLocked)
        {
            lockMap.ShowMessage();
            return;
        }
        
        SavePointName.SetName(_currentPointData.Name);
        sceneLoader.LoadHomeScene();
    }
}
