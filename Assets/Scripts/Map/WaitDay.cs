using Assets.Scripts.Map;
using System.Collections;
using UnityEngine;

public class WaitDay : MonoBehaviour
{
    [SerializeField] private MapCreater mapCreater;
    [SerializeField] private GameObject unclickableMask;
    [SerializeField] private float waitTime;

    public void WaitNextDay()
    {
        mapCreater.Clear();
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        unclickableMask.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        mapCreater.Rebuild();
        unclickableMask.SetActive(false);
    }
}
