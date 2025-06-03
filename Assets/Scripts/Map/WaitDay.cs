using System.Collections;
using UnityEngine;

namespace Map
{
    public class WaitDay : MonoBehaviour
    {
        [SerializeField] private MapCreator mapCreator;
        [SerializeField] private GameObject unclickableMask;
        [SerializeField] private float waitTime;

        public void WaitNextDay()
        {
            mapCreator.Clear();
            StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            unclickableMask.SetActive(true);
            yield return new WaitForSeconds(waitTime);
            mapCreator.Rebuild();
            unclickableMask.SetActive(false);
        }
    }
}
